using StockManagement.Shared.Domain.Interfaces.Repository;
using StockManagement.User.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.User.Domain.RepositoryContracts
{
    public interface IUserRefreshTokenRepository : IGenericRepository<UserRefreshToken, long>
    {

    }
}
