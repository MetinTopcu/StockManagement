using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.User.Domain.DTOs
{
    public class TokenDTO
    {
        public string AccessToken { get; set; } = string.Empty; // 3 parçadan oluşan string token
        public DateTime AccessTokenExpiration { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime RefrestTokenExpiration { get; set; }
    }
}
