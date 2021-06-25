using Andreys.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andreys.Services
{
    public interface IHomeService
    {
        ICollection<HomeViewModel> GetAllProducts();
    }
}
