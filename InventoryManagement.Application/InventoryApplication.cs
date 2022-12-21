using _0_Framework.Application;
using InventoryManagement.Application.Contracts.Inventory;
using InventoryManagement.Domain;
using InventoryManagement.Domain.InventoryAgg;
using System;
using System.Collections.Generic;

namespace InventoryManagement.Application
{
    public class InventoryApplication:IInventoryApplication
    {
        private readonly IAuthHelper _authHelper;
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryApplication(IInventoryRepository inventoryRepository, IAuthHelper authHelper)
        {
            _inventoryRepository = inventoryRepository;
            _authHelper = authHelper;
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

        public List<InventoryOperationViewModel> GetOperationlog(long inventoryId)
        {
            return _inventoryRepository.GetOperationlog(inventoryId);
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
            var operatorid = _authHelper.CurrentAccountId();
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
