﻿using _0_Framework.Application;
using InventoryManagement.Application.Contracts.Inventory;
using InventoryManagement.Domain;
using InventoryManagement.Domain.InventoryAgg;
using System;
using System.Collections.Generic;

namespace InventoryManagement.Application
{
    public class InventoryApplication:IInventoryApplication
    {
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryApplication(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public OperationResult Create(CreateInventory command)
        {
           var operation=new OperationResult();
            if(_inventoryRepository.Exists(x=>x.ProductId==command.ProductId))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);
            var inventory = new Inventory(command.ProductId, command.UnitPrice);
            _inventoryRepository.Create(inventory);
            _inventoryRepository.SaveChange();
            return operation.Succedded();
        }

        public OperationResult Edit(EditInventory command)
        {
            var operation = new OperationResult();
            var inventory = _inventoryRepository.Get(command.Id);
            if(inventory==null)
                return operation.Failed(ApplicationMessage.RecordNotFound);
            if(_inventoryRepository.Exists(x=>x.ProductId==command.ProductId && x.Id!=command.Id))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);
            inventory.Edit(command.ProductId,command.UnitPrice);
            _inventoryRepository.SaveChange();
            return operation.Succedded();

        }

        public EditInventory GetDetails(long id)
        {
           return _inventoryRepository.GetDetails(id);
        }

        public OperationResult Increase(IncreaseInventory command)
        {
            var operation = new OperationResult();
            var inventory = _inventoryRepository.Get(command.InventoryId);
            if(inventory== null)
                return operation.Failed(ApplicationMessage.RecordNotFound);
            const long operatorid = 1;
            inventory.Increase(command.Count,operatorid,command.Description);
            _inventoryRepository.SaveChange();
            return operation.Succedded();

        }

        public OperationResult Reduse(ReduceInventory command)
        {
            var operation = new OperationResult();
            var inventory = _inventoryRepository.Get(command.InventoryId);
            if (inventory == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);
            const long operatorid = 1;
            inventory.Reduce(command.Count, operatorid, command.Description,0);
            _inventoryRepository.SaveChange();
            return operation.Succedded();
        }

        public OperationResult Reduse(List<ReduceInventory> command)
        {
           var operation=new OperationResult();
            const long operatorid = 1;
            foreach (var item in command)
            {
                var inventory=_inventoryRepository.GetBy(item.ProductId);
                inventory.Reduce(item.Count,operatorid,item.Description,item.OrderId);
            }
            _inventoryRepository.SaveChange();
            return operation.Succedded();
        }

        public List<InventoryViewModel> Search(InventorySearchModel searchModel)
        {
           return _inventoryRepository.Search(searchModel);
        }
    }
}
