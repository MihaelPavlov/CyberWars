namespace CyberWars.Web.Controllers
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using CyberWars.Common;
    using CyberWars.Services.Data.Market;
    using CyberWars.Web.ViewModels.Market;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Controller that handles requests that come from the Market.
    /// </summary>
    [Authorize(Roles = GlobalConstants.UserRoleName)]
    public class MarketController : Controller
    {
        private readonly IMarketService marketService;

        /// <summary>
        /// Constructor that instantiates Market controller.
        /// </summary>
        public MarketController(IMarketService marketService)
        {
            this.marketService = marketService ?? throw new ArgumentNullException(nameof(marketService));
        }

        /// <summary>
        /// Use this method to get index page of the market.
        /// </summary>
        [HttpGet] // GET /Market/Idnex
        public IActionResult Index()
        {
            return this.View();
        }

        /// <summary>
        /// Use this method to get and visualize all animals in the market.
        /// </summary>
        /// <returns></returns>
        [HttpGet] // GET /Market/Animals
        public async Task<IActionResult> Animals()
        {
            var viewModel = await this.marketService.GetAllPets<MarketPetViewModel>();
            return this.View(viewModel);
        }

        /// <summary>
        /// Use this method to get and visualize all food in the market.
        /// </summary>
        [HttpGet] // GET /Market/Food
        public async Task<IActionResult> Food()
        {
            var viewModel = await this.marketService.GetAllFood<MarketFoodViewModel>();
            return this.View(viewModel);
        }

        /// <summary>
        /// Use this method to buy pet.
        /// </summary>
        /// <param name="petId">A integer representing the pet Id.</param>
        /// <param name="nameIt">A string representing the name of the new pet.</param>
        [HttpPost] // GET /Market/Animals?petId={petId}&nameIt={nameIt}
        public async Task<IActionResult> Animals(int petId, string nameIt)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            await this.marketService.BuyPet(petId, userId, nameIt);

            return this.Redirect("/Home/Pets");
        }

        /// <summary>
        /// Use this method to buy food from the market.
        /// </summary>
        /// <param name="foodId">A interger representing the Id of the food that we want buy.</param>
        [HttpPost] // GET /Market/Animals?foodId={foodId}
        public async Task<IActionResult> Food(int foodId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            await this.marketService.BuyFood(foodId, userId);

            return this.Redirect("/Market/Food");
        }
    }
}
