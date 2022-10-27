using BlogManagement.Application.Contracts.Article;
using BlogManagement.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Blog.Articles
{
    public class CreateModel : PageModel
    {
        public SelectList ArticleCategories { get; set; }
        public CreateArticle createArticle { get; set; }
        private readonly IArticleApplication _articleApplication;
        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public CreateModel(IArticleApplication articleApplication, IArticleCategoryApplication articleCategoryApplication)
        {
            _articleApplication = articleApplication;
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet()
        {
            ArticleCategories = new SelectList(_articleCategoryApplication.GetArticleCategories(),"Id","Name");
        }
        public JsonResult OnPost(CreateArticle createArticle)
        {
         var result= _articleApplication.Create(createArticle);
             RedirectToPage("./Index");
            return new JsonResult(result);
        }
    }
}
