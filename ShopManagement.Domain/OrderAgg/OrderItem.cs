using _0_Framework.Domain;

namespace ShopManagement.Domain.OrderAgg
{
    public class OrderItem:EntityBase
    {
   

        public long ProdouctId { get;private set; }
        public int Count { get; private set; }
        public double UnitPrice { get; private set; }
        public int DiscountRate { get; private set; }
        public long OrderId { get; private set; }
        public Order Order { get; private set; }
        public OrderItem(long prodouctId, int count, double unitPrice, int discountRate)
        {
            ProdouctId = prodouctId;
            Count = count;
            UnitPrice = unitPrice;
            DiscountRate = discountRate;

        }


    }
}
