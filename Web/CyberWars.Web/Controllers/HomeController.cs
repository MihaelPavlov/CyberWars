namespace CyberWars.Web.Controllers
{
    using System.Diagnostics;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    using CyberWars.Common;
    using CyberWars.Data.Common.Repositories;
    using CyberWars.Data.Models;
    using CyberWars.Data.Models.Pet_Food;
    using CyberWars.Data.Models.Player;
    using CyberWars.Data.Models.Skills;
    using CyberWars.Services.Data.Home;
    using CyberWars.Services.Messaging;
    using CyberWars.Web.ViewModels;
    using CyberWars.Web.ViewModels.HomeViews;
    using CyberWars.Web.ViewModels.HomeViews.Pet;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [Authorize(Roles = GlobalConstants.UserRoleName)]
    public class HomeController : Controller
    {
        private readonly IHomeService homeService;

        public HomeController(IHomeService homeService)
        {
            this.homeService = homeService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var viewModelPlayer = await this.homeService.GetPlayerData(userId);
            return this.View(viewModelPlayer);
        }

        public async Task<IActionResult> Skills()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var viewModel = await this.homeService.GetPlayerSkills<PlayerSkillViewModel>(userId);

            return this.View(viewModel);
        }

        public async Task<IActionResult> TrainSkill(string skillName)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            await this.homeService.TrainSkillByName(userId, skillName);

            return this.Redirect("/Home/Skills");
        }

        public async Task<IActionResult> Abilities(string type)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await this.homeService.GetUserById(userId);

            var viewModel = await this.homeService.GetPlayerAbilitiesByType<PlayerAbilitiesViewModel>(user.PlayerId, type);
            return this.View(viewModel);
        }

        public async Task<IActionResult> Badges()
        {
            var viewModel = await this.homeService.GetAllBadges<BadgesViewModel>();
            return this.View(viewModel);
        }

        public async Task<IActionResult> BadgeRequirements(int badgeId)
        {
            var viewModel = await this.homeService.GetAllRequirementForBadgeById(badgeId);
            return this.View(viewModel);
        }

        public async Task<IActionResult> Pets()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var viewModel = await this.homeService.GetPlayerPets<PetViewModel>(userId);

            // Give pet Random food Every day
            foreach (var pet in viewModel)
            {
                pet.Foods = await this.homeService.GetPetRandomFood<FoodViewModel>(pet.PetId);
            }

            return this.View(viewModel);
        }

        public async Task<IActionResult> PetCard(int petId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var viewModel = await this.homeService.GetPetById(userId, petId);

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> PetCard(int foodId, int petId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            await this.homeService.FeedPetById(foodId, petId, userId);
            return this.Redirect($"/Home/PetCard?petId={petId}");
        }

        [HttpPost]
        public async Task<IActionResult> ChangeName(string newName, int petId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            await this.homeService.ChangePetName(newName, petId, userId);

            return this.Redirect($"/Home/PetCard?petId={petId}");
        }

        [HttpPost]
        public async Task<IActionResult> ScratchPetBelly(int petId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            await this.homeService.ScratchPetBelly(petId, userId);
            System.Threading.Thread.Sleep(2000);

            return this.Redirect($"/Home/PetCard?petId={petId}");
        }

        [HttpPost]
        public async Task<IActionResult> SellPet(int petId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            await this.homeService.SellPetById(petId, userId);

            return this.Redirect("/Home/Pets");
        }

        public async Task<IActionResult> PlayerView(string playerName)
        {
            var viewModel = await this.homeService.GetPlayerViewData(playerName);
            if (viewModel == null)
            {
                return this.Redirect("/Home/Index");
            }
            return this.View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
