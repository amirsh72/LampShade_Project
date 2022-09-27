using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Contracts.Inventory
{
    public partial class CreateInventory
    {
        [Range(1,100000,ErrorMessage = ValidationMessages.IsRequierd)]
        public long ProductId { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = ValidationMessages.IsRequierd)]
        public double UnitPrice { get; set; }
    }
}
