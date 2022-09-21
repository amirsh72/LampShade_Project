using DiscountManagement.Application;
using DiscountManagement.Application.Contract.CustomerDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.application.Contracts.Product;

using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.Discounts.CoustomerDiscounts
{
    public class IndexModel : PageModel
    {
        public CustomerDiscountSearchModel SearchModel;
        public List<CustomerDiscountViewModel> customerDiscount;
        public SelectList products;

        private readonly IProductApplication _productApplication;
        private readonly ICoustomerDiscountApplication _CustomerDiscountApplication;

        public IndexModel(IProductApplication productApplication,
            ICoustomerDiscountApplication customerDiscountApplication)
        {
            _productApplication = productApplication;
            _CustomerDiscountApplication = customerDiscountApplication;
        }

        public void OnGet(CustomerDiscountSearchModel searchModel)
        {
            products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
          customerDiscount= _CustomerDiscountApplication.Search(searchModel);
        }
        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateProduct());
        }
    }
}
