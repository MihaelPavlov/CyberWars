namespace CyberWars.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using CyberWars.Common;
    using CyberWars.Services.Data.Team;
    using CyberWars.Web.ViewModels.Team;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.UserRoleName)]
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

        public async Task<IActionResult> Ranking(int id = 1)
        {
            const int ItemsPerPage = 6;
            var viewModel = new TeamRankingListViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                Teams = await this.teamService.GetTeamRankingList<TeamRankingInList>(id, ItemsPerPage),
                TeamCount = await this.teamService.GetTeamCount(),
            };
            return this.View(viewModel);
        }

        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterTeamInputModel input)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            // If User Already have Team
            if (this.teamService.IsUserHaveTeam(userId))
            {
                var teamName = await this.teamService.GetTeamNameByUserId(userId);
                return this.Redirect($"/Team/TeamPage?teamName={teamName}");
            }

            // If Player Try Create Team But He already apply to other Team
            if (await this.teamService.IsPlayerAlreadyApplyToTeam(userId))
            {
                var teamName = await this.teamService.GetTeamPlayerTeamNameByUserId(userId);
                return this.Redirect($"/Team/TeamPage?teamName={teamName}");
            }

            if (this.ModelState.IsValid)
            {
                await this.teamService.CreateTeam(userId, input);
            }

            var newTeam = await this.teamService.GetTeamNameByUserId(userId);

            return this.Redirect($"/Team/TeamPage?teamName={newTeam}");
        }

        [HttpPost]
        public async Task<IActionResult> ApplyToTeam(int teamId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await this.teamService.ApplyToTeam(userId, teamId);
            var teamName = await this.teamService.GetTeamNameById(teamId);
            return this.Redirect($"/Team/TeamPage?teamName={teamName}");
        }

        [HttpPost]
        public async Task<IActionResult> LeaveGroup(int teamId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            await this.teamService.LeaveGroup(userId, teamId);

            return this.Redirect("/Team/Index");
        }

        [HttpPost]
        public async Task<IActionResult> Abandon(int teamId)
        {
            await this.teamService.Abandon(teamId);

            return this.Redirect("/Team/Index");
        }

        public async Task<IActionResult> TeamPage(string teamName)
        {
            var viewModel = await this.teamService.GetTeamByName(teamName);
            return this.View(viewModel);
        }
    }
}
