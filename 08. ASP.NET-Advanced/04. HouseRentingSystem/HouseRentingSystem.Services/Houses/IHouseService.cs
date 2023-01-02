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

        bool HasAgentWithId(int houseId, string currentUserId);

        bool IsRentedByUserWithId(int houseId, string userId);

        IEnumerable<HouseServiceModel> AllHousesByAgentId(int agentId);

        IEnumerable<HouseServiceModel> AllHousesByUserId(string userId);

        bool Exists(int id);

        HouseDetailsServiceModel HouseDetailsById(int id);

        IEnumerable<HouseCategoryServiceModel> AllCategories();

        bool CategoryExists(int categoryId);

        int Create(string title, string address,
           string description, string imageUrl, decimal price,
           int categoryId, int agentId);

        int GetHouseCategoryId(int houseId);
    }
}
