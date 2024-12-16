using UpggiftMAUI.Views;

namespace UpggiftMAUI
{
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            ServiceProvider = serviceProvider;
            MainPage = ServiceProvider.GetService<AppShell>();
        }
    }
}
