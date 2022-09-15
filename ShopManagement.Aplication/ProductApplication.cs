using _0_Framework.Application;
using ShopManagement.application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Aplication
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;

        public ProductApplication(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public OperationResult Create(CreateProduct command)
        {
           var operition=new OperationResult();
            if (_productRepository.Exists(x => x.Name == command.Name))
                operition.Failed(ApplicationMessage.DuplicatedRecord);
            var slug = command.Slug.Slugify1();
            var product = new Product(command.Name, command.Code, command.UnitPrice,
                command.ShortDescription, command.Description, command.Picture,
                command.PictureAlt, command.PictureTitle, slug,
                command.KeyWords, command.MetaDescription, command.CategoryId);
            _productRepository.Create(product);
            _productRepository.SaveChange();
            return operition.Succedded();
        }

        public OperationResult Edit(EditProduct command)
        {
            var operation = new OperationResult();
            var product = _productRepository.Get(command.Id);
            if (product == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);
            if (_productRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            var slug = command.Slug.Slugify1();
            product.Edit(command.Name, command.Code, command.UnitPrice,
                command.ShortDescription, command.Description, command.Picture,
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

        public OperationResult InStock(long id)
        {
            var operation = new OperationResult();
            var product = _productRepository.Get(id);
            if (product == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);
           


            product.InStock();
            _productRepository.SaveChange();
            return operation.Succedded();
        }

        public OperationResult NotInStock(long id)
        {
            var operation = new OperationResult();
            var product = _productRepository.Get(id);
            if (product == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);



            product.NotInStock();
            _productRepository.SaveChange();
            return operation.Succedded();
        }

        public List<ProductViewModel> Search(ProductSearchModel searchmodel)
        {
            return _productRepository.Search(searchmodel);
        }
    }
}
