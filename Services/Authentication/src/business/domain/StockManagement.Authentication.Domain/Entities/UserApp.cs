using Microsoft.AspNetCore.Identity;
using StockManagement.Shared.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.User.Domain.Entities
{
    public class UserApp : IdentityUser
    {
        public DateTime CreatedTime { get; set; }
        public Guid CreatedUserId { get; set; }
        public DateTime UpdatedTime { get; set; }
        public Guid UpdatedUserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}
