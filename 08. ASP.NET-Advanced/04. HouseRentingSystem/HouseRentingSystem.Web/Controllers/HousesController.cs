﻿using HouseRentingSystem.Web.Models.Houses;
using HouseRentingSystem.Web.Infrastructure;
using HouseRentingSystem.Services.Agents;
using HouseRentingSystem.Services.Houses;
using HouseRentingSystem.Services.Houses.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;

namespace HouseRentingSystem.Web.Controllers
{
    public class HousesController : Controller
    {
        private readonly IHouseService houses;
        private readonly IAgentService agents;
        private readonly IMapper mapper;

        public HousesController(IHouseService houses, 
            IAgentService agents,
            IMapper mapper)
        {
            this.houses = houses;
            this.agents = agents;
            this.mapper = mapper;
        }

        public IActionResult All([FromQuery] AllHousesQueryModel query)
        {
            var queryResult = this.houses.All(
                query.Category,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                AllHousesQueryModel.HousesPerPage);

            query.TotalHousesCount = queryResult.TotalHousesCount;
            query.Houses = queryResult.Houses;

            var houseCategories = this.houses.AllCategoriesNames();
            query.Categories = houseCategories;

            return View(query);
        }

        [Authorize]
        public IActionResult Mine()
        {
            IEnumerable<HouseServiceModel> myHouses = null;

            var userId = this.User.Id();

            if (this.agents.ExistsById(userId))
            {
                var currentAgentId = this.agents.GetAgentId(userId);

                myHouses = this.houses.AllHousesByAgentId(currentAgentId);
            }
            else
            {
                myHouses = this.houses.AllHousesByUserId(userId);
            }

            return View(myHouses);
        }

        public IActionResult Details(int id, string information)
        {
            if (!this.houses.Exists(id))
            {
                return BadRequest();
            }

            var houseModel = this.houses.HouseDetailsById(id);

            if (information != houseModel.GetInformation())
            {
                return BadRequest();
            }

            return View(houseModel);
        }
    }
}
