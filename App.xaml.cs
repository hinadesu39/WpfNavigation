using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Net;
using System.Windows;
using WpfNavigation.View;
using WpfNavigation.ViewModel;

namespace WpfNavigation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static new App Current => (App)Application.Current;

        public IServiceProvider Services { get; }

        public App()
        {
            Services = ConfigureServices();
        }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<ViewA>();
            services.AddSingleton<ViewB>();
            services.AddSingleton<ViewC>();
            services.AddSingleton<ViewAViewModel>();
            services.AddSingleton<ViewBViewModel>();
            services.AddSingleton<ViewCViewModel>();
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<NavigationService>();
            return services.BuildServiceProvider();
        }
    }
}
