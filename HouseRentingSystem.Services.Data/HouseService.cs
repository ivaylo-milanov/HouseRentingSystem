namespace HouseRentingSystem.Services.Data
{
    using HouseRentingSystem.Data;
    using HouseRentingSystem.Services.Data.Contracts;
    using HouseRentingSystem.Web.ViewModels.House;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class HouseService : IHouseService
    {
        private readonly HouseRentingDbContext context;

        public HouseService(HouseRentingDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<HouseIndexViewModel>> LastThreeHouses()
            => await this.context.Houses
                .OrderByDescending(h => h.CreatedOn)
                .Select(h => new HouseIndexViewModel
                {
                    Id = h.Id.ToString(),
                    Title = h.Title,
                    ImageUrl = h.ImageUrl
                })
                .ToListAsync();
    }
}
