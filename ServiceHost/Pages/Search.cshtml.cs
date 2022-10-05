using _01_LampShadeQuery.Contracts.Product;
using _01_LampShadeQuery.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace ServiceHost.Pages
{
    public class SearchModel : PageModel
    {
        public string Value;
        private readonly IProductQuery _productQuery;
        public List<ProductQueryModel> Products;

        public SearchModel(IProductQuery productCategoryQuery)
        {
            _productQuery = productCategoryQuery;
        }

        
        public void OnGet(string value)
        {
            Value = value;
            Products = _productQuery.Search(value);
        }
    }
}
