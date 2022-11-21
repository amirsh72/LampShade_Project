
using _0_Framework.Infrastructure;
using InventoryManagement.Application.Contracts.Inventory;
using InventoryManagement.Infrastructure.Configuration.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.application.Contracts.Product;


namespace ServiceHost.Areas.Administration.Pages.Inventory
{
    [Authorize(Roles = Roles.Administator)]
    public class CreateModel : PageModel
    {
        public SelectList products;
        public CreateInventory createInventory { get; set; }
        private readonly IProductApplication _productApplication;
        private readonly IInventoryApplication _inventory;

        public CreateModel(IProductApplication productApplication, 
            IInventoryApplication inventory)
        {
            _productApplication = productApplication;
            _inventory = inventory;
        }
        [NeedsPermissionsAttribute(InventoryPermissions.CreateInventory)]
        public void OnGet()
        {
            products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
        }
        public JsonResult OnPost(CreateInventory command)
        {
            var result = _inventory.Create(command);
            RedirectToPage("./Index");
            return new JsonResult(result);
        }
    }
}
