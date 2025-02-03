using System.Windows.Markup;
using System.Windows;
using EleCho.MdViewer.ColorModes;

namespace EleCho.MdViewer.Markup;

[Localizability(LocalizationCategory.Ignore)]
[Ambient]
[UsableDuringInitialization(true)]
public class ThemeDictionary : ResourceDictionary
{
    private ColorMode _colorMode = ColorMode.Light;
    public ColorMode ColorMode { 
        get => _colorMode;
        set {
            _colorMode = value;
            UpdateColorMode();
        } 
    }
    public ThemeDictionary()
    {
        UpdateColorMode();
    }
    private void UpdateColorMode()
    {
        Source = new Uri($"pack://application:,,,/EleCho.MdViewer;component/ColorModes/{_colorMode}Mode.xaml", UriKind.Absolute);
    }
}
