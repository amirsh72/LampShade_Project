using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.application.Contracts.ProductCategory;

namespace ServiceHost.Areas.Administration.Pages.Shop.ProductCategories
{
    public class EditModel : PageModel
    {
        [BindProperty] public EditProductCategory editProductCategory { get; set; }
        private readonly IProductCategoryApplication _productCategoryApplication;

        public EditModel(IProductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }

        public void OnGet(long id)
        {
            editProductCategory = _productCategoryApplication.GetDetails(id);
        }
        public JsonResult OnPost()
        {
          var result=_productCategoryApplication.Edit(editProductCategory);
            
            RedirectToPage("./Index");
            return new JsonResult(result);
        }
    }
}
