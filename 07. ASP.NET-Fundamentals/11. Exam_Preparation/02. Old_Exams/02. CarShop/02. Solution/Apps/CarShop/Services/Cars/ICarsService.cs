﻿using CarShop.ViewModels;
using CarShop.ViewModels.Cars;

namespace CarShop.Services.Cars
{
    public interface ICarsService
    {
        AllCarsViewModel GetAllCars(string userId);

        AllCarsViewModel GetAllCarsForMechanics();

        public void AddCar(string userId, CarInputModel inputModel);
    }
}
