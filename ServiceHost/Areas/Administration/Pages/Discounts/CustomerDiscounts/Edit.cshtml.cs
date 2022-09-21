
using DiscountManagement.Application.Contract.CustomerDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.application.Contracts.Product;


namespace ServiceHost.Areas.Administration.Pages.Discounts.CustomerDiscounts
{
    public class EditModel : PageModel
    {
        [BindProperty] public EditCustomerDiscount editCustomerDiscount{ get; set; }
        public SelectList products;
        
        private readonly IProductApplication _productApplication;
        private readonly ICoustomerDiscountApplication _customerDiscountApplication;

        public EditModel(IProductApplication productApplication, 
            ICoustomerDiscountApplication customerDiscountApplication)
        {
            _productApplication = productApplication;
            _customerDiscountApplication = customerDiscountApplication;
        }

        public void OnGet(long id)
        {
            products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
            editCustomerDiscount = _customerDiscountApplication.GetDetails(id);
        }
        public JsonResult OnPost()
        {
          var result=_customerDiscountApplication.Edit(editCustomerDiscount);
            
            RedirectToPage("./Index");
            return new JsonResult(result);
        }
        //public IActionResult OnGetNotInStock(long id)
        //{
        //    _productApplication.NotInStock(id);
        //   return RedirectToPage("./Index");
        //}
        //public IActionResult OnGetIsInStock(long id)
        //{
        //    _productApplication.InStock(id);
        //   return RedirectToPage("./Index");

        //}
    }
}
