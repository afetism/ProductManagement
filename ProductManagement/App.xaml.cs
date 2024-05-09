
using System.Configuration;
using System.Data;
using System.Windows;
using ProductManagement.Data;
using ProductManagement.ViewModels;
using ProductManagement.Views;
using SimpleInjector;

namespace ProductManagement;
public partial class App : Application
{
    public static Container Container { get; set; } = new();
    public App()
    {
        Container.RegisterSingleton<AppDbContext>();
        AddViews();
        AddViewModels();
    }
    
    

    private void AddViewModels()
    {
        Container.RegisterSingleton<AddProductViewModel>();
        Container.RegisterSingleton<AllProductsViewModel>();
        Container.RegisterSingleton<MainViewModel>();
    }

    private void AddViews()
    {
        Container.RegisterSingleton<AddProductView>();
        Container.RegisterSingleton<AllProductsView>();
        Container.RegisterSingleton<MainView>();
    }
    protected override void OnStartup(StartupEventArgs e)
    {
        var mainView = Container.GetInstance<MainView>();
        mainView.DataContext = Container.GetInstance<MainViewModel>();
        mainView.Show();
        base.OnStartup(e);
    }
}

