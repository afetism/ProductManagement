using ProductManagement.Command;
using ProductManagement.Data;
using ProductManagement.Helpers;
using ProductManagement.Models;
using ProductManagement.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.ViewModels
{
    public class EditProductViewModel:NotifyPropertyChanged
    {

        private Product productForEdit;
        private Product copyProductForEdit;
        private string id;

        public Product ProductForEdit { get => productForEdit; set { productForEdit = value; OnPropertyChanged(); } }
        public Product CopyProductForEdit { get => copyProductForEdit; set { copyProductForEdit = value; OnPropertyChanged(); } }

        public RelayCommand EditCommand { get; }
        public RelayCommand CancelCommand { get; }
        public AppDbContext DbContext { get; set; }


        public string Id { get; set; }
        public EditProductViewModel(AppDbContext dbContext)
        {
            var MainView = App.Current.MainWindow.DataContext as AddProductViewModel;

            DbContext = dbContext;

            CancelCommand = new RelayCommand(Cancel);
            EditCommand = new RelayCommand(Save);
        }

        private void Cancel(object? obj)
        {
            var mainViewModel = App.Current.MainWindow.DataContext as MainViewModel;
            if (mainViewModel != null)
            {
                mainViewModel.CurrentView = App.Container.GetInstance<AllProductsView>();
                mainViewModel.CurrentView.DataContext = App.Container.GetInstance<AllProductsViewModel>();

            }
        }

        private void Save(object? id)
        {
            ProductForEdit.SetValue(CopyProductForEdit);
            DbContext.UpdateProduct(ProductForEdit);
            var mainViewModel = App.Current.MainWindow.DataContext as MainViewModel;
            if (mainViewModel != null)
            {
                mainViewModel.CurrentView = App.Container.GetInstance<AllProductsView>();
                mainViewModel.CurrentView.DataContext = App.Container.GetInstance<AllProductsViewModel>();

            }
        }

       
    }


}
