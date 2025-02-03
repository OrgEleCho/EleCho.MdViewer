namespace EleCho.MdViewer.Markdown;

public class MarkdownLinkNavigateEventArgs(string? link) : EventArgs
{
    public string? Link { get; set; } = link;
}
