using _0_Framework.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.application.Contracts.Product;
using ShopManagement.application.Contracts.ProductCategory;
using ShopManagement.Configuration.Permissions;

namespace ServiceHost.Areas.Administration.Pages.Shop.Products
{
    public class EditModel : PageModel
    {
        [BindProperty] public EditProduct editProduct { get; set; }
        public SelectList productcategories;
        
        private readonly IProductApplication _productApplication;
        private readonly IProductCategoryApplication _productCategoryApplication;

        public EditModel(IProductApplication productApplication,
            IProductCategoryApplication productCategoryApplication)
        {
            _productApplication = productApplication;
            _productCategoryApplication = productCategoryApplication;
        }

        

       

        public void OnGet(long id)
        {
            productcategories = new SelectList(_productCategoryApplication.GetProductCategories(), "Id", "Name");
            editProduct = _productApplication.GetDetails(id);
        }

        [NeedsPermissionsAttribute(ShopPermissions.EditProduct)]
        public JsonResult OnPost()
        {
          var result=_productApplication.Edit(editProduct);
            
            RedirectToPage("./Index");
            return new JsonResult(result);
        }
      
    }
}
