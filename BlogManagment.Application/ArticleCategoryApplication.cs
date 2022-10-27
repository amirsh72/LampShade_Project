using _0_Framework.Application;
using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagement.Domain.ArticleCategoryAgg;
using System;
using System.Collections.Generic;

namespace BlogManagment.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IFileUploader _fileUploader;
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository,
            IFileUploader fileUploader)
        {
            _articleCategoryRepository = articleCategoryRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateArticleCategory Command)
        {
            var operation = new OperationResult();
            if (_articleCategoryRepository.Exists(x => x.Name == Command.Name))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);
            var slug=Command.Slug.Slugify1();
            var pictureName=_fileUploader.Upload(Command.Picture,slug);
            var articleCategory = new ArticleCategory(Command.Name, pictureName, Command.PictureAlt,
                Command.PictureTitle, Command.Description,Command.ShowOrder, slug, Command.Keywords,
                Command.MetaDescription,
                Command.CanonicalAddress);
            _articleCategoryRepository.Create(articleCategory);
            _articleCategoryRepository.SaveChange();

            return operation.Succedded();

        }

        public OperationResult Edit(EditArticleCategory Command)
        {
            var operation = new OperationResult();
            var articleCategory = _articleCategoryRepository.Get(Command.Id);
            if(articleCategory == null)
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            if (_articleCategoryRepository.Exists(x => x.Name == Command.Name && x.Id!=Command.Id))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            var slug = Command.Slug.Slugify1();
            var pictureName = _fileUploader.Upload(Command.Picture, slug);
            articleCategory.Edit(Command.Name, pictureName,Command.PictureAlt,Command.PictureTitle,
                Command.Description,Command.ShowOrder, slug, Command.Keywords, Command.MetaDescription,
                Command.CanonicalAddress);

           
            _articleCategoryRepository.SaveChange();

            return operation.Succedded();
        }

        public List<ArticleCategoryViewModel> GetArticleCategories()
        {
            return _articleCategoryRepository.GetArticleCategories();
        }

        public EditArticleCategory GetDetails(long id)
        {
            return _articleCategoryRepository.GetDetails(id);
        }

        public List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel)
        {
            return _articleCategoryRepository.Search(searchModel);
        }
    }
}
