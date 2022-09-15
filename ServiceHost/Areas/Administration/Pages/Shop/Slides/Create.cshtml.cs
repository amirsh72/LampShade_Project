using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Aplication;
using ShopManagement.application.Contracts.Product;
using ShopManagement.application.Contracts.ProductCategory;
using ShopManagement.application.Contracts.ProductPicture;
using ShopManagement.application.Contracts.Slide;

namespace ServiceHost.Areas.Administration.Pages.Shop.Slides
{
    public class CreateModel : PageModel
    {
        
        public CreateSlide createSlide{ get; set; }

        private readonly ISlideApplication _slideApplication;

        public CreateModel(ISlideApplication slideApplication)
        {
            _slideApplication = slideApplication;
        }

        public void OnGet()
        {
          
        }
        public JsonResult OnPost(CreateSlide command)
        {
            var result = _slideApplication.Create(command);
            RedirectToPage("./Index");
            return new JsonResult(result);
        }
    }
}
