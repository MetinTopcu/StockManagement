using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Catalog.Domain.DTOs
{
    public class CreateProductItemInputDTO
    {
        public DateTime ProductionDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Amount { get; set; }

    }
}
