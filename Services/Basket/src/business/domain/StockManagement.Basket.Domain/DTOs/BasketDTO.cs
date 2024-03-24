using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Basket.Domain.DTOs
{
    public class BasketDTO
    {
        public int UserId { get; set; }
        public List<BasketItemDTO>? BasketItems { get; set; }
        public decimal TotalKDV { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
