using Android.App;
using Android.Content;
using Android.Webkit;
using Hider.Controls;
using Hider.Platforms;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Controls.Platform;

[assembly: ExportRenderer(typeof(WebViewControl), typeof(GenericWebViewRenderer))]
namespace Hider.Platforms;
public class GenericWebViewRenderer : WebViewRenderer
{ 
    Context ctx;

    public GenericWebViewRenderer(Context context) : base(context)
    {
        ctx = context;
    }

    protected override void OnElementChanged(ElementChangedEventArgs<Microsoft.Maui.Controls.WebView> e)
    {
        base.OnElementChanged(e);

        if (Control == null)
            return;
        Control.Settings.JavaScriptEnabled = true;
        Control.SetWebViewClient(new WebViewClient());
        Control.SetWebChromeClient(new MyWebChromeClient());
        Control.SetDownloadListener(new CustomDownloadListener());
    }
}
public class MyWebChromeClient : Android.Webkit.WebChromeClient
{
    public override void OnProgressChanged(Android.Webkit.WebView view, int newProgress)
    {
        WeakReferenceMessenger.Default.Send(new CurrentProgress(newProgress));
    }
}
public class CustomDownloadListener : Java.Lang.Object, IDownloadListener
{
    public void OnDownloadStart(string url, string userAgent, string contentDisposition, string mimetype, long contentLength)
    {
        try
        {
            DownloadManager.Request request = new DownloadManager.Request(Android.Net.Uri.Parse(url));
            request.AllowScanningByMediaScanner();
            request.SetNotificationVisibility(DownloadVisibility.VisibleNotifyCompleted);
            // if this path is not create, we can create it.
            string thmblibrary = FileSystem.AppDataDirectory + "/download";
            if (!Directory.Exists(thmblibrary))
                Directory.CreateDirectory(thmblibrary);
            request.SetDestinationInExternalFilesDir(Android.App.Application.Context, FileSystem.AppDataDirectory, "download");
            DownloadManager dm = (DownloadManager)Android.App.Application.Context.GetSystemService(Android.App.Application.DownloadService);
            dm.Enqueue(request);

        }
        catch (Exception)
        {
            throw;
        }

    }
}