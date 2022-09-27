

using InventoryManagement.Application.Contracts.Inventory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.application.Contracts.Product;


namespace ServiceHost.Areas.Administration.Pages.Inventory
{
    public class EditModel : PageModel
    {
        [BindProperty] public EditInventory editinventory{ get; set; }
        public SelectList products;
        
        private readonly IProductApplication _productApplication;
        private readonly IInventoryApplication _inventoryApplication;

        public EditModel(IProductApplication productApplication, 
            IInventoryApplication inventoryApplication)
        {
            _productApplication = productApplication;
            _inventoryApplication = inventoryApplication;
        }

        public void OnGet(long id)
        {
            products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
            editinventory = _inventoryApplication.GetDetails(id);
        }
        public JsonResult OnPost()
        {
          var result=_inventoryApplication.Edit(editinventory);
            
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
