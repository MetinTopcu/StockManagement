using Microsoft.EntityFrameworkCore;
using StockManagement.Shared.Domain.Interfaces.Repository;
using StockManagement.Shared.Domain.Services;
using StockManagement.User.Domain.Entities;
using StockManagement.User.Domain.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StockManagement.User.Infrastructure.Repositories
{
    public class UserRefreshTokenRepository<TDbContext> : GenericRepository<UserRefreshToken, TDbContext, Guid>, IUserRefreshTokenRepository where TDbContext : DbContext
    {
        public UserRefreshTokenRepository(TDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<UserRefreshToken?> GetRefreshTokenAsync(string refreshToken, CancellationToken cancellationToken=default)
        {
            return await Where(x => x.Code == refreshToken).SingleOrDefaultAsync(cancellationToken);

        }
        public async Task<UserRefreshToken?> GetRefreshTokenAsyncByUser(UserApp user, CancellationToken cancellationToken = default)
        {
            return await Where(x => x.Id.ToString() == user.Id).SingleOrDefaultAsync(cancellationToken);

        }


    }
}
