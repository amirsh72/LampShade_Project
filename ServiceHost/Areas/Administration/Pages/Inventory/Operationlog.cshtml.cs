
using InventoryManagement.Application.Contracts.Inventory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.application.Contracts.Product;

using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.Inventory
{
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
