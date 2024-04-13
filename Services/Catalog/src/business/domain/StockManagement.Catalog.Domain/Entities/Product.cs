using StockManagement.Shared.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Catalog.Domain.Entities
{
    public class Product : IAggregateRoot, IEntity<int>
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int BarkodNo { get; set; }
        public double Amount { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal Cost { get; set; }
        public decimal SalePrice { get; set; }
        public decimal KDV { get; set; }
        public string ProductDescription { get; set; } = string.Empty;
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
        public int CreatedUserId { get; set; }
        public int UpdatedUserId { get; set; }
        public string Picture { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public int BrandId { get; set; }
        public Brand? Brand { get; set; }
        public int UnitId { get; set; }
        public Unit? Unit { get; set; }


    }
}
