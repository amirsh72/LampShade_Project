using BlogManagement.Application.Contracts.Article;
using BlogManagement.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace ServiceHost.Areas.Administration.Pages.Blog.Articles
{
    public class EditModel : PageModel
    {
        [BindProperty] public EditArticle editArticle { get; set; }
        private readonly IArticleCategoryApplication _articleCategoryApplication;
        private readonly IArticleApplication _ArticleApplication;
        public SelectList ArticleCategories;

        public EditModel(IArticleApplication articleApplication, 
            IArticleCategoryApplication articleCategoryApplication)
        {
            _ArticleApplication = articleApplication;
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet(long id)
        {
            editArticle = _ArticleApplication.GetDetails(id);
            ArticleCategories = new SelectList(_articleCategoryApplication.GetArticleCategories(),"Id","Name");

        }
        public JsonResult OnPost()
        {
            if (ModelState.IsValid)
            {

            }
          var result=_ArticleApplication.Edit(editArticle);
            
            RedirectToPage("./Index");
            return new JsonResult(result);
        }
    }
}
