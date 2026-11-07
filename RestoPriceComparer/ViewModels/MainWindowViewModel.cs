using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RestoPriceComparer.Models;
using RestoPriceComparer.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RestoPriceComparer.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _greeting = string.Empty;
    [ObservableProperty]
    private ObservableCollection<Supplier> _suppliers = new ObservableCollection<Supplier>();
    [ObservableProperty]
    private string _newSupplierName = string.Empty;
    [ObservableProperty]
    private string? _newSupplierWebsiteUrl;
    [ObservableProperty]
    private Supplier? _editingSupplier;
    private readonly ISupplierService _supplierService;

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

    [RelayCommand]
    private void AddSupplier()
    {
        if (!string.IsNullOrWhiteSpace(NewSupplierName))
        {
            Supplier newSupplier = new Supplier
            {
                Name = NewSupplierName.Trim(),
                WebsiteUrl = string.IsNullOrWhiteSpace(NewSupplierWebsiteUrl) ? null : NewSupplierWebsiteUrl.Trim()
            };
            _supplierService.AddSupplier(newSupplier);
            Suppliers.Add(newSupplier);
            NewSupplierName = string.Empty;
            NewSupplierWebsiteUrl = null;
            Greeting = $"{Suppliers.Count} fournisseurs en base";
        }
    }

    [RelayCommand]
    public void StartEdit(Supplier supplier)
    {
        if (supplier != null)
        {
            EditingSupplier = supplier;
            NewSupplierName = supplier.Name;
            NewSupplierWebsiteUrl = supplier.WebsiteUrl;
        }
    }

    [RelayCommand]
    private void SaveSupplier()
    {
        if (EditingSupplier != null)
        {
            if (!string.IsNullOrWhiteSpace(NewSupplierName))
            {
                EditingSupplier.Name = NewSupplierName.Trim();
                EditingSupplier.WebsiteUrl = string.IsNullOrWhiteSpace(NewSupplierWebsiteUrl) ? null : NewSupplierWebsiteUrl.Trim();
                _supplierService.UpdateSupplier(EditingSupplier);
                EditingSupplier = null;
                NewSupplierName = string.Empty;
                NewSupplierWebsiteUrl = null;
            }
        }
        else
        {
            AddSupplier();
        }
    }
    
    [RelayCommand]
    private void CancelEdit()
    {
        EditingSupplier = null;
        NewSupplierName = string.Empty;
        NewSupplierWebsiteUrl = null;
    }

    [RelayCommand]
    private void DeleteSupplier(Supplier supplier)
    {
        if (supplier == EditingSupplier)
        {
            CancelEdit();
        }
        _supplierService.DeleteSupplier(supplier);
        Suppliers.Remove(supplier);
        Greeting = $"{Suppliers.Count} fournisseurs en base";
    }
}
