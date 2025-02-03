using System.Windows;
using System.Windows.Controls;
using Markdig;
using Markdig.Syntax;
using EleCho.MdViewer.Markdown;

namespace EleCho.MdViewer;

public class MarkdownViewer : Control
{
    private readonly MarkdownPipeline pipeline;
    public MarkdownViewer()
    {
        pipeline = new MarkdownPipelineBuilder()
                            .UseEmphasisExtras()
                            .UseGridTables()
                            .UsePipeTables()
                            .UseTaskLists()
                            .UseAutoLinks()
                            .Build();
    }
    static MarkdownViewer()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(MarkdownViewer), new FrameworkPropertyMetadata(typeof(MarkdownViewer)));
    }

    public string Content
    {
        get { return (string)GetValue(ContentProperty); }
        set { SetValue(ContentProperty, value); }
    }

    public FrameworkElement RenderedContent
    {
        get { return (FrameworkElement)GetValue(RenderedContentProperty); }
        private set { SetValue(RenderedContentProperty, value); }
    }

    public static readonly DependencyProperty ContentProperty =
        DependencyProperty.Register(nameof(Content), typeof(string), typeof(MarkdownViewer), new PropertyMetadata(string.Empty, ContentChangedCallback));

    public static readonly DependencyProperty RenderedContentProperty =
         DependencyProperty.Register(nameof(RenderedContent), typeof(FrameworkElement), typeof(MarkdownViewer), new PropertyMetadata(null));


    private async Task RenderProcessAsync(CancellationToken cancellationToken)
    {
        try
        {
            if (cancellationToken.IsCancellationRequested)
                return;

            string content = Content;

            MarkdownDocument? doc =
                await Task.Run(() =>
                {
                    var doc = Markdig.Markdown.Parse(
                        content,
                        pipeline);

                    return doc;
                });

            var renderer = new MarkdownWpfRenderer();
            ContentControl contentControl =new();
            RenderedContent = contentControl;
            renderer.RenderDocumentTo(contentControl, doc, cancellationToken);
        }
        catch { }
    }

    Task? renderProcessTask;
    CancellationTokenSource? renderProcessCancellation;

    private static void ContentChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is not MarkdownViewer markdownViewer)
            return;

        if (markdownViewer.renderProcessCancellation is CancellationTokenSource cancellation)
            cancellation.Cancel();

        cancellation =
            markdownViewer.renderProcessCancellation =
            new CancellationTokenSource();

        markdownViewer.renderProcessTask = markdownViewer.RenderProcessAsync(cancellation.Token);
    }
}
