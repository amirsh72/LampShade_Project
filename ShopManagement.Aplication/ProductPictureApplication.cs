using _0_Framework.Application;
using ShopManagement.application.Contracts.ProductPicture;
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
        private readonly IProductPictureRepository _productPictureRepository;

        public ProductPictureApplication(IProductPictureRepository productPictureRepository)
        {
            _productPictureRepository = productPictureRepository;
        }

        public OperationResult Create(CreateProductPicture command)
        {
            var opertion = new OperationResult();
            if (_productPictureRepository.Exists(x => x.Picture == command.Picture &&
            x.ProductId == command.ProductId))
                return opertion.Failed(ApplicationMessage.DuplicatedRecord);
            var productpicture = new ProductPicture(command.ProductId, command.Picture,
                command.PictureAlt, command.PictureTitle);
            _productPictureRepository.Create(productpicture);
            _productPictureRepository.SaveChange();
            return opertion.Succedded();
        }

        public OperationResult Edit(EditProductPicture command)
        {
            var opertion = new OperationResult();
            var ProductPicture = _productPictureRepository.Get(command.Id);
            if(ProductPicture==null)
                return opertion.Failed(ApplicationMessage.RecordNotFound);
            if (_productPictureRepository.Exists(x => x.Picture == command.Picture && x.ProductId == command.ProductId && x.Id != command.Id))
                return opertion.Failed(ApplicationMessage.DuplicatedRecord);
            ProductPicture.Edit(command.ProductId,command.Picture,command.PictureAlt,command.PictureTitle);
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
