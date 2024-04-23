using StockManagement.User.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.User.ApplicationContracts.ServiceContracts
{
    public interface IAuthenticationService
    {
        Task<TokenDTO> CreateTokenAsync(LoginDTO loginDto);
        Task<TokenDTO> CreateTokenByRefreshToken(string refreshToken);
        Task RevokeRefreshToken(string refreshToken);
        ClientTokenDTO CreateTokenByClient(ClientLoginDTO clientLoginDto);
    }
}
