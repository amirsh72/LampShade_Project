using _01_LampShadeQuery;
using _01_LampShadeQuery.Contracts.ArticleCategory;
using _01_LampShadeQuery.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;


namespace ServiceHost.ViewComponents
{
    public class MenuViewComponent:ViewComponent
    {
        private readonly IProductCategoryQuery _productCategoryQuery;
        private readonly IArticleCategoryQuery _articleCategoryQuery;
        public MenuViewComponent(IProductCategoryQuery productCategoryQuery,
            IArticleCategoryQuery articleCategoryQuery)
        {
            _articleCategoryQuery= articleCategoryQuery;
            _productCategoryQuery = productCategoryQuery;
        }

        public IViewComponentResult Invoke()
        {
            var result = new MenuModel
            {
                productCategories = _productCategoryQuery.GetProductCategories(),
                articleCategories = _articleCategoryQuery.GetArticleCategories(),
            };
            return View(result);
        }
    }
}
