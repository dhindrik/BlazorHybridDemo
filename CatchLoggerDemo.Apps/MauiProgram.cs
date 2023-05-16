using CatchLoggerDemo.Core.Helpers;
using CatchLoggerDemo.Web.Services;
using Microsoft.Extensions.Logging;

namespace CatchLoggerDemo.Apps;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<RegisterPage>();

        builder.Services.AddSingleton<IPlatformInfoProvider, AppPlatformProvider>();


        builder.Services.AddSingleton<ICatchService, CatchService>();

		builder.Services.AddSingleton<IFilePathProvider, AppFilePathProvider>();

        return builder.Build();
	}
}

