using _0_Framework.Infrastructure;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Application.Contracts.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.application.Contracts.Product;
using ShopManagement.application.Contracts.ProductCategory;
using System.Collections.Generic;
using System.Linq;

namespace ServiceHost.Areas.Administration.Pages.Accounts.Role
{
    public class EditModel : PageModel
    {
        [BindProperty] public EditRole  editRole { get; set; }
        public List<SelectListItem> Permissions = new List<SelectListItem>();
        private readonly IRoleApplication _roleApplication;
        private readonly IEnumerable<IPermissionExposer> _exposers;

        public EditModel(IRoleApplication roleApplication, IEnumerable<IPermissionExposer> exposers)
        {
            _roleApplication = roleApplication;
            _exposers = exposers;
        }

        public void OnGet(long id)
        {
           
            editRole = _roleApplication.GetDetails(id);
            var permissions=new List<PermissionDto>();
            foreach(var exposer in _exposers)
            {
                var exposedPermissions = exposer.Expose();
                foreach(var (key,value) in exposedPermissions)
                {
                    permissions.AddRange(value);
                    var group = new SelectListGroup()
                    {
                        Name = key,
                       
                    };
                    foreach(var permission in value)
                    {
                        var item = new SelectListItem(permission.Name, permission.Code.ToString())
                        {
                            Group = group,
                        };
                        if(editRole.MappedPermissions.Any(x=>x.Code==permission.Code))
                            item.Selected=true;
                        Permissions.Add(item);
                    };
                }
            }
        }
        public JsonResult OnPost()
        {
          var result=_roleApplication.Edit(editRole);
            
            RedirectToPage("./Index");
            return new JsonResult(result);
        }
      
    }
}
