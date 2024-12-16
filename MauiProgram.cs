using Microsoft.Extensions.Logging;
using UpggiftMAUI.Services;
using UpggiftMAUI.ViewModels;
using UpggiftMAUI.Views;

namespace UpggiftMAUI
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

            builder.Services.AddSingleton<DatabaseService>();
            builder.Services.AddSingleton<IShoppingItemRepository, ShoppingItemRepository>();
            builder.Services.AddSingleton<IShoppingListRepository, ShoppingListRepository>();
            builder.Services.AddSingleton<IAppState, AppState>();
            builder.Services.AddSingleton<AppShell>();

            builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<ShoppingListsPageViewModel>();
            builder.Services.AddTransient<ShoppingListsPage>();
            builder.Services.AddTransient<ShoppingListDetailsPage>();
            builder.Services.AddTransient<ShoppingListDetailsViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
