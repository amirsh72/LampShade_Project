using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.application.Contracts.Order;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.Shop.Orders
{
    public class ItemsModel : PageModel
    {
        public List<OrderItemViewModel> Items { get; set; }
        private readonly IOrderApplication _orderApplication;

        public ItemsModel(IOrderApplication orderApplication)
        {
            _orderApplication = orderApplication;
        }

        public void OnGet(long id)
        {
            Items=_orderApplication.GetItems(id);
        }
    }
}
