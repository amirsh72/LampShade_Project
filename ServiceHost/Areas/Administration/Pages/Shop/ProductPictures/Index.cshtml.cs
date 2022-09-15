using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Aplication;
using ShopManagement.application.Contracts.Product;
using ShopManagement.application.Contracts.ProductCategory;
using ShopManagement.application.Contracts.ProductPicture;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.Shop.ProductPictures
{
    public class IndexModel : PageModel
    {
        public ProductPictureSearchModel SearchModel;
        public List<ProductPictureViewModel> ProductPictures;
        public SelectList products;

        private readonly IProductApplication _productApplication;
        private readonly IProductPictureApplication _productPictureApplication;

        public IndexModel(IProductApplication productApplication, IProductPictureApplication productPictureApplication )
        {
            _productApplication = productApplication;
            _productPictureApplication = productPictureApplication;
        }

        public void OnGet(ProductPictureSearchModel searchModel)
        {
            products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
            ProductPictures = _productPictureApplication.Search(searchModel);
        }
        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateProduct());
        }
    }
}
