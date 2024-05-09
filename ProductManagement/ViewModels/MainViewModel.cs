using ProductManagement.Command;
using ProductManagement.Helpers;
using ProductManagement.Views;
using System.Windows.Controls;
using SimpleInjector;
using ProductManagement.Data;

namespace ProductManagement.ViewModels
{
    public class MainViewModel: NotifyPropertyChanged
    {
        private Page currentView;
        public Page CurrentView { get => currentView; set { currentView=value;
                                                            OnPropertyChanged(); } }


        public RelayCommand AllProductsCommand {  get; set; }
        public RelayCommand AddCommand { get; set; }

        public AppDbContext DbContext { get; private set; }

        public MainViewModel(AppDbContext dbContext)
        {
            DbContext = dbContext;
            AllProductsCommand= new RelayCommand(AllProducts);
            AddCommand=new RelayCommand(Add);
            CurrentView =App.Container.GetInstance<AllProductsView>();
            CurrentView.DataContext=App.Container.GetInstance<AllProductsViewModel>();
           
        }

        public void AllProducts(object? obj)
        {
            CurrentView=App.Container.GetInstance<AllProductsView>();
            CurrentView.DataContext=App.Container.GetInstance<AllProductsViewModel>();
        }
        public void Add(object? parameter)
        {
            CurrentView = App.Container.GetInstance<AddProductView>();
            CurrentView.DataContext = App.Container.GetInstance<AddProductViewModel>();
        }
    }
}
