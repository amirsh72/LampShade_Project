using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.application.Contracts.ProductCategory;

namespace ServiceHost.Areas.Administration.Pages.Shop.ProductCategories
{
    public class CreateModel : PageModel
    {
        public CreateProductCategory CreateProductCategory { get; set; }
        private readonly IProductCategoryApplication _productCategoryApplication;

        public CreateModel(IProductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }

        public void OnGet()
        {
            
        }
        public JsonResult OnPost(CreateProductCategory command)
        {
         var result= _productCategoryApplication.Create(command);
             RedirectToPage("./Index");
            return new JsonResult(result);
        }
    }
}
