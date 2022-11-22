
using System.Runtime.CompilerServices;

namespace Hider.Controls;

public class WebViewControl : WebView
{
    public int NavigationPosition
    {
        get => (int)GetValue(NavigationPositionProperty);
        set => SetValue(NavigationPositionProperty, value);
    }


    public static readonly BindableProperty NavigationPositionProperty =
    BindableProperty.Create(nameof(NavigationPosition), typeof(int), typeof(int), propertyChanged: OnPropertyChanging);
    private static void OnPropertyChanging(BindableObject bindable, object oldValue, object newValue)
    {
        throw new NotImplementedException();
    }
}


