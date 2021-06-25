using Andreys.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andreys.Services
{
    public interface IProductService
    {
        bool AddProduct(AddProductsFormModel model);
        ProductDetailsViewModel GetDetails(int id);
        void DeleteProduct(int productId);
    }
}
