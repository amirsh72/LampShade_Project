﻿using _0_Framework.Application;
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
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public OperationResult Create(CreateProductCategory command)
        {
            var operation=new OperationResult();
            if (_productCategoryRepository.Exists(x=>x.Name==command.Name))
                return operation.Failed("امکان ثبت رکورد تکراری وجود ندارد");
            var slug = command.Slug.Slugify1();
            var productCategory=new ProductCategory(command.Name,command.Description,command.Picture
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
                return operation.Failed(" رکورد با اطلاعات درخواست شده یافت نشد");
            if (_productCategoryRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed("امکان ثبت رکورد تکراری وجود ندارد");
            productCategory.Edit(command.Name, command.Description, command.Picture, command.PictureAlt, command.PictureTitle, command.KeyWords,command.MetaDescription,command.Slug);
            _productCategoryRepository.SaveChange();
           return operation.Succedded();
        }

        public EditProductCategory GetDetails(long id)
        {
           return _productCategoryRepository.GetDetail(id);
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            return _productCategoryRepository.Search(searchModel);
        }

        
    }
}
