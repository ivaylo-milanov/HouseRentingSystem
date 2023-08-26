namespace HouseRentingSystem.Web.Controllers
{
    using HouseRentingSystem.Web.ViewModels.House;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class HousesController : Controller
    {
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            return View(new AllHousesViewModel());
        }

        public async Task<IActionResult> Mine()
        {
            return View(new MineHousesViewModel());
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details()
        {
            return View(new HouseDetailsViewModel());
        }

        public async Task<IActionResult> Add()
        {
            return View(new HouseAddFormModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(HouseAddFormModel model)
        {
            return View(model);
        }

        public async Task<IActionResult> Edit()
        {
            return View(new HouseEditFormModel());
        }

        [HttpPost]
        public async Task<IActionResult> Edit(HouseEditFormModel model)
        {
            return View(model);
        }

        public async Task<IActionResult> Delete()
        {
            return View(new HouseDeleteFormModel());
        }

        [HttpPost]
        public async Task<IActionResult> Delete(HouseDeleteFormModel model)
        {
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Rent()
        {
            return RedirectToAction(nameof(Mine));
        }

        [HttpPost]
        public async Task<IActionResult> Leave()
        {
            return RedirectToAction(nameof(Mine));
        }
    }
}