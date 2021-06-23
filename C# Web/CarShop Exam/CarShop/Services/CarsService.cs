using CarShop.Data;
using CarShop.Data.Models;
using CarShop.Models.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services
{
    public class CarsService : ICarsService
    {
        private readonly CarShopDbContext db;
        public CarsService(CarShopDbContext db)
        {
            this.db = db;
        }

        public void AddCar(CarsAddFormModel model, string ownerId)
        {
            var newCar = new Car
            {
                Model = model.Model,
                Year = model.Year,
                PlateNumber = model.PlateNumber,
                OwnerId = ownerId,
                PictureUrl = model.Image
            };

            this.db.Cars.Add(newCar);
            this.db.SaveChanges();
        }

        public ICollection<CarsAllViewModel> GetAllCars(string userId, bool IsMechanic)
        {
            var carsList = new List<CarsAllViewModel>();
            if (IsMechanic)
            {
                carsList = db.Cars
                    .Where(c=>c.Issues.Any(x=>!x.IsFixed))
                           .Select(c => new CarsAllViewModel
                           {
                               Id = c.Id,
                               Model = c.Id,
                               Year = c.Year,
                               PlateNumber = c.PlateNumber,
                               FixedIssues = c.Issues.Where(x => x.IsFixed).Count(),
                               RemainingIssues = c.Issues.Where(x => x.IsFixed == false).Count(),
                               PictureUrl = c.PictureUrl
                           })
             .ToList();
                
            }
            else
            {
                carsList = db.Cars
                             .Where(c => c.OwnerId == userId)
                             .Select(c => new CarsAllViewModel
                             {
                                 Id = c.Id,
                                 Model = c.Id,
                                 Year = c.Year,
                                 PlateNumber = c.PlateNumber,
                                 FixedIssues = c.Issues.Where(x => x.IsFixed).Count(),
                                 RemainingIssues = c.Issues.Where(x => !x.IsFixed).Count(),
                                 PictureUrl = c.PictureUrl
                             })
                             .ToList();
            }

            return carsList;
        }


    }
}
