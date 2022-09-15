using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.application.Contracts.Product;
using ShopManagement.application.Contracts.ProductCategory;

namespace ServiceHost.Areas.Administration.Pages.Shop.Products
{
    public class CreateModel : PageModel
    {
        public SelectList productcategories;
        public CreateProduct CreateProduct { get; set; }
        private readonly IProductApplication _productApplication;
        private readonly IProductCategoryApplication _productCategoryApplication;

        public CreateModel(IProductApplication productApplication,
            IProductCategoryApplication productCategoryApplication)
        {
            _productApplication = productApplication;
            _productCategoryApplication = productCategoryApplication;
        }

        public void OnGet()
        {
            productcategories = new SelectList(_productCategoryApplication.GetProductCategories(), "Id", "Name");
        }
        public JsonResult OnPost(CreateProduct command)
        {
            var result = _productApplication.Create(command);
            RedirectToPage("./Index");
            return new JsonResult(result);
        }
    }
}
