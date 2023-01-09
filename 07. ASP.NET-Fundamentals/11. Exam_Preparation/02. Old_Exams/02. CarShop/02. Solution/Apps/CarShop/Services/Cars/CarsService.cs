using CarShop.Data;
using CarShop.Data.Models;
using CarShop.ViewModels;
using System.Linq;

namespace CarShop.Services.Cars
{
    public class CarsService : ICarsService
    {
        private readonly ApplicationDbContext db;

        public CarsService(ApplicationDbContext db)
        {
            this.db = db;
        }
    }
}
