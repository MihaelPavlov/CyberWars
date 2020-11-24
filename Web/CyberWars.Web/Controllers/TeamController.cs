namespace CyberWars.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using CyberWars.Services.Data.Team;
    using CyberWars.Web.ViewModels.Team;
    using Microsoft.AspNetCore.Mvc;

    public class TeamController : Controller
    {
        private readonly ITeamService teamService;

        public TeamController(ITeamService teamService)
        {
            this.teamService = teamService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = await this.teamService.Get10RandomTeam<TeamViewModel>();
            return this.View(viewModel);
        }

        public IActionResult Ranking()
        {
            return this.View();
        }

        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterTeamInputModel input)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            //if (this.ModelState.IsValid)
            //{

            //}
            await this.teamService.CreateTeam(userId, input.Name, input.MotivationalMotto, input.Description);

            return this.Redirect("/Home/Index");
        }

        public async Task<IActionResult> ApplyToTeam(int teamId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await this.teamService.ApplyToTeam(userId, teamId);
            return this.Redirect("/Home/Index");
        }
    }
}
