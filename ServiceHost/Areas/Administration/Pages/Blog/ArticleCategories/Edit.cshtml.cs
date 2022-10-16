using BlogManagement.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.application.Contracts.ProductCategory;

namespace ServiceHost.Areas.Administration.Pages.Blog.ArticleCategories
{
    public class EditModel : PageModel
    {
        [BindProperty] public EditArticleCategory editArticleCategory { get; set; }
        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public EditModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet(long id)
        {
            editArticleCategory = _articleCategoryApplication.GetDetails(id);
        }
        public JsonResult OnPost()
        {
            if (ModelState.IsValid)
            {

            }
          var result=_articleCategoryApplication.Edit(editArticleCategory);
            
            RedirectToPage("./Index");
            return new JsonResult(result);
        }
    }
}
