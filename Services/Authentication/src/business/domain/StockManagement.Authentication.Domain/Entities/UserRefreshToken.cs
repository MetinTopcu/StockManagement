using StockManagement.Shared.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.User.Domain.Entities
{
    public class UserRefreshToken : IEntity<long>
    {
        public long Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public DateTime Expiration { get; set; }
    }
}
