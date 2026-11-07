using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestoPriceComparer.Data;
using RestoPriceComparer.Models;

namespace RestoPriceComparer.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly AppDbContext _context;
        public SupplierService(AppDbContext context)
        {
            _context = context;
            context.Database.Migrate();
        }
        public List<Supplier> GetSuppliers()
        {
            return _context.Suppliers.ToList();
        }
        public void AddSupplier(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
    }
    }
}
