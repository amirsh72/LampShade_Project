using _0_Framework.Infrastructure;
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
                        new PermissionDto(ShopPermissions.ListProducts,"ListProduct"),
                        new PermissionDto(ShopPermissions.SearchProducts,"SearchProduct"),
                        new PermissionDto(ShopPermissions.CreateProduct,"CreateProduct"),
                        new PermissionDto(ShopPermissions.EditProduct,"EditProduct"),
                    }
                },
                {
                    "ProductCategory",new List<PermissionDto>
                    {
                        new PermissionDto(ShopPermissions.SearchProductCaegories,"SearchProductCategories"),
                        new PermissionDto(ShopPermissions.ListProductCaegories,"ListProductCategories"),
                        new PermissionDto(ShopPermissions.CreateProductCaegory,"CreateProductCategory"),
                        new PermissionDto(ShopPermissions.EditProductCaegory,"EditProductCategory"),
                    }
                }
            };
        }
    }
}
