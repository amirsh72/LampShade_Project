using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_LampShadeQuery.Contracts.Product
{
    public interface IProductQuery
    {
        ProductQueryModel GetProductDetails(string id);
        List<ProductQueryModel> GetLatestArrivals();
        List<ProductQueryModel> Search(string value);
        
    }
}
