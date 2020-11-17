namespace CyberWars.Web.Controllers
{
    using CyberWars.Services.Data.DarkWeb;
    using CyberWars.Web.ViewModels.DarkWeb;
    using CyberWars.Web.ViewModels.HomeViews;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class DarkWebController : Controller
    {
        private readonly IDarkWebService darkWebService;

        public DarkWebController(IDarkWebService darkWebService)
        {
            this.darkWebService = darkWebService;
        }

        public IActionResult Attack()
        {
            return this.View();
        }

        public async Task<IActionResult> Search(TypeOfAttackInputModel input)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var viewModel = await this.darkWebService.FindNormalEnemy(input.Type, userId);

            return this.View(viewModel);
        }

        public IActionResult Result()
        {
            return this.View();
        }
    }
}
