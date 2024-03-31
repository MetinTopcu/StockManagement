using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagement.Shared.Domain.Interfaces;

namespace StockManagement.Shared.Domain.Interfaces.Repository
{
    public interface IGenericRepository<T, U> : IGenericQueryRepository<T, U>, IGenericCudRepository<T, U> where T : IEntity<U> where U : struct
    {
    }
}
