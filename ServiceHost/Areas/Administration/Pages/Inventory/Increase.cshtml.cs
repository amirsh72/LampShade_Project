using _0_Framework.Infrastructure;
using InventoryManagement.Application.Contracts.Inventory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.application.Contracts.Product;

namespace ServiceHost.Areas.Administration.Pages.Inventory
{
    [Authorize(Roles = Roles.Administator)]
    public class IncreaseModel : PageModel
    {
        [BindProperty] public IncreaseInventory increaseinventory { get; set; }
        public SelectList products;

        private readonly IProductApplication _productApplication;
        private readonly IInventoryApplication _inventoryApplication;

        public IncreaseModel(IProductApplication productApplication,
            IInventoryApplication inventoryApplication)
        {
            _productApplication = productApplication;
            _inventoryApplication = inventoryApplication;
        }

        public void OnGet(long id)
        {
            products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
            increaseinventory = new IncreaseInventory
            {
                InventoryId = id,
            };
            
        }
        public JsonResult OnPost(IncreaseInventory command)
        {
            var result = _inventoryApplication.Increase(command);

            RedirectToPage("./Index");
            return new JsonResult(result);
        }
        //public IActionResult OnGetRemove(long id)
        //{
        //    _inventoryApplication.Remove(id);
        //    return RedirectToPage("./Index");
        //}
        //public IActionResult OnGetRestore(long id)
        //{
        //    _inventoryApplication.Restore(id);
        //    return RedirectToPage("./Index");

        //}
    }
}
