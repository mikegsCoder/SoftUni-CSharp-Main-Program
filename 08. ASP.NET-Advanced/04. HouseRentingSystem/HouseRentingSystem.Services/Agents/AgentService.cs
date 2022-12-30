using HouseRentingSystem.Services.Data;
using HouseRentingSystem.Services.Data.Entities;

namespace HouseRentingSystem.Services.Agents
{
    public class AgentService : IAgentService 
    {
        private readonly HouseRentingDbContext data;

        public AgentService(HouseRentingDbContext data)
           => this.data = data;


        public bool ExistsById(string userId)
            => this.data.Agents.Any(a => a.UserId == userId);

    }
}
