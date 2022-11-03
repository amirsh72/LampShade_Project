using AccountManagement.Application.Contracts.Account;
using AccountManagement.Application.Contracts.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.application.Contracts.Product;
using ShopManagement.application.Contracts.ProductCategory;

namespace ServiceHost.Areas.Administration.Pages.Accounts.Account
{
    public class EditModel : PageModel
    {
        [BindProperty] public EditAccount editAccount { get; set; }
        public SelectList Roles;

        private readonly IRoleApplication _roleApplication;
        private readonly IAccountApplication _accountApplication;


        public EditModel(IAccountApplication accountApplication, IRoleApplication roleApplication)
        {
            _accountApplication = accountApplication;
            _roleApplication = roleApplication;
        }





        public void OnGet(long id)
        {
           
            editAccount = _accountApplication.GetDetails(id);
            Roles = new SelectList(_roleApplication.List(), "Id", "Name");
        }
        public JsonResult OnPost()
        {
          var result=_accountApplication.Edit(editAccount);
            
            RedirectToPage("./Index");
            return new JsonResult(result);
        }
      
    }
}
