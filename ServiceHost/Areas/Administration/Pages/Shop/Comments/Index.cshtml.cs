using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Aplication;
using ShopManagement.application.Contracts.Comment;
using ShopManagement.application.Contracts.Product;
using ShopManagement.application.Contracts.ProductCategory;
using ShopManagement.application.Contracts.ProductPicture;
using ShopManagement.application.Contracts.Slide;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.Shop.Comments
{
    public class IndexModel : PageModel
    {
        
        public List<CommentViewModel> comments;
        public CommentSearchModel searchModel;
        

        private readonly ICommentApplication _commentApplication ;

        public IndexModel(ICommentApplication commentApplication)
        {
            _commentApplication=commentApplication;
        }

        public void OnGet(CommentSearchModel searchModel)
        {

            comments = _commentApplication.Search(searchModel);
        }
        public IActionResult OnGetConfirm(long id)
        {
            _commentApplication.Confirm(id);
            return Partial("./index", new CreateProduct());
        }
        public IActionResult OnGetCancel(long id)
        {
            _commentApplication.Cancel(id);
            return Partial("./index", new CreateProduct());
        }
    }
}
