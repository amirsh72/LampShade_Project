
using _0_Framework.Domain;
using BlogManagement.Application.Contracts.Article;
using BlogManagement.Application.Contracts.ArticleCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Domain.ArticleAgg
{
    public interface IArticleRepository:IRepository<long,Article>
    {
        
        EditArticle GetDetails(long id);        
        Article GetWhitCategory(long id);
        List<ArticleViewModel> Search(ArticleSearchModel searchModel);
    }
}
