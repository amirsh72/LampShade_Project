﻿using System.Collections.Generic;

using InventoryManagement.Application.Contracts.Inventory;
using Microsoft.AspNetCore.Mvc;
using _01_LampShadeQuery.Contracts.Inventory;

namespace InventoryManagement.Presentation.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        
        private readonly IInventoryApplication _inventoryApplication;
        private readonly IInventoryQuery _inventoryQuery;

        public InventoryController(IInventoryApplication inventoryApplication, IInventoryQuery inventoryQuery)
        {

            _inventoryApplication = inventoryApplication;
            _inventoryQuery = inventoryQuery;
        }

        [HttpGet("{id}")]
        public List<InventoryOperationViewModel> GetOperationsBy(long id)
        {
            return _inventoryApplication.GetOperationlog(id);
        }
        [HttpPost]
        public StockStatus CheckStock(IsInStock command)
        {
           return _inventoryQuery.CheckStock(command);
        }
       
    }
}