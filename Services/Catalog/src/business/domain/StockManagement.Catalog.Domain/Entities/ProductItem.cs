using StockManagement.Shared.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Catalog.Domain.Entities
{
    public class ProductItem : IEntity<int>
    {
        public int Id { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime AddedTime { get; set; }
        public int AddedUserId { get; set; }


    }
}
