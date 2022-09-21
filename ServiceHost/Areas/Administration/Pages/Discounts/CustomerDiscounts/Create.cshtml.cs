using DiscountManagement.Application.Contract.CustomerDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.application.Contracts.Product;
using ShopManagement.application.Contracts.ProductCategory;

namespace ServiceHost.Areas.Administration.Pages.Discounts.CustomerDiscounts
{
    public class CreateModel : PageModel
    {
        public SelectList products;
        public DefineCustomerDiscount defineCustomerDiscount { get; set; }
        private readonly IProductApplication _productApplication;
        private readonly ICoustomerDiscountApplication _coustomerDiscount;

        public CreateModel(IProductApplication productApplication, 
            ICoustomerDiscountApplication coustomerDiscount)
        {
            _productApplication = productApplication;
            _coustomerDiscount = coustomerDiscount;
        }

        public void OnGet()
        {
            products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
        }
        public JsonResult OnPost(DefineCustomerDiscount command)
        {
            var result = _coustomerDiscount.Define(command);
            RedirectToPage("./Index");
            return new JsonResult(result);
        }
    }
}
