using CommunityToolkit.Maui;
using Datez.Db;
using Datez.Models;
using Datez.Pages;
using Datez.ViewModels;

using Microsoft.Extensions.Logging;

namespace Datez;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();

        builder.Services.AddSingleton<IDatabase<Event>, EventDatabase>();

        builder.Services.AddTransient<NewEventPageViewModel>();
        builder.Services.AddTransient<NewEventPage>();

        builder.Services.AddSingleton<MainPageViewModel>();
        builder.Services.AddSingleton<MainPage>();

        builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("Lato-Regular.ttf", "LatoRegular");
				fonts.AddFont("Lato-Semibold.ttf", "LatoSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
