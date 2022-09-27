using DiscountManagement.Application;
using DiscountManagement.Application.Contract.ColleagueDiscount;
using DiscountManagement.Application.Contract.CustomerDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.application.Contracts.Product;

using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.Discounts.ColleagueDiscounts
{
    public class IndexModel : PageModel
    {
        public ColleagueDiscountSearchModel SearchModel;
        public List<ColleagueDiscountViewModel> colleagueDiscount;
        public SelectList products;

        private readonly IProductApplication _productApplication;
        private readonly IInventoryApplication _ColleagueDiscountApplication;

        public IndexModel(IProductApplication productApplication,
            IInventoryApplication customerDiscountApplication)
        {
            _productApplication = productApplication;
            _ColleagueDiscountApplication = customerDiscountApplication;
        }

        public void OnGet(ColleagueDiscountSearchModel searchModel)
        {
            products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
          colleagueDiscount= _ColleagueDiscountApplication.Search(searchModel);
        }
        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateProduct());
        }
    }
}
