using _0_Framework.Application;
using BlogManagement.Application.Contracts.Article;
using BlogManagement.Domain.ArticleAgg;
using BlogManagement.Domain.ArticleCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagment.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IFileUploader _fileUploader;
        private readonly IArticleRepository _articleRepository;
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        public ArticleApplication(IFileUploader fileUploader, 
            IArticleRepository articleRepository,
            IArticleCategoryRepository articleCategoryRepository)
        {
            _fileUploader = fileUploader;
            _articleRepository = articleRepository;
            _articleCategoryRepository = articleCategoryRepository;
        }

        public OperationResult Create(CreateArticle Command)
        {
           var operation=new OperationResult();
            if(_articleRepository.Exists(x=>x.Title==Command.Title))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);
            var slug=Command.Slug.Slugify1();
            var categorySlug =_articleCategoryRepository.GetSlugBy(Command.CategoryId);
            var path =$"{categorySlug}/{slug}";
            var pictureName=_fileUploader.Upload(Command.Picture,path);
            var article = new Article(Command.Title, Command.ShortDescription, Command.Description,
                pictureName, Command.PictureAlt, Command.PictureTitle, Command.PublishDate.ToGeorgianDateTime(), slug,
                Command.Keywords, Command.MetaDescription, Command.CanonicalAddress, Command.CategoryId);
           _articleRepository.Create(article);
            _articleRepository.SaveChange();

            return operation.Succedded();
        }

        public OperationResult Edit(EditArticle Command)
        {
            var operation=new OperationResult();
            var article = _articleRepository.GetWhitCategory(Command.Id);
            if(article==null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            if (_articleRepository.Exists(x => x.Title == Command.Title && x.Id!=Command.Id))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);


            var slug = Command.Slug.Slugify1();
            
            var path = $"{article.Category.Slug}/{slug}";
            var pictureName = _fileUploader.Upload(Command.Picture, path);
            article.Edit(Command.Title, Command.ShortDescription, Command.Description,
                pictureName, Command.PictureAlt, Command.PictureTitle, Command.PublishDate.ToGeorgianDateTime(), slug,
                Command.Keywords, Command.MetaDescription, Command.CanonicalAddress, Command.CategoryId);
           
            _articleRepository.SaveChange();

            return operation.Succedded();

        }

        public EditArticle GetDetails(long id)
        {
            return _articleRepository.GetDetails(id);
        }

        public List<ArticleViewModel> Search(ArticleSearchModel searchModel)
        {
            return _articleRepository.Search(searchModel);
        }
    }
}
