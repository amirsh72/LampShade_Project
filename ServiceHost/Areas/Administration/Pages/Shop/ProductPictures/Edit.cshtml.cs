using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.application.Contracts.Product;
using ShopManagement.application.Contracts.ProductCategory;
using ShopManagement.application.Contracts.ProductPicture;

namespace ServiceHost.Areas.Administration.Pages.Shop.ProductPictures
{
    public class EditModel : PageModel
    {
        [BindProperty] public EditProductPicture editProductPicture { get; set; }
        public SelectList products;
        
        private readonly IProductApplication _productApplication;
        private readonly IProductPictureApplication _productPictureApplication;

        public EditModel(IProductApplication productApplication,
            IProductPictureApplication productPictureApplication)
        {
            _productApplication = productApplication;
            _productPictureApplication = productPictureApplication;
        }

        

       

        public void OnGet(long id)
        {
            products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
            editProductPicture = _productPictureApplication.GetDetails(id);
        }
        public JsonResult OnPost()
        {
          var result=_productPictureApplication.Edit(editProductPicture);
            
            RedirectToPage("./Index");
            return new JsonResult(result);
        }
        public IActionResult OnGetRemove(long id)
        {
            _productPictureApplication.Remove(id);
           return RedirectToPage("./Index");
        }
        public IActionResult OnGetRestore(long id)
        {
            _productPictureApplication.ReStore(id);
           return RedirectToPage("./Index");

        }
    }
}
