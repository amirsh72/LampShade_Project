
using DiscountManagement.Application.Contract.ColleagueDiscount;
using DiscountManagement.Application.Contract.CustomerDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.application.Contracts.Product;


namespace ServiceHost.Areas.Administration.Pages.Discounts.ColleagueDiscounts
{
    public class EditModel : PageModel
    {
        [BindProperty] public EditColleagueDiscount editColleagueDiscount{ get; set; }
        public SelectList products;
        
        private readonly IProductApplication _productApplication;
        private readonly IInventoryApplication _colleagueDiscountApplication;

        public EditModel(IProductApplication productApplication, 
            IInventoryApplication colleagueDiscountApplication)
        {
            _productApplication = productApplication;
            _colleagueDiscountApplication = colleagueDiscountApplication;
        }

        public void OnGet(long id)
        {
            products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
            editColleagueDiscount = _colleagueDiscountApplication.GetDetails(id);
        }
        public JsonResult OnPost()
        {
          var result=_colleagueDiscountApplication.Edit(editColleagueDiscount);
            
            RedirectToPage("./Index");
            return new JsonResult(result);
        }
        public IActionResult OnGetRemove(long id)
        {
            _colleagueDiscountApplication.Remove(id);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetRestore(long id)
        {
            _colleagueDiscountApplication.Restore(id);
            return RedirectToPage("./Index");

        }
    }
}
