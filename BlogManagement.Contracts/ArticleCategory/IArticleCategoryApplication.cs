using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Application.Contracts.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        OperationResult Create(CreateArticleCategory Command);
        OperationResult Edit(EditArticleCategory Command);
        List<ArticleCategoryViewModel> GetArticleCategories();
        EditArticleCategory GetDetails(long id);
        List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel);

    }
}
