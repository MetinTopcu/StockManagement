using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Basket.Domain.DTOs
{
    public class BasketItemDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string PictureUrl { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal KDV { get; set; }
        public int UnitId { get; set; }
        public int Quantity { get; set; }
    }
}
