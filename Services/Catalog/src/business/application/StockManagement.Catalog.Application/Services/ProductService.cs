using AutoMapper;
using StockManagement.Catalog.ApplicationContracts.ServiceContracts;
using StockManagement.Catalog.Domain.DTOs;
using StockManagement.Catalog.Domain.Entities;
using StockManagement.Catalog.Domain.RepositoryContracts;
using StockManagement.Catalog.Infrastructure;
using StockManagement.Shared.Domain.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Catalog.Application.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork<CatalogDbContext> _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IUnitOfWork<CatalogDbContext> unitOfWork, IMapper mapper)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<object> CreateAsync(CreateProductInputDTO input)
        {
            var cancellationToken = new CancellationToken();
            await _unitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                if(await _productRepository.AnyAsync(x => x.ProductName == input.ProductName))
                {
                    throw new Exception("The product is already exist");
                }
                if(await _productRepository.AnyAsync(x => x.BarkodNo == input.BarkodNo))
                {
                    throw new Exception("The barkod number is already exist");
                }
                var product = _mapper.Map<Product>(input);
                product.CreatedTime = DateTime.Now;

                await _productRepository.InsertOneAsync(product, cancellationToken);

                await _unitOfWork.CommitAsync(cancellationToken);
            }
            catch(Exception)
            {
                await _unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }

            return true;
        }

    }
}
