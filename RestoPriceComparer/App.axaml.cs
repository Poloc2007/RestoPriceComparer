using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using RestoPriceComparer.ViewModels;
using RestoPriceComparer.Views;
using Microsoft.Extensions.DependencyInjection;
using RestoPriceComparer.Services;
using RestoPriceComparer.Data;

namespace RestoPriceComparer;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        ServiceProvider serviceProvider = BuildServices();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = serviceProvider.GetRequiredService<MainWindowViewModel>(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    private static ServiceProvider BuildServices()
    {
        ServiceCollection services = new ServiceCollection();
        services.AddSingleton<AppDbContext>();
        services.AddSingleton<ISupplierService, SupplierService>();
        services.AddSingleton<MainWindowViewModel>();
        return services.BuildServiceProvider();
    }
}