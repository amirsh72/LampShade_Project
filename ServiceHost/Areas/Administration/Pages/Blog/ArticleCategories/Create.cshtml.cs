using BlogManagement.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace ServiceHost.Areas.Administration.Pages.Blog.ArticleCategories
{
    public class CreateModel : PageModel
    {
        public CreateArticleCategory createArticleCategory { get; set; }
        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public CreateModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet()
        {
            
        }
        public JsonResult OnPost(CreateArticleCategory command)
        {
         var result= _articleCategoryApplication.Create(command);
             RedirectToPage("./Index");
            return new JsonResult(result);
        }
    }
}
