using StockManagement.Catalog.Domain.Entities;
using StockManagement.Shared.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Catalog.Domain.RepositoryContracts
{
    public interface IProductRepository : IGenericRepository<Product, int>
    {

    }
}
