using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.application.Contracts.Product;
using ShopManagement.application.Contracts.ProductCategory;
using ShopManagement.application.Contracts.ProductPicture;
using ShopManagement.application.Contracts.Slide;

namespace ServiceHost.Areas.Administration.Pages.Shop.Slides
{
    public class EditModel : PageModel
    {
        [BindProperty] public EditSlide editSlide { get; set; }
       
        
        private readonly ISlideApplication _slideApplication;

        public EditModel(ISlideApplication slideApplication)
        {
            _slideApplication = slideApplication;
        }

        public void OnGet(long id)
        {
           
            editSlide = _slideApplication.GetDetails(id);
        }
        public JsonResult OnPost()
        {
          var result=_slideApplication.Edit(editSlide);
            
            RedirectToPage("./Index");
            return new JsonResult(result);
        }
        public IActionResult OnGetRemove(long id)
        {
            _slideApplication.Remove(id);
           return RedirectToPage("./Index");
        }
        public IActionResult OnGetRestore(long id)
        {
            _slideApplication.Restore(id);
           return RedirectToPage("./Index");

        }
    }
}
