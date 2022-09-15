using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Aplication;
using ShopManagement.application.Contracts.Product;
using ShopManagement.application.Contracts.ProductCategory;
using ShopManagement.application.Contracts.ProductPicture;
using ShopManagement.application.Contracts.Slide;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.Shop.Slides
{
    public class IndexModel : PageModel
    {
        
        public List<SlideViewModel> slides;
        

        private readonly ISlideApplication _slideApplication;

        public IndexModel(ISlideApplication slideApplication)
        {
            _slideApplication = slideApplication;
        }

        public void OnGet()
        {
            
            slides = _slideApplication.GetList();
        }
        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateProduct());
        }
    }
}
