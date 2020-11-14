namespace CyberWars.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using CyberWars.Services.Data.Market;
    using CyberWars.Web.ViewModels.HomeViews.Pet;
    using CyberWars.Web.ViewModels.Market;
    using Microsoft.AspNetCore.Mvc;

    public class MarketController : Controller
    {
        private readonly IMarketService marketService;

        public MarketController(IMarketService marketService)
        {
            this.marketService = marketService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public async Task<IActionResult> Animals()
        {
            var viewModel = await this.marketService.GetAllPets<MarketPetViewModel>();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Animals(int petId,string nameIt)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            await this.marketService.BuyPet(petId, userId,nameIt);

            return this.Redirect("/Home/Pets");
        }

        public async Task<IActionResult> Food()
        {
            var viewModel = await this.marketService.GetAllFood<MarketFoodViewModel>();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Food(int foodId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            await this.marketService.BuyFood(foodId, userId);

            return this.Redirect("/Home/Pets");
        }
    }
}
