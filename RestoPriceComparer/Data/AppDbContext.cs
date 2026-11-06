using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestoPriceComparer.Models;

namespace RestoPriceComparer.Data;

public class AppDbContext : DbContext
{
    public DbSet<Supplier> Suppliers => Set<Supplier>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<SupplierItem> SupplierItems => Set<SupplierItem>();
    public DbSet<PriceRecord> PriceRecords => Set<PriceRecord>();

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite("Data Source=restopricecomparer.db");
    }
}