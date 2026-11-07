using CommunityToolkit.Mvvm.ComponentModel;
using RestoPriceComparer.Models;
using RestoPriceComparer.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RestoPriceComparer.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _greeting = string.Empty;
    private readonly ISupplierService _supplierService;
    [ObservableProperty]
    private ObservableCollection<Supplier> _suppliers = new ObservableCollection<Supplier>();

    public MainWindowViewModel(ISupplierService supplierService)
    {
        _supplierService = supplierService;
        LoadTestData();
    }

    public void LoadTestData()
    {
        List<Supplier> suppliers = _supplierService.GetSuppliers();

        if (suppliers.Count == 0)
        {
            Supplier supplier1 = new Supplier { Name = "Supplier 1", WebsiteUrl = "https://supplier1.com" };
            Supplier supplier2 = new Supplier { Name = "Supplier 2", WebsiteUrl = "https://supplier2.com" };
            _supplierService.AddSupplier(supplier1);
            _supplierService.AddSupplier(supplier2);
            suppliers = _supplierService.GetSuppliers();
        }
        
        foreach (Supplier supplier in suppliers) {
            Suppliers.Add(supplier);
        }

        Greeting = $"{suppliers.Count} fournisseurs en base";
    }
}
