﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_LampShadeQuery.Contracts.Inventory
{
    public interface IInventoryQuery
    {
        StockStatus CheckStock(IsInStock command);
    }
}
