using StockManagement.Shared.Domain.Interfaces.Repository;
using StockManagement.Shared.Domain.Services;
using StockManagement.User.Domain.Entities;
using StockManagement.User.Domain.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.User.Infrastructure.Repositories
{
    public class UserRefreshTokenRepository : GenericRepository<UserRefreshToken, UserDbContext, long>, IUserRefreshTokenRepository
    {
        public UserRefreshTokenRepository(UserDbContext dbContext) : base(dbContext)
        {
        }
    }
}
