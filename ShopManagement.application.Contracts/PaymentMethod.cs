using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.application.Contracts
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        private PaymentMethod(int id, string name, string description)
        {

            Id = id;
            Name = name;
            Description = description;
        }
        public static List<PaymentMethod> GetList()
        {
            return new List<PaymentMethod>
            {
            new PaymentMethod(1,"پرداخت اینترنتی","پرداخت انلاین"),
            new PaymentMethod(2, "پرداخت نقدی", "پرداخت در محل"),
            };
        
        }
        public static PaymentMethod GetBy(long id)
        {
            return GetList().FirstOrDefault(x => x.Id == id);
        }
    }
}
