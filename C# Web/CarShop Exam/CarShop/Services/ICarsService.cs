using CarShop.Models.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services
{
    public interface ICarsService
    {
        ICollection<CarsAllViewModel> GetAllCars(string id, bool IsMechanic);
        void AddCar(CarsAddFormModel model,string ownerId);
    }
}
