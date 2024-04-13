﻿using StockManagement.Catalog.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Catalog.ApplicationContracts.ServiceContracts
{
    public interface IProductItemService
    {
        Task<object> CreateAsync(CreateProductItemInputDTO input);

    }
}
