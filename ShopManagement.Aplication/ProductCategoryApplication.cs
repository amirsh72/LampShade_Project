using _0_Framework.Application;
using ShopManagement.application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Aplication
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IFileUploader _fileUploader;
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository, IFileUploader fileUploader)
        {
            _productCategoryRepository = productCategoryRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateProductCategory command)
        {
            var operation=new OperationResult();
            if (_productCategoryRepository.Exists(x=>x.Name==command.Name))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);
            var slug = command.Slug.Slugify1();
            var picturePath = $"{command.Slug}";
            var filaName = _fileUploader.Upload(command.Picture,picturePath);
            var productCategory=new ProductCategory(command.Name,command.Description,filaName
                ,command.PictureAlt,command.PictureTitle,command.KeyWords,
                command.MetaDescription,slug);
            _productCategoryRepository.Create(productCategory);
            _productCategoryRepository.SaveChange();
            return operation.Succedded();
        }

        public OperationResult Edit(EditProductCategory command)
        {
            var operation=new OperationResult();
            var productCategory=_productCategoryRepository.Get(command.Id);
            if (productCategory == null)
                return operation.Failed(ApplicationMessage.RecordNotFound );
            if (_productCategoryRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);
            var slug=command.Slug.Slugify1();
            var picturePath = $"{command.Slug}";
            var filaName = _fileUploader.Upload(command.Picture, picturePath);            
            productCategory.Edit(command.Name, command.Description, filaName, command.PictureAlt,
                command.PictureTitle, command.KeyWords,command.MetaDescription,slug);
            _productCategoryRepository.SaveChange();
           return operation.Succedded();
        }

        public EditProductCategory GetDetails(long id)
        {
           return _productCategoryRepository.GetDetail(id);
        }

        public List<ProductCategoryViewModel> GetProductCategories()
        {
            return _productCategoryRepository.GetProductCategories();
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            return _productCategoryRepository.Search(searchModel);
        }

        
    }
}
