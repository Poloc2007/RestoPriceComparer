using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestoPriceComparer.Models;

namespace RestoPriceComparer.Services
{
    public interface ISupplierService
    {
        public List<Supplier> GetSuppliers();
        public void AddSupplier(Supplier supplier);
        public void DeleteSupplier(Supplier supplier);
    }
}
