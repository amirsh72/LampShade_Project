using _0_Framework.Application;
using ShopManagement.application.Contracts.ProductPicture;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductPictureAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Aplication
{
    public class ProductPictureApplication : IProductPictureApplication
    {
        private readonly IFileUploader _fileUploader;
        private readonly IProductRepository _productRepository;
        private readonly IProductPictureRepository _productPictureRepository;

        public ProductPictureApplication(IProductPictureRepository productPictureRepository,
            IFileUploader fileUploader, IProductRepository productRepository)
        {
            _productPictureRepository = productPictureRepository;
            _fileUploader = fileUploader;
            _productRepository = productRepository;
        }

        public OperationResult Create(CreateProductPicture command)
        {
            var opertion = new OperationResult();
            //if (_productPictureRepository.Exists(x => x.Picture == command.Picture &&
            //x.ProductId == command.ProductId))

            var product = _productRepository.GetProductWhitCategory(command.ProductId);
            var path = $"{product.Category.Slug}/{product.Slug}";

           var picturePath= _fileUploader.Upload(command.Picture, path);
                return opertion.Failed(ApplicationMessage.DuplicatedRecord);

            var productPicture = new ProductPicture(command.ProductId, picturePath,
                command.PictureAlt, command.PictureTitle);
            _productPictureRepository.Create(productPicture);
            _productPictureRepository.SaveChange();
            return opertion.Succedded();
        }

        public OperationResult Edit(EditProductPicture command)
        {
            var opertion = new OperationResult();
            var ProductPicture = _productPictureRepository.Get(command.Id);
            if(ProductPicture==null)
                return opertion.Failed(ApplicationMessage.RecordNotFound);

            var productPicture = _productPictureRepository.GetProductAndCategory(command.Id);
            var path = $"{productPicture.product.Category.Slug}/{productPicture.product.Slug}";
            var picturePath = _fileUploader.Upload(command.Picture, path);
            //if (_productPictureRepository.Exists(x => x.Picture == command.Picture && x.ProductId == command.ProductId && x.Id != command.Id))
            //    return opertion.Failed(ApplicationMessage.DuplicatedRecord);
            ProductPicture.Edit(command.ProductId,picturePath,command.PictureAlt,command.PictureTitle);
            _productPictureRepository.SaveChange();
            return opertion.Succedded();
        }

        public EditProductPicture GetDetails(long id)
        {
            return _productPictureRepository.GetDetails(id);
        }

        public OperationResult Remove(long id)
        {
            var opertion = new OperationResult();
            var ProductPicture = _productPictureRepository.Get(id);
            if (ProductPicture == null)
                return opertion.Failed(ApplicationMessage.RecordNotFound);
          
            ProductPicture.Remove();
            _productPictureRepository.SaveChange();
            return opertion.Succedded();
        }

        public OperationResult ReStore(long id)
        {
            var opertion = new OperationResult();
            var ProductPicture = _productPictureRepository.Get(id);
            if (ProductPicture == null)
                return opertion.Failed(ApplicationMessage.RecordNotFound);

            ProductPicture.ReStore();
            _productPictureRepository.SaveChange();
            return opertion.Succedded();
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel command)
        {
            return _productPictureRepository.Search(command);
        }
    }
}
