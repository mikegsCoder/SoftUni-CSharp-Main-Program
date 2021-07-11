using System;
using System.Collections.Generic;
using System.Text;

namespace P01Vehicles.Interfaces
{
    public interface IRefuelable
    {
        double TankCapacity { get; }
        void Refuel(double amount);
    }
}
