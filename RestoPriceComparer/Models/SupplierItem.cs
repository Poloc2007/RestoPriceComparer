using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace RestoPriceComparer.Models
{
    public class SupplierItem
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public Supplier? Supplier { get; set; }
        public int? ProductId { get; set; }
        public Product? Product { get; set; }
        public string Label { get; set; } = string.Empty;
        public int PackCount { get; set; }
        public int UnitQuantity { get; set; }
        public Unit Unit { get; set; }
        public string? SourceUrl { get; set; }
        public List<PriceRecord> Prices { get; set; } = new();

    }
}
