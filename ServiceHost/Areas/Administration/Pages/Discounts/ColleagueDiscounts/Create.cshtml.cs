using DiscountManagement.Application.Contract.ColleagueDiscount;
using DiscountManagement.Application.Contract.CustomerDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.application.Contracts.Product;
using ShopManagement.application.Contracts.ProductCategory;

namespace ServiceHost.Areas.Administration.Pages.Discounts.ColleagueDiscounts
{
    public class CreateModel : PageModel
    {
        public SelectList products;
        public DefineColleagueDiscount defineColleagueDiscount { get; set; }
        private readonly IProductApplication _productApplication;
        private readonly IColleagueDiscountApplication _colleagueDiscount;

        public CreateModel(IProductApplication productApplication, 
            IColleagueDiscountApplication colleagueDiscount)
        {
            _productApplication = productApplication;
            _colleagueDiscount = colleagueDiscount;
        }

        public void OnGet()
        {
            products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
        }
        public JsonResult OnPost(DefineColleagueDiscount command)
        {
            var result = _colleagueDiscount.Define(command);
            RedirectToPage("./Index");
            return new JsonResult(result);
        }
    }
}
