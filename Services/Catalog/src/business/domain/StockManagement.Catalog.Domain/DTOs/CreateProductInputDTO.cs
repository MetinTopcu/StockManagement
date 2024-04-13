using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Catalog.Domain.DTOs
{
    public class CreateProductInputDTO
    {
        public string ProductName { get; set; } = string.Empty;
        public int BarkodNo { get; set; }
        public decimal Cost { get; set; }
        public decimal SalePrice { get; set; }
        public decimal KDV { get; set; }
        public string ProductDescription { get; set; } = string.Empty;
        public int CreatedUserId { get; set; }
        public int UpdatedUserId { get; set; }
        public string Picture { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int UnitId { get; set; }
    }
}
