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

        public IEnumerable<HouseIndexServiceModel> LastThreeHouses()
          => this.data
              .Houses
              .OrderByDescending(c => c.Id)
              .ProjectTo<HouseIndexServiceModel>(this.mapper.ConfigurationProvider)
              .Take(3);
    }
}
