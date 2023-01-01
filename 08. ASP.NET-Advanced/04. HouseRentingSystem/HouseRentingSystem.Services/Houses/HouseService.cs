using System.Linq;
using System.Collections.Generic;
using HouseRentingSystem.Services.Data;
using HouseRentingSystem.Services.Data.Entities;
using HouseRentingSystem.Services.Houses.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Services.Houses
{
    public class HouseService : IHouseService
    {
        private readonly HouseRentingDbContext data;
        private readonly IMapper mapper;

        public HouseService(HouseRentingDbContext data,
            IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }

        public bool Exists(int id)
             => this.data.Houses.Any(h => h.Id == id);

        public HouseQueryServiceModel All(
           string category = null,
           string searchTerm = null,
           HouseSorting sorting = HouseSorting.Newest,
           int currentPage = 1,
           int housesPerPage = 1)
        {
            var housesQuery = this.data.Houses.AsQueryable();

            if (!string.IsNullOrWhiteSpace(category))
            {
                housesQuery = this.data.Houses
                    .Where(h => h.Category.Name == category);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                housesQuery = housesQuery.Where(h =>
                    h.Title.ToLower().Contains(searchTerm.ToLower()) ||
                    h.Address.ToLower().Contains(searchTerm.ToLower()) ||
                    h.Description.ToLower().Contains(searchTerm.ToLower()));
            }

            housesQuery = sorting switch
            {
                HouseSorting.Price => housesQuery
                    .OrderBy(h => h.PricePerMonth),
                HouseSorting.NotRentedFirst => housesQuery
                    .OrderBy(h => h.RenterId != null)
                    .ThenByDescending(h => h.Id),
                _ => housesQuery.OrderByDescending(h => h.Id)
            };

            var houses = housesQuery
                .Skip((currentPage - 1) * housesPerPage)
                .Take(housesPerPage)
                .ProjectTo<HouseServiceModel>(this.mapper.ConfigurationProvider)
                .ToList();

            var totalHouses = housesQuery.Count();

            return new HouseQueryServiceModel()
            {
                TotalHousesCount = totalHouses,
                Houses = houses
            };
        }

        public IEnumerable<HouseIndexServiceModel> LastThreeHouses()
          => this.data
              .Houses
              .OrderByDescending(c => c.Id)
              .ProjectTo<HouseIndexServiceModel>(this.mapper.ConfigurationProvider)
              .Take(3);

        public IEnumerable<string> AllCategoriesNames()
          => this.data
               .Categories
                  .Select(c => c.Name)
                  .Distinct()
                  .ToList();

        public bool HasAgentWithId(int houseId, string currentUserId)
        {
            var house = this.data.Houses.Find(houseId);
            var agent = this.data.Agents.FirstOrDefault(a => a.Id == house.AgentId);

            if (agent == null)
            {
                return false;
            }

            if (agent.UserId != currentUserId)
            {
                return false;
            }

            return true;
        }

        public bool IsRentedByUserWithId(int houseId, string userId)
        {
            var house = this.data.Houses.Find(houseId);

            if (house == null)
            {
                return false;
            }

            if (house.RenterId != userId)
            {
                return false;
            }

            return true;
        }

        public IEnumerable<HouseServiceModel> AllHousesByAgentId(int agentId)
        {
            var houses = this.data
                  .Houses
                  .Where(h => h.AgentId == agentId)
                  .ProjectTo<HouseServiceModel>(this.mapper.ConfigurationProvider)
                  .ToList();

            return houses;
        }

        public IEnumerable<HouseServiceModel> AllHousesByUserId(string userId)
        {
            var houses = this.data
                  .Houses
                  .Where(h => h.RenterId == userId)
                  .ProjectTo<HouseServiceModel>(this.mapper.ConfigurationProvider)
                  .ToList();

            return houses;
        }
    }
}
