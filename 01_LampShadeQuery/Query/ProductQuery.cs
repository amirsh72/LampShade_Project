﻿using _0_Framework.Application;
using _01_LampshadeQuery.Contracts.Product;
using _01_LampShadeQuery.Contracts.Product;
using DiscountManagement.Infrastructure.EFCore;
using InventoryManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.CommentAgg;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagementInfrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_LampShadeQuery.Query
{
    public class ProductQuery : IProductQuery
    {
        private readonly ShopContext _context;
        private readonly InventoryContext _inventoryContext;
        private readonly DisCountContext _discountContext;

        public ProductQuery(ShopContext context,
            InventoryContext inventoryContext,
            DisCountContext discountContext)
        {
            _context = context;
            _inventoryContext = inventoryContext;
            _discountContext = discountContext;
        }


        public List<ProductQueryModel> GetLatestArrivals()
        {
            var inventory = _inventoryContext.Inventory
               .Select(x => new { x.ProductId, x.UnitPrice }).ToList();
            var discounts = _discountContext.customerDiscounts
                .Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                .Select(x => new { x.DiscountRate, x.ProductId }).ToList();
            var products=_context.products.Include(x=>x.Category)
            .Select(product => new ProductQueryModel
            {
                Id = product.Id,
                Category = product.Category.Name,
                Picture = product.Picture,
                PictureAlt = product.PictureAlt,
                PictureTitle = product.PictureTitle,
                Name = product.Name,
                Slug = product.Slug,

            }).OrderByDescending(x=>x.Id).Take(6).ToList();
            
                foreach (var product in products)
                {
                    var productInventory = inventory.FirstOrDefault(x => x.ProductId == product.Id);
                    if (productInventory != null)
                    {
                        var price = productInventory.UnitPrice;
                        product.Price = price.ToMoney();
                        var discount = discounts.FirstOrDefault(x => x.ProductId == product.Id);
                        if (discount != null)
                        {
                            int discountRate = discount.DiscountRate;
                            product.DiscountRate = discountRate;
                            product.HasDiscount = discountRate > 0;
                            var discountAmount = Math.Round((price * discountRate) / 100);
                            product.PriceWhitDiscount = (price - discountAmount).ToMoney();
                        }
                    }

                }
            
            return products;
        }

        public ProductQueryModel GetProductDetails(string slug)
        {
           
                var inventory = _inventoryContext.Inventory.Select(x => new { x.ProductId, x.UnitPrice, x.InStock }).ToList();

                var discounts = _discountContext.customerDiscounts
                    .Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                    .Select(x => new { x.DiscountRate, x.ProductId, x.EndDate }).ToList();

                var product = _context.products
                    .Include(x => x.Category)
                    .Include(x => x.productPictures)
                    .Include(x => x.comments)
                    
                    .Select(x => new ProductQueryModel
                    {
                        Id = x.Id,
                        Category = x.Category.Name,
                        Name = x.Name,
                        Picture = x.Picture,
                        PictureAlt = x.PictureAlt,
                        PictureTitle = x.PictureTitle,
                        Slug = x.Slug,
                        CategorySlug = x.Category.Slug,
                        Code = x.Code,
                        Description = x.Description,
                        Keywords = x.KeyWords,
                        comments=MapComments(x.comments),
                        MetaDescription = x.MetaDescription,
                        ShortDescription = x.ShortDescription,
                        Pictures = MapProductPictures(x.productPictures)
                        
                    }).AsNoTracking().FirstOrDefault(x => x.Slug == slug);

                if (product == null)
                    return new ProductQueryModel();

                var productInventory = inventory.FirstOrDefault(x => x.ProductId == product.Id);
                if (productInventory != null)
                {
                    product.IsInStock = productInventory.InStock;
                    var price = productInventory.UnitPrice;
                    product.Price = price.ToMoney();
                    product.DoublePrice = price;
                    var discount = discounts.FirstOrDefault(x => x.ProductId == product.Id);
                    if (discount != null)
                    {
                        var discountRate = discount.DiscountRate;
                        product.DiscountRate = discountRate;
                        product.DiscountExpireDate = discount.EndDate.ToDiscountFormat();
                        product.HasDiscount = discountRate > 0;
                        var discountAmount = Math.Round((price * discountRate) / 100);
                        product.PriceWithDiscount = (price - discountAmount).ToMoney();
                    }
                }

               

                return product;
            }

        public List<ProductQueryModel> Search(string value)
        {
            var inventory = _inventoryContext.Inventory
                 .Select(x => new { x.ProductId, x.UnitPrice }).ToList();
            var discounts = _discountContext.customerDiscounts
                .Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                .Select(x => new { x.DiscountRate, x.ProductId, x.EndDate }).ToList();
            var query = _context.products                
                .Include(x => x.Category)
                .Select(x => new ProductQueryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Category=x.Category.Name,                   
                    Picture=x.Picture,
                    PictureAlt=x.PictureAlt,
                    PictureTitle=x.PictureTitle,
                    Slug = x.Slug,
                    
                }).AsNoTracking();
            if (!string.IsNullOrWhiteSpace(value))
            {
                query = query.Where(x => x.Name.Contains(value));
            }
            var products = query.OrderByDescending(x=>x.Id).ToList();

            foreach (var product in products)
            {
                var productInventory = inventory.FirstOrDefault(x => x.ProductId == product.Id);
                if (productInventory != null)
                {
                    var price = productInventory.UnitPrice;
                    product.Price = price.ToMoney();
                    var discount = discounts.FirstOrDefault(x => x.ProductId == product.Id);
                    if (discount != null)
                    {
                        int discountRate = discount.DiscountRate;
                        product.DiscountRate = discountRate;
                        product.DiscountExpireDate = discount.EndDate.ToDiscountFormat();
                        product.HasDiscount = discountRate > 0;
                        var discountAmount = Math.Round((price * discountRate) / 100);
                        product.PriceWhitDiscount = (price - discountAmount).ToMoney();
                    }
                }

            }

            return products;
        }
        private static List<ProductPictureQueryModel> MapProductPictures(List<ProductPicture> pictures)
        {
            return pictures.Select(x => new ProductPictureQueryModel
            {
                IsRemoved = x.IsRemoved,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ProductId = x.ProductId
            }).Where(x => !x.IsRemoved).ToList();
        }
         private static List<CommentQueryModel> MapComments(List<Comment> comments)
        {
            return comments
                .Where(x => !x.IsCanceled)
                .Where(x => !x.IsConfirmed)
                .Select(x => new CommentQueryModel
                {
                    Id = x.Id,
                    Message = x.Message,
                    Name=x.Name,
                }).OrderByDescending(x=>x.Id).ToList();
        }
    }
}
