namespace HouseRentingSystem.Services.Data.Contracts
{
    using HouseRentingSystem.Web.ViewModels.House;

    public interface IHouseService
    {
        Task<IEnumerable<HouseIndexViewModel>> LastThreeHouses();
    }
}
