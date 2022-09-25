﻿using _0_Framework.Infrastructure;
using InventoryManagement.Application.Contracts.Inventory;
using InventoryManagement.Domain;
using InventoryManagement.Domain.InventoryAgg;
using Microsoft.EntityFrameworkCore;
using ShopManagementInfrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure.EFCore.Repository
{
    public class InventoryRepository : RepositoryBase<long, Inventory>, IInventoryRepository
    {
        private readonly ShopContext _shopContext;
        private readonly InventoryContext _inventoryContext;
        public InventoryRepository(InventoryContext inventoryContext, ShopContext shopContext) : base(inventoryContext)
        {
            _shopContext = shopContext;
            _inventoryContext=inventoryContext;
        }

        public Inventory GetBy(long ProductId)
        {
          return  _inventoryContext.Inventory.FirstOrDefault(x=>x.ProductId == ProductId);
        }

        public EditInventory GetDetails(long id)
        {
            return _inventoryContext.Inventory.Select(x => new EditInventory
            {
                Id =x.Id,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice,
            }).FirstOrDefault();
        }

        public List<InventoryViewModel> Search(InventorySearchModel searchModel)
        {
            var products = _shopContext.products.Select(x => new { x.Id, x.Name }).ToList();
            var query = _inventoryContext.Inventory.Select(x => new InventoryViewModel
            {
                Id = x.Id,
                UnitPrice = x.UnitPrice,
                IsStock = x.InStock,
                ProductId = x.ProductId,
                CurrentCount=x.CalculateCurrentCount(),
            });
            if(searchModel.ProductId>0)
                query=query.Where(x=>x.ProductId==searchModel.ProductId);
            if(!searchModel.Instock)
                query=query.Where(x=>!x.IsStock);
            var inventory = query.OrderByDescending(x => x.Id).ToList();
            inventory.ForEach(item=>
            item.Product=products.FirstOrDefault(x=>x.Id==item.ProductId)?.Name);

            return null;
        }
    }
}