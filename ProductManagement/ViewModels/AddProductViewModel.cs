using Microsoft.Win32;
using OfficeOpenXml;
using ProductManagement.Command;
using ProductManagement.Data;
using ProductManagement.Helpers;
using ProductManagement.Models;
using System.ComponentModel;
using System.IO;
using System.Windows;

namespace ProductManagement.ViewModels;


public class AddProductViewModel: NotifyPropertyChanged
{
    private Product product;

    public Product Product { get => product; set { product = value; OnPropertyChanged(); } }

    public RelayCommand SaveCommand { get; set; }
    public RelayCommand CancelCommand { get; set; }

    public RelayCommand LoadCommand { get; set; }
    public AppDbContext DbContext { get; set; }

    public AddProductViewModel(AppDbContext dbContext)
    {
        SaveCommand = new RelayCommand(Save);
        CancelCommand = new RelayCommand(Cansel);
        LoadCommand=new RelayCommand(Load);
        Product = new();
        DbContext = dbContext;
    }

    private void Load(object? obj)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";
        openFileDialog.Title = "Select an Excel File";

        if (openFileDialog.ShowDialog() == true)
        {
            FileInfo fileInfo = new FileInfo(openFileDialog.FileName);

            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();
                if (worksheet != null)
                {
                    int rowCount = worksheet.Dimension.Rows;
                    int colCount = worksheet.Dimension.Columns;

                    for (int row = 2; row <= rowCount; row++)
                    {
                        Product newProduct = new Product
                        {
                            Name = worksheet.Cells[row, 1].Value?.ToString() ?? "",
                            Price = double.Parse(worksheet.Cells[row, 2].Value?.ToString() ?? "0"),
                            Quantity = int.Parse(worksheet.Cells[row, 3].Value?.ToString() ?? "0")
                        };
                        
                        DbContext.Products.Add(newProduct);
                    }
                }
            }
        }
    }
    private void Cansel(object? obj)
    {
        throw new NotImplementedException();
    }

    private void Save(object? obj)
    {
        DbContext.AddProduct(Product);
        Product = new();
    }
}
