using AccountManagement.Application.Contracts.Account;
using AccountManagement.Application.Contracts.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.application.Contracts.Product;
using ShopManagement.application.Contracts.ProductCategory;

namespace ServiceHost.Areas.Administration.Pages.Accounts.Role
{
    public class EditModel : PageModel
    {
        [BindProperty] public EditRole  editRole { get; set; }
       
        
        private readonly IRoleApplication _roleApplication;

        public EditModel(IRoleApplication roleApplication)
        {
            _roleApplication = roleApplication;
        }

        public void OnGet(long id)
        {
           
            editRole = _roleApplication.GetDetails(id);
        }
        public JsonResult OnPost()
        {
          var result=_roleApplication.Edit(editRole);
            
            RedirectToPage("./Index");
            return new JsonResult(result);
        }
      
    }
}
