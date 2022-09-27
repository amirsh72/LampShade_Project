﻿using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.application.Contracts.Product
{
    public interface IProductApplication
    {
        OperationResult Create(CreateProduct command);
        OperationResult Edit(EditProduct command);     
        EditProduct GetDetails(long id);
        List<ProductViewModel> Search(ProductSearchModel searchmodel);
        List<ProductViewModel> GetProducts();
      
    }
}
