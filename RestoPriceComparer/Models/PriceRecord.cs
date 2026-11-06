using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoPriceComparer.Models
{
    public class PriceRecord
    {
        public int Id { get; set; }
        public int SupplierItemId { get; set; }
        public SupplierItem? SupplierItem { get; set; }
        public decimal Price { get; set; }
        public DateTime RecordedAt { get; set; }
    }
}
