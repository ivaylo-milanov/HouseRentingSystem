namespace HouseRentingSystem.Web.Controllers
{
    using HouseRentingSystem.Web.ViewModels.Agent;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class AgentsController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Become(BecomeAgentFormModel model)
        {
            return RedirectToAction(nameof(HousesController.All), "Houses");
        }
    }
}
