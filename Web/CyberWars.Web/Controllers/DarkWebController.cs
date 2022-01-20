namespace CyberWars.Web.Controllers
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using CyberWars.Common;
    using CyberWars.Services.Data.DarkWeb;
    using CyberWars.Web.ViewModels.DarkWeb;
    using CyberWars.Web.ViewModels.HomeViews;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Controller that handles requests that come from the DarkWeb.
    /// </summary>
    [Authorize(Roles = GlobalConstants.UserRoleName)]
    public class DarkWebController : Controller
    {
        private readonly IDarkWebService darkWebService;

        /// <summary>
        /// Constructor that instantiates DarkWeb controller.
        /// </summary>
        /// <param name="darkWebService"></param>
        public DarkWebController(IDarkWebService darkWebService)
        {
            this.darkWebService = darkWebService ?? throw new ArgumentNullException(nameof(darkWebService));
        }

        [HttpGet] // GET /DarkWeb/Attack
        public IActionResult Attack()
        {
            return this.View();
        }

        /// <summary>
        /// Use this method to start searching for the player that u want to fight.
        /// </summary>
        /// <param name="input">A input model <see cref="TypeOfAttackInputModel"/>.</param>
        [HttpGet] // GET /DarkWeb/Search?type={type}&searchName={searchName}&choise={choise}
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
                viewModel = await this.darkWebService.FindNormalEnemy(userId, "Normal");
            }

            if (input.Type == "Stronger")
            {
                viewModel = await this.darkWebService.FindStrongerEnemy(userId, "Stronger");
            }

            if (input.Type == "Search")
            {
                // Need to be Error
                if (input.SearchName == null)
                {
                    return this.Redirect("/DarkWeb/Attack");
                }

                viewModel = await this.darkWebService.FindEnemyByName(userId, input.SearchName, "Normal");
            }

            // Need to be Error
            if (viewModel == null)
            {
                return this.Redirect("/DarkWeb/Attack");
            }

            return this.View(viewModel);
        }

        // TODO: Seprate the logics of the method.Result from the fight and start fight.
        /// <summary>
        /// Use this method to start a fight and show the result from the fight.
        /// </summary>
        /// <param name="defencePlayerId">A string that contains defence player Id.</param>
        [HttpPost] // POST /DarkWeb/Result?defencePlayerId={defencePlayerId}
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
