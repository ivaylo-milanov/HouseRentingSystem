namespace HouseRentingSystem.Web.Controllers
{
    using HouseRentingSystem.Services.Data.Contracts;
    using HouseRentingSystem.Web.Infrastructure.Extensions;
    using HouseRentingSystem.Web.ViewModels.Agent;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class AgentsController : Controller
    {
        private readonly IAgentService agentService;

        public AgentsController(IAgentService agentService)
        {
            this.agentService = agentService;
        }

        public async Task<IActionResult> Become()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeAgentFormModel model)
        {
            if (await this.agentService.ExistsById(User.GetId()))
            {
                return BadRequest();
            }

            if (await this.agentService.UserWithPhoneNumberExists(model.PhoneNumber))
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), "Phone number already exists. Enter another one.");
            }

            if (await this.agentService.UserHasRents(User.GetId()))
            {
                ModelState.AddModelError("Error", "You should have no rents to become agent!");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await this.agentService.Create(User.GetId(), model.PhoneNumber);
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction(nameof(HousesController.All), "Houses");
        }
    }
}
