using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.application.Contracts.Product;
using ShopManagement.application.Contracts.ProductCategory;
using ShopManagement.application.Contracts.ProductPicture;

namespace ServiceHost.Areas.Administration.Pages.Shop.ProductPictures
{
    public class CreateModel : PageModel
    {
        public SelectList products;
        public CreateProductPicture CreateProductPicture { get; set; }
        private readonly IProductApplication _productApplication;
        private readonly IProductPictureApplication _productPictureApplication;

        public CreateModel(IProductApplication productApplication,
            IProductPictureApplication productPictureApplication)
        {
            _productApplication = productApplication;
            _productPictureApplication = productPictureApplication;
        }

        public void OnGet()
        {
            products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
        }
        public JsonResult OnPost(CreateProductPicture command)
        {
            var result = _productPictureApplication.Create(command);
            RedirectToPage("./Index");
            return new JsonResult(result);
        }
    }
}
