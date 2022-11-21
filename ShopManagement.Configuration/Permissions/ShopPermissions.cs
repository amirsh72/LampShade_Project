using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Configuration.Permissions
{
    public static class ShopPermissions
    {
        //product
        public const int ListProducts = 10;
        public const int SearchProducts = 11;
        public const int CreateProduct = 12;
        public const int EditProduct = 13;

        //ProductCategory
        public const int ListProductCaegories = 20;
        public const int SearchProductCaegories = 21;
        public const int CreateProductCaegory = 22;
        public const int EditProductCaegory = 23;
    }
}
