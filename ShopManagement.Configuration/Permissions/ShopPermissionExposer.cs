﻿using _0_Framework.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Configuration.Permissions
{
    public class ShopPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>
            {
                {
                    "Product",new List<PermissionDto>
                    {
                        new PermissionDto(10,"ListProduct"),
                        new PermissionDto(11,"SearchProduct"),
                        new PermissionDto(12,"CreateProduct"),
                        new PermissionDto(13,"EditProduct"),
                    }
                },
                {
                    "ProductCategory",new List<PermissionDto>
                    {
                        new PermissionDto(20,"SearchProductCategories"),
                        new PermissionDto(21,"ListProductCategories"),
                        new PermissionDto(22,"CreateProductCategory"),
                        new PermissionDto(23,"EditProductCategory"),
                    }
                }
            };
        }
    }
}
