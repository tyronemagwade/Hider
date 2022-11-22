using System.ComponentModel;

namespace Hider.Views;

public partial class BrowserPage : ContentPage
{

    public BrowserPage()
	{
		InitializeComponent();
      
	   
	}

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        if (web.CanGoBack) web.GoBack();
    }
    
    private void ImageButton_Clicked_1(object sender, EventArgs e)
    {
        if (web.CanGoForward) web.GoForward();
    }

    private async void ImageButton_Clicked_2(object sender, EventArgs e)
    {
        await reload.RotateTo(360*3);
        web.Reload();
        await reload.RotateTo(0);
    }

    private void Entry_Completed(object sender, EventArgs e)
    {

    }
}