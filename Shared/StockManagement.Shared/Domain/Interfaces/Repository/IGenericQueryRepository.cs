using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using StockManagement.Shared.Domain.Interfaces;

namespace StockManagement.Shared.Domain.Interfaces.Repository
{
    public interface IGenericQueryRepository<T, U> where T : IEntity<U> where U : struct
    {
        Task<IQueryable<T>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IQueryable<T>> WhereAsync(Expression<Func<T, bool>> selector, CancellationToken cancellationToken = default);
        Task<T> GetByIdAsync(U id, CancellationToken cancellationToken = default);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> selector, CancellationToken cancellationToken = default);
        Task<T> CountAsync(Expression<Func<T, bool>> selector, CancellationToken cancellationToken = default);
        Task<bool> AnyAsync(Expression<Func<T, bool>> selector, CancellationToken cancellationToken = default);
    }
}
