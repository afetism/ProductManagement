﻿using ProductManagement.Command;
using ProductManagement.Data;
using ProductManagement.Models;
using ProductManagement.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.ViewModels
{
    public class AllProductsViewModel
    {
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand EditCommand { get; set; }

        public AllProductsViewModel(AppDbContext dbContext)
        {
            DbContext = dbContext;
            DeleteCommand = new RelayCommand(DeleteProduct);
            EditCommand = new RelayCommand(EditProduct);


        }

        private void EditProduct(object? id)
        {
            var MainView = App.Current.MainWindow.DataContext as MainViewModel;
            if (MainView != null)
            {
                MainView.CurrentView = App.Container.GetInstance<EditProductView>();
                MainView.CurrentView.DataContext = App.Container.GetInstance<EditProductViewModel>();
                var EditViewModel = MainView.CurrentView.DataContext as EditProductViewModel;
                EditViewModel.ProductForEdit = DbContext.Products.FirstOrDefault(s => s.Id == id);
                EditViewModel.CopyProductForEdit = EditViewModel.ProductForEdit?.Clone() as Product;
            }
        }

        private void DeleteProduct(object? id)
        {
            DbContext.RemoveProduct(id!.ToString()!);
        }

        public AppDbContext DbContext { get; set; }


    }
}
