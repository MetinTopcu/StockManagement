using StockManagement.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.User.Domain.Entities
{
    public class User : IEntity<int>
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime UpdatedTime { get; set; }
        public int UpdatedUserId { get; set; }
        public string NameSurname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

    }
}
