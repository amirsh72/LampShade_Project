﻿using _01_LampShadeQuery.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;


namespace ServiceHost.ViewComponents
{
    public class FooterViewComponent:ViewComponent
    {
        private readonly IProductCategoryQuery _productCategoryQuery;
        public FooterViewComponent(IProductCategoryQuery productCategoryQuery)
        {
            _productCategoryQuery = productCategoryQuery;
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
