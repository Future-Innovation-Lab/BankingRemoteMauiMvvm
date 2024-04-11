using BankingRemoteMaui.Interfaces;
using BankingRemoteMaui.Services;
using BankingRemoteMaui.ViewModels;
using Microsoft.Extensions.Logging;
using TodoREST.Services;
using BankingRemoteMaui.Config;

namespace BankingRemoteMaui
{
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

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.RegisterServices()
             .RegisterViewModels()
             .RegisterViews();

            return builder.Build();
        }

        public static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<IHttpsClientHandlerService, HttpsClientHandlerService>();
            mauiAppBuilder.Services.AddSingleton<IBankingService, BankingService>();

            mauiAppBuilder.Services.AddTransient<ISettings, Settings>();
            mauiAppBuilder.Services.AddTransient<IAlertDialogService, DefaultMauiAlertDialogService>();

            // More services registered here.

            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<MainViewModel>();

            // More view-models registered here.

            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<MainView>();

            // More views registered here.

            return mauiAppBuilder;
        }
    }
}
