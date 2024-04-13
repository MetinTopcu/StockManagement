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
        void UpdateOne(T entity, CancellationToken cancellationToken = default);
        void UpdateMany(IEnumerable<T> entities, CancellationToken cancellationToken = default);
        void DeleteOne(T entity, CancellationToken cancellationToken = default);
        void DeleteMany(IEnumerable<T> entities, CancellationToken cancellation = default);
    }
}
