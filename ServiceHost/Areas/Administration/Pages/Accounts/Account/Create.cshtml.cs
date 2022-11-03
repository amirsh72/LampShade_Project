using AccountManagement.Application.Contracts.Account;
using AccountManagement.Application.Contracts.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.application.Contracts.Product;
using ShopManagement.application.Contracts.ProductCategory;

namespace ServiceHost.Areas.Administration.Pages.Accounts.Account
{
    public class CreateModel : PageModel
    {
        public SelectList Roles;
        public CreateAccount CreateAccount { get; set; }
        private readonly IAccountApplication _AccountApplication;
        private readonly IRoleApplication _roleApplication;


        public CreateModel(IAccountApplication accountApplication, IRoleApplication roleApplication)
        {
            _AccountApplication = accountApplication;
            _roleApplication = roleApplication;
        }

        public void OnGet()
        {
            Roles = new SelectList(_roleApplication.List(), "Id", "Name");
        }
        public JsonResult OnPost(CreateAccount command)
        {
            var result = _AccountApplication.Create(command);
            RedirectToPage("./Index");
            return new JsonResult(result);
        }
    }
}
