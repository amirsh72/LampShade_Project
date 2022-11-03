using AccountManagement.Application.Contracts.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.application.Contracts.Product;
using ShopManagement.application.Contracts.ProductCategory;

namespace ServiceHost.Areas.Administration.Pages.Accounts.Account
{
    public class ChangePasswordModel : PageModel
    {

        public ChangePassword changePassword { get; set; }
        public long Id { get; set; }
        private readonly IAccountApplication _AccountApplication;


        public ChangePasswordModel(IAccountApplication accountApplication)
        {
            _AccountApplication = accountApplication;

        }

        public void OnGet(long id)
        {
            Id = id;

        }
        public JsonResult OnPost(ChangePassword changePassword)
        {

            var result = _AccountApplication.ChangePassword(changePassword);
            RedirectToPage("./Index");
            return new JsonResult(result);
        }
    }
}
