using HouseRentingSystem.Services.Houses.Models;

namespace HouseRentingSystem.Services.Houses
{
    public interface IHouseService
    {
        HouseQueryServiceModel All(
              string category = null,
              string searchTerm = null,
              HouseSorting sorting = HouseSorting.Newest,
              int currentPage = 1,
              int housesPerPage = 1);

        IEnumerable<HouseIndexServiceModel> LastThreeHouses();

        IEnumerable<string> AllCategoriesNames();
    }
}
