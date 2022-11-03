using AccountManagement.Application.Contracts.Account;
using AccountManagement.Application.Contracts.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.application.Contracts.Product;
using ShopManagement.application.Contracts.ProductCategory;

namespace ServiceHost.Areas.Administration.Pages.Accounts.Role
{
    public class CreateModel : PageModel
    {
        
        public CreateRole createRole { get; set; }
       
        private readonly IRoleApplication _roleApplication;


        public CreateModel( IRoleApplication roleApplication)
        {
           
            _roleApplication = roleApplication;
        }

        public void OnGet()
        {
            
        }
        public JsonResult OnPost(CreateRole command)
        {
            var result = _roleApplication.Create(command);
            RedirectToPage("./Index");
            return new JsonResult(result);
        }
    }
}
