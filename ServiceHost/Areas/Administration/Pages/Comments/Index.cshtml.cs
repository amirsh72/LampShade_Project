
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;


using System.Collections.Generic;
using CommentManagement.Application.Contracts.Comment;

namespace ServiceHost.Areas.Administration.Pages.Comments
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
            return RedirectToPage("index");
        }
        public IActionResult OnGetCancel(long id)
        {
            _commentApplication.Cancel(id);
            return RedirectToPage("index");

        }
    }
}
