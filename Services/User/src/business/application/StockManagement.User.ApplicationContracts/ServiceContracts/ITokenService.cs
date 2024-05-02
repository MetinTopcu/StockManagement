using StockManagement.User.Domain.Configuration;
using StockManagement.User.Domain.DTOs;
using StockManagement.User.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.User.ApplicationContracts.ServiceContracts
{
    public interface ITokenService
    {
        Task<TokenDTO> CreateTokenAsync(UserApp userApp);
        ClientTokenDTO CreateTokenByClient(Client client);

    }
}
