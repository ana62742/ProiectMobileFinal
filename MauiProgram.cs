using ProiectMobileFinal.Views;
using ProiectMobileFinal.ViewModels;
using ProiectMobileFinal.Services;

namespace ProiectMobileFinal;

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
        //Services
        builder.Services.AddSingleton<IConcertService, ConcertService>();


        //Views
        builder.Services.AddSingleton<ConcertListPage>();
        builder.Services.AddSingleton<AddUpdateConcert>();

        //View Models

        builder.Services.AddSingleton<ConcertListPageViewModel>();
        builder.Services.AddSingleton<AddUpdateConcertViewModel>();


        return builder.Build();
	}
}
