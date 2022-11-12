
namespace Hider.Views;

public partial class FingerprintPage : ContentPage
{
	public FingerprintPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var request = new AuthenticationRequestConfiguration("Prove you have fingers!", "Because without it you can't have access");
        var result = await CrossFingerprint.Current.AuthenticateAsync(request);
        if (result.Authenticated)
        {
            App.Current.MainPage = new MainPage();
        }
        else
        {
            // not allowed to do secret stuff :(
        }
    }
}