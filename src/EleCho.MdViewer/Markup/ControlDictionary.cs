using System.Windows.Markup;
using System.Windows;

namespace EleCho.MdViewer.Markup;

[Localizability(LocalizationCategory.Ignore)]
[Ambient]
[UsableDuringInitialization(true)]
public class ControlsDictionary : ResourceDictionary
{
    private const string DictionaryUri = "pack://application:,,,/EleCho.MdViewer;component/MarkdownViewer.xaml";

    public ControlsDictionary()
    {
        Source = new Uri(DictionaryUri, UriKind.Absolute);
    }
}
