using _0_Framework.Infrastructure;
using AccountManagement.Application;
using AccountManagement.Application.Contracts.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.application.Contracts.Order;
using ShopManagement.application.Contracts.ProductCategory;
using ShopManagement.Configuration.Permissions;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.Shop.Orders
{
  
    public class IndexModel : PageModel
    {
        public OrderSearchModel SearchModel;
        public SelectList Accounts;
        public List<OrderViewModel> Orders;
        private readonly IOrderApplication _OrderApplication;
        private readonly IAccountApplication _accountApplication;

        public IndexModel(IOrderApplication orderApplication, IAccountApplication accountApplication)
        {
            _OrderApplication = orderApplication;
            _accountApplication = accountApplication;
        }

        public void OnGet(OrderSearchModel searchModel)
        {
            Accounts = new SelectList(_accountApplication.GetAccounts(), "Id", "Fullname");
          Orders= _OrderApplication.Search(searchModel);
        }
       public IActionResult OnGetConfirm(long id)
        {
            _OrderApplication.PaymentSucceeded(id, 0);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetCancel(long id)
        {
            _OrderApplication.Cancel(id);
            return RedirectToPage("./Index");
        }
    }
}
