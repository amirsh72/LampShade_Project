
using _0_Framework.Infrastructure;
using InventoryManagement.Application.Contracts.Inventory;
using InventoryManagement.Infrastructure.Configuration.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.application.Contracts.Product;

using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.Inventory
{
    [Authorize(Roles = Roles.Administator)]
    public class OperationLogModel : PageModel
    {
        public InventorySearchModel SearchModel;
        public List<InventoryOperationViewModel> inventory;
        public SelectList products;

        private readonly IProductApplication _productApplication;
        private readonly IInventoryApplication _inventoryApplication;

        public OperationLogModel(IProductApplication productApplication,
            IInventoryApplication inventoryApplication)
        {
            _productApplication = productApplication;
            _inventoryApplication = inventoryApplication;
        }
        [NeedsPermissionsAttribute(InventoryPermissions.OperationLog)]
        public void OnGet(long id)
        {
            products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
            inventory = _inventoryApplication.GetOperationlog(id);
        }
        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateInventory());

        }
        
    }
}
