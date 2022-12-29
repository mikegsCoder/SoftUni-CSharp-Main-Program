using HouseRentingSystem.Services.Houses.Models;

namespace HouseRentingSystem.Services.Houses
{
    public interface IHouseService
    {
        IEnumerable<HouseIndexServiceModel> LastThreeHouses();
    }
}
