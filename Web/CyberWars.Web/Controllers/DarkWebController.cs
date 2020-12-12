namespace CyberWars.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using CyberWars.Common;
    using CyberWars.Services.Data.DarkWeb;
    using CyberWars.Web.ViewModels.DarkWeb;
    using CyberWars.Web.ViewModels.HomeViews;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.UserRoleName)]
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
            var viewModel = new PlayerDataView();

            // Need to be Error
            if (input.Type == null)
            {
                return this.Redirect("/DarkWeb/Attack");
            }

            if (input.Type == "Normal")
            {
                viewModel = await this.darkWebService.FindNormalEnemy(userId);
            }

            if (input.Type == "Stronger")
            {
                viewModel = await this.darkWebService.FindStrongerEnemy(userId);
            }

            if (input.Type == "Search")
            {
                // Need to be Error
                if (input.SearchName == null)
                {
                    return this.Redirect("/DarkWeb/Attack");
                }

                viewModel = await this.darkWebService.FindEnemyByName(userId, input.SearchName);

            }

            // Need to be Error
            if (viewModel == null)
            {
                return this.Redirect("/DarkWeb/Attack");
            }

            return this.View(viewModel);
        }

        public async Task<IActionResult> Result(string defencePlayerId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var viewModel = await this.darkWebService.ResultFromBattle(userId, defencePlayerId);
            if (viewModel == null)
            {
                return this.Redirect("/DarkWeb/Attack");
            }
            return this.View(viewModel);
        }
    }
}
