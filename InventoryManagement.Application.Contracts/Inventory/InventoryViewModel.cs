﻿namespace InventoryManagement.Application.Contracts.Inventory
{

    public class InventoryViewModel
    {
        public long Id { get; set; }
        public string Product { get; set; }
        public long ProductId { get; set; }
        public double UnitPrice { get; set; }
        public bool IsStock { get; set; }
        public long CurrentCount { get; set; }
        public string CreatinDate { get; set; }

    }

}
