using _0_Framework.Application;
using ShopManagement.application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Aplication
{
    public class ProductApplication : IProductApplication
    {
        private readonly IFileUploader _fileUploader;
        private readonly IProductRepository _productRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductApplication(IProductRepository productRepository, IFileUploader fileUploader, IProductCategoryRepository productCategoryRepository)
        {
            _productRepository = productRepository;
            _fileUploader = fileUploader;
            _productCategoryRepository = productCategoryRepository;
        }

        public OperationResult Create(CreateProduct command)
        {
           var operition=new OperationResult();

            if (_productRepository.Exists(x => x.Name == command.Name))
                operition.Failed(ApplicationMessage.DuplicatedRecord);
            var slug = command.Slug.Slugify1();
            var categorySlug=_productCategoryRepository.GetSlugBy(command.CategoryId);
            var path=$"{categorySlug}/{slug}";
            var picturePath=_fileUploader.Upload(command.Picture,path);
            var product = new Product(command.Name, command.Code,command.ShortDescription, command.Description,picturePath,
                command.PictureAlt, command.PictureTitle, slug,
                command.KeyWords, command.MetaDescription, command.CategoryId);
            _productRepository.Create(product);
            _productRepository.SaveChange();
            return operition.Succedded();
        }

        public OperationResult Edit(EditProduct command)
        {
            var operation = new OperationResult();
            var product = _productRepository.GetProductWhitCategory(command.Id);
            if (product == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);
            if (_productRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            var slug = command.Slug.Slugify1();
    
            var path = $"{product.Category.Slug}/{slug}";
            var picturePath = _fileUploader.Upload(command.Picture, path);
            product.Edit(command.Name, command.Code,
                command.ShortDescription, command.Description, picturePath,
                command.PictureAlt, command.PictureTitle, slug,
                command.KeyWords, command.MetaDescription, command.CategoryId);
            _productRepository.SaveChange();
            return operation.Succedded();
        }

        public EditProduct GetDetails(long id)
        {
            return _productRepository.GetDetails(id);
        }

        public List<ProductViewModel> GetProducts()
        {
           return _productRepository.GetProducts();
        }

        public List<ProductViewModel> Search(ProductSearchModel searchmodel)
        {
            return _productRepository.Search(searchmodel);
        }
    }
}
