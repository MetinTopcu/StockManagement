using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagement.Shared.Domain.Interfaces;

namespace StockManagement.Shared.Domain.Interfaces.Repository
{
    public interface IGenericCudRepository<T, U> where T : IEntity<U> where U : struct
    {
        Task<T> InsertOneAsync(T entity, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> InsertManyAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
        Task UpdateOneAsync(T entity, CancellationToken cancellationToken = default);
        Task UpdateManyAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
        Task DeleteOneAsync(T entity, CancellationToken cancellationToken = default);
        Task DeleteManyAsync(IEnumerable<T> entities, CancellationToken cancellation = default);
    }
}
