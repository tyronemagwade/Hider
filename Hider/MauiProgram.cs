using CommunityToolkit.Maui;
using Hider.Controls;
#if ANDROID || IOS
using Hider.Platforms;
#endif
using Microsoft.Maui.Controls.Compatibility.Hosting;

namespace Hider;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()

#if ANDROID || IOS
			.UseLocalNotification()
#endif
			.UseMauiCompatibility()
			.ConfigureMauiHandlers(hander =>
			{
#if ANDROID
				hander.AddCompatibilityRenderer<WebViewControl, GenericWebViewRenderer>();
#endif

			})
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if ANDROID
        CrossFingerprint.SetCurrentActivityResolver(() => Platform.CurrentActivity);
#endif

#if DEBUG
        builder.Logging.AddDebug();
#endif
        builder.UseMauiCommunityToolkit();
        return builder.Build();
	}
}
