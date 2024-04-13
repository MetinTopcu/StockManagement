using StockManagement.Catalog.Domain.Entities;
using StockManagement.Catalog.Domain.RepositoryContracts;
using StockManagement.Shared.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Catalog.Infrastructure.Repositories
{
    public class ProductItemRepository : GenericRepository<ProductItem, CatalogDbContext, int>, IProductItemRepository
    {
        public ProductItemRepository(CatalogDbContext dbContext) : base(dbContext)
        {
        }
    }
}
