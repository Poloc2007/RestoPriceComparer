using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using RestoPriceComparer.Data;
using RestoPriceComparer.Models;
using System.Linq;

namespace RestoPriceComparer.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _greeting = string.Empty;

    public MainWindowViewModel()
    {
        LoadTestData();
    }

    public void LoadTestData()
    {
        using AppDbContext context = new AppDbContext();
        context.Database.Migrate();

        if (!context.Suppliers.Any())
        {
            Supplier supplier1 = new Supplier { Name = "Supplier 1", WebsiteUrl = "https://supplier1.com" };
            Supplier supplier2 = new Supplier { Name = "Supplier 2", WebsiteUrl = "https://supplier2.com" };
            context.Suppliers.AddRange(supplier1, supplier2);
            context.SaveChanges();
        }
        Greeting = $"{context.Suppliers.Count()} fournisseurs en base";
    }
}
