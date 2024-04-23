using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.User.Domain.Configuration
{
    public class CustomTokenOptions
    {
        public List<string>? Audience { get; set; }
        public string Issuer { get; set; } = string.Empty; 
        public int AccessTokenExpiration { get; set; }
        public int RefreshTokenExpiration { get; set; }
        public string SecurityKey { get; set; } = string.Empty;
    }
}
