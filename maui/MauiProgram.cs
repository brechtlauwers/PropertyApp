using Microsoft.Extensions.Logging;
using maui.Services;
using maui.ViewModels;

namespace maui;

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
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<IDataService, DataService>();

		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddTransient<PropertyViewPage>();
		builder.Services.AddTransient<AddPropertyPage>();

		builder.Services.AddTransient<MainPageVM>();
		builder.Services.AddTransient<PropertyDetailVM>();
		builder.Services.AddTransient<AddPropertyVM>();


#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
