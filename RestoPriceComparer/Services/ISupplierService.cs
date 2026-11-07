using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoPriceComparer.Services
{
    public interface ISupplierService
    {
        public List<Models.Supplier> GetSuppliers();
        public void AddSupplier(Models.Supplier supplier);
    }
}
