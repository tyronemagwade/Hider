

namespace Hider.ViewModels;

public partial class BrowserPageModel : ObservableObject
{
    [ObservableProperty] WebView web;
    [ObservableProperty] string searchtext;
    [RelayCommand] void DownloadVieo()
    {


    }
    public bool IsNotbusy
    {
        get => MyProgress == 1 ? false : true;

    }

    [ObservableProperty][NotifyPropertyChangedFor(nameof(IsNotbusy))] int myProgress;


    [RelayCommand] void Search()
    {
        string pattern = @"(http|ftp|https):\/\/([\w_-]+(?:(?:\.[\w_-]+)+))([\w.,@?^=%&:\/~+#-]*[\w@?^=%&\/~+#-])";
        // if (Regex.IsMatch(Searchtext, pattern))


    }
    public BrowserPageModel()
    {
        Searchtext = "https://www.google.com";
        MyProgress = 0;
        WeakReferenceMessenger.Default.Register<CurrentProgress>(this, (s, e) =>
        {
            MyProgress = e.Value / 100;

        });
    }
    [RelayCommand] async void GoBack()
    {
        await App.Current.MainPage.Navigation.PopAsync();
    }
    [RelayCommand] async void GoDownloadsPage()
    {
        await App.Current.MainPage.Navigation.PushAsync(new DownloadsPage());
    }

}

