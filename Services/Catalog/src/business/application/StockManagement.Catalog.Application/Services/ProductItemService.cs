using AutoMapper;
using StockManagement.Catalog.ApplicationContracts.ServiceContracts;
using StockManagement.Catalog.Domain.DTOs;
using StockManagement.Catalog.Domain.Entities;
using StockManagement.Catalog.Domain.RepositoryContracts;
using StockManagement.Catalog.Infrastructure;
using StockManagement.Shared.Domain.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Catalog.Application.Services
{
    public class ProductItemService : IProductItemService
    {
        private readonly IProductItemRepository _productItemRepository;
        private readonly IUnitOfWork<CatalogDbContext> _unitOfWork;
        private readonly IMapper _mapper;

        public ProductItemService(IProductItemRepository productItemRepository, IUnitOfWork<CatalogDbContext> unitOfWork, IMapper mapper)
        {
            _productItemRepository = productItemRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<object> CreateAsync(CreateProductItemInputDTO input)
        {
            var cancellationToken = new CancellationToken();
            await _unitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                var productItem = _mapper.Map<ProductItem>(input);
                productItem.AddedTime = DateTime.Now;
                List<ProductItem> productItems = [];

                for (int i = 0; i < input.Amount; i++)
                {
                    productItems = [productItem];
                }

                await _productItemRepository.InsertManyAsync(productItems, cancellationToken);

                await _unitOfWork.CommitAsync(cancellationToken);
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync(cancellationToken);

                throw;
            }

            return true;
        }
    }
}
