using StockManagement.Shared.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Order.Domain.Entities
{
    public class Order : IEntity<int>
    {
        public int Id { get; set; }
        public List<OrderItem>? OrderItems { get; set; }
        public decimal TotalKDV { get; set; }
        public decimal TotalPrice { get; set; }
        public int CustomerId { get; set; }
        public string CustomerNameSurname { get; set; } = string.Empty;
        public string CustomerPhone { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public DateTime CreatedTime { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime UpdateTime { get; set; }
        public int UpdateUserId { get; set; }
    }
}
