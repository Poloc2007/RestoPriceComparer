using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;

namespace RestoPriceComparer.Models;

public partial class Supplier : ObservableObject
{
    public int Id { get; set; }

    [ObservableProperty]
    private string _name = string.Empty;

    [ObservableProperty]
    private string? _websiteUrl;

    public List<SupplierItem> Items { get; set; } = new();
}