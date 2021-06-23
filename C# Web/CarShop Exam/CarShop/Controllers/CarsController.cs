using CarShop.Models.Cars;
using CarShop.Services;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Controllers
{
    public class CarsController : Controller
    {
        private readonly IValidator validator;
        private readonly ICarsService carsService;
        private readonly IUserService userService;
        public CarsController(IValidator validator, ICarsService carsService, IUserService userService)
        {
            this.carsService = carsService;
            this.userService = userService;
            this.validator = validator;
        }

        [Authorize]
        public HttpResponse All()
        {
            bool isMechanic = userService.IsMechanic(this.User.Id);
            var carList = carsService.GetAllCars(this.User.Id, isMechanic);
            return this.View(carList);
        }

        [Authorize]
        public HttpResponse Add()
        {
            if (this.userService.IsMechanic(this.User.Id))
            {
                return Error("You have not permission to Add new cars.");
            }
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Add(CarsAddFormModel model)
        {
           
            var modelErrors = validator.ValidateCar(model);
            
            if (modelErrors == null)
            {
                return Error(modelErrors);
            }

            carsService.AddCar(model, this.User.Id);

            return this.Redirect("/Cars/All");
        }
    }
}
