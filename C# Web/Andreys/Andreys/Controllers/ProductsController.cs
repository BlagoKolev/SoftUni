using Andreys.Models.Products;
using Andreys.Services;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andreys.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService productService;
        private readonly IValidator validator;
        public ProductsController(IProductService productService, IValidator validator)
        {
            this.productService = productService;
            this.validator = validator;
        }

        [Authorize]
        public HttpResponse Add()
        {
            if (this.User.IsAuthenticated)
            {
                return this.View();
            }
            return Unauthorized();
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Add(AddProductsFormModel model)
        {
            var modelErrors = validator.ValidateProduct(model);
            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            var isAddSuccessfull = productService.AddProduct(model);

            if (isAddSuccessfull)
            {
                return this.Redirect("/");
            }

            return this.Redirect("/Products/Add");
        }

        [Authorize]
        public HttpResponse Details(int  Id)
        {
            var model = productService.GetDetails(Id);
            return this.View(model);
        }

        [Authorize]
        public HttpResponse Delete(int Id)
        {
            productService.DeleteProduct(Id);
            return this.Redirect("/Home/Home");
        }

    }
}
