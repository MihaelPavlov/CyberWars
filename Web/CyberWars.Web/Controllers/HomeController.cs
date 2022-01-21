namespace CyberWars.Web.Controllers
{
    using System;
    using System.Diagnostics;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using CyberWars.Common;
    using CyberWars.Services.Data.Home;
    using CyberWars.Web.ViewModels;
    using CyberWars.Web.ViewModels.HomeViews;
    using CyberWars.Web.ViewModels.HomeViews.Pet;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Controller that handles requests that come from the Home page.
    /// </summary>
    [Authorize(Roles = GlobalConstants.UserRoleName)]
    public class HomeController : Controller
    {
        private readonly IHomeService homeService;

        /// <summary>
        /// Constructor that instantiates Home controller.
        /// </summary>
        public HomeController(IHomeService homeService)
        {
            this.homeService = homeService ?? throw new ArgumentNullException(nameof(homeService));
        }

        /// <summary>
        /// Use this method to vusialize index page of the Home.
        /// </summary>
        [HttpGet] // GET /Home/Index
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var viewModelPlayer = await this.homeService.GetPlayerData(userId);

            return this.View(viewModelPlayer);
        }

        /// <summary>
        /// Use this method to vusialize skills page.
        /// </summary>
        [HttpGet] // GET /Home/Skills
        public async Task<IActionResult> Skills()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var viewModel = await this.homeService.GetPlayerSkills<PlayerSkillViewModel>(userId);

            return this.View(viewModel);
        }

        /// <summary>
        /// Use this method to train one skill.
        /// </summary>
        /// <param name="skillName">A string that contains the name of the skill.</param>
        [HttpPost] // POST /Home/TrainSkill?skillName={skillName}
        public async Task<IActionResult> TrainSkill(string skillName)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            await this.homeService.TrainSkillByName(userId, skillName);

            return this.Redirect("/Home/Skills");
        }

        /// <summary>
        /// Use this method to get all Abilities.
        /// </summary>
        /// <param name="type">A string that contains type of the abilities.</param>
        [HttpGet] // GET /Home/Abilities?type={type}
        public async Task<IActionResult> Abilities(string type)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await this.homeService.GetUserById(userId);

            var viewModel = await this.homeService.GetPlayerAbilitiesByType<PlayerAbilitiesViewModel>(user.PlayerId, type);
            return this.View(viewModel);
        }

        /// <summary>
        /// Use this method to get all badges.
        /// </summary>
        [HttpGet] // GET /Home/Badges
        public async Task<IActionResult> Badges()
        {
            var viewModel = await this.homeService.GetAllBadges<BadgesViewModel>();
            return this.View(viewModel);
        }

        /// <summary>
        /// Use this method to vusialize all badge requirements by selected badge.
        /// </summary>
        /// <param name="badgeId">A string that contains which badge requirements will vusialize.</param>
        [HttpGet] // GET /Home/BadgeRequirements?badgeId={badgeId}
        public async Task<IActionResult> BadgeRequirements(int badgeId)
        {
            var viewModel = await this.homeService.GetAllRequirementForBadgeById(badgeId);
            return this.View(viewModel);
        }

        /// <summary>
        /// Use this method to get all pets that currently login user have.
        /// </summary>
        [HttpGet] // GET /Home/Pets
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

        /// <summary>
        /// Use this method to get pet by Id and see pet stats.
        /// </summary>
        /// <param name="petId">A string that contains pet Id.</param>
        [HttpGet] // GET /Home/PetCard?petId={petId}
        public async Task<IActionResult> PetCard(int petId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var viewModel = await this.homeService.GetPetById(userId, petId);

            return this.View(viewModel);
        }

        /// <summary>
        /// Use this method to feed the pet by Id.
        /// </summary>
        /// <param name="foodId">A string that contains food Id.</param>
        /// <param name="petId">A string that contains pet Id.</param>
        [HttpPost] // POST /Home/PetCard?foodId={foodId}&petId={petId}
        public async Task<IActionResult> PetCard(int foodId, int petId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            await this.homeService.FeedPetById(foodId, petId, userId);
            return this.Redirect($"/Home/PetCard?petId={petId}");
        }

        /// <summary>
        /// Use this method to change the name of pet.
        /// </summary>
        /// <param name="newName">A string that contains the new name of the pet.</param>
        /// <param name="petId">A string that contains pet Id.</param>
        [HttpPost] // POST /Home/ChangeName?newName={newName}&petId={petId}
        public async Task<IActionResult> ChangeName(string newName, int petId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            await this.homeService.ChangePetName(newName, petId, userId);

            return this.Redirect($"/Home/PetCard?petId={petId}");
        }

        /// <summary>
        /// Use this method to scratch pet belly.
        /// </summary>
        /// <param name="petId">A string that contains pet Id.</param>
        [HttpPost] // POST /Home/ScratchPetBelly?petId={petId}
        public async Task<IActionResult> ScratchPetBelly(int petId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            await this.homeService.ScratchPetBelly(petId, userId);
            System.Threading.Thread.Sleep(2000);

            return this.Redirect($"/Home/PetCard?petId={petId}");
        }

        /// <summary>
        /// Use this method to sell pet by Id.
        /// </summary>
        /// <param name="petId">A string that contains pet Id.</param>
        /// <returns></returns>
        [HttpPost] // POST /Home/SellPet?petId={petId}
        public async Task<IActionResult> SellPet(int petId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            await this.homeService.SellPetById(petId, userId);

            return this.Redirect("/Home/Pets");
        }

        /// <summary>
        /// Use this method to see player view with stats.
        /// </summary>
        /// <param name="playerName">A string that contains the name of the player we want to see.</param>
        [HttpGet] // GET /Home/PlayerView?playerName={playerName}
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
