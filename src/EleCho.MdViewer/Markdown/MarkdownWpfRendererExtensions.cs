using System.Windows;
using System.Windows.Controls;

using WpfDocs = System.Windows.Documents;

namespace EleCho.MdViewer.Markdown;

public static class MarkdownWpfRendererExtensions
{
    public static TextBlock BindMainForeground(this TextBlock element)
    {
        element.SetResourceReference(TextBlock.ForegroundProperty, MarkdownResKey.MainForeground);
        return element;
    }
    public static TextBlock BindHeadingForeground(this TextBlock element)
    {
        element.SetResourceReference(TextBlock.ForegroundProperty,MarkdownResKey.HeadingForeground);
        return element;
    }


    public static TextBlock BindCodeBlockForeground(this TextBlock element)
    {
        element.SetResourceReference(TextBlock.ForegroundProperty, MarkdownResKey.CodeBlockForeground);
        return element;
    }

    public static Border BindQuoteBlockBackground(this Border element)
    {
        element.SetResourceReference(Border.BackgroundProperty, MarkdownResKey.QuoteBlockBackground);
        return element;
    }

    public static Border BindCodeBlockBackground(this Border element)
    {
        element.SetResourceReference(Border.BackgroundProperty, MarkdownResKey.CodeBlockBackground);
        return element;
    }


    public static Border BindCodeInlineBackground(this Border element)
    {
        element.SetResourceReference(Border.BackgroundProperty, MarkdownResKey.CodeInlineBackground);
        return element;
    }

    public static Border BindQuoteBlockBorder(this Border element)
    {
        element.SetResourceReference(Border.BorderBrushProperty, MarkdownResKey.QuoteBlockBorder);
        return element;
    }

    public static TextBlock BindTableForeground(this TextBlock element)
    {
        element.SetResourceReference(TextBlock.ForegroundProperty, MarkdownResKey.TableForeground);
        return element;
    }

    public static TextBlock BindTableBackground(this TextBlock element)
    {
        element.SetResourceReference(TextBlock.BackgroundProperty, MarkdownResKey.TableBackground);
        return element;
    }

    public static Border BindTableBackground(this Border element)
    {
        element.SetResourceReference(Border.BackgroundProperty, MarkdownResKey.TableBackground);
        return element;
    }

    public static Border BindTableStripe(this Border element)
    {
        element.SetResourceReference(Border.BackgroundProperty, MarkdownResKey.TableStripe);
        return element;
    }

    public static Border BindTableBorder(this Border element)
    {
        element.SetResourceReference(Border.BorderBrushProperty, MarkdownResKey.TableBorder);
        return element;
    }

    public static Border BindThematicBreak(this Border element)
    {
        element.SetResourceReference(Border.BackgroundProperty, MarkdownResKey.ThematicBreak);
        return element;
    }

    public static WpfDocs.Inline WrapWithContainer(this UIElement element)
    {
        return new WpfDocs.Span()
        {
            BaselineAlignment = BaselineAlignment.Center,
            Inlines =
            {
                new WpfDocs.InlineUIContainer()
                {
                    Child = element
                }
            }
        };
    }
}
