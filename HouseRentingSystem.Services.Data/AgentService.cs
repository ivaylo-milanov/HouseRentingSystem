namespace HouseRentingSystem.Services.Data
{
    using HouseRentingSystem.Data;
    using HouseRentingSystem.Data.Models;
    using HouseRentingSystem.Services.Data.Contracts;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class AgentService : IAgentService
    {
        private readonly HouseRentingDbContext context;

        public AgentService(HouseRentingDbContext context)
        {
            this.context = context;
        }

        public async Task Create(string userId, string phoneNumber)
        {
            Agent agent = new Agent
            {
                UserId = Guid.Parse(userId),
                PhoneNumber = phoneNumber
            };

            await this.context.AddAsync(agent);
            await this.context.SaveChangesAsync();
        }

        public async Task<bool> ExistsById(string userId)
            => await this.context.Agents.AnyAsync(a => a.UserId.ToString() == userId);

        public async Task<bool> UserHasRents(string userId)
            => await this.context.Houses.AnyAsync(h => h.RenterId.ToString() == userId);

        public async Task<bool> UserWithPhoneNumberExists(string phoneNumber)
            => await this.context.Agents.AnyAsync(a => a.PhoneNumber == phoneNumber);
    }
}
