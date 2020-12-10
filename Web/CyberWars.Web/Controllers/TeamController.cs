namespace CyberWars.Web.Controllers
{
    using System.IO;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using CyberWars.Common;
    using CyberWars.Services.Data.Team;
    using CyberWars.Web.ViewModels.Team;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.UserRoleName)]
    public class TeamController : Controller
    {
        private readonly ITeamService teamService;
        private readonly IWebHostEnvironment webHostEnvironment;

        public TeamController(ITeamService teamService, IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
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
                var teamId = await this.teamService.GetTeamIdByUserId(userId);
                return this.Redirect($"/Team/TeamPage?teamId={teamId}");
            }

            // If Player Try Create Team But He already apply to other Team
            if (await this.teamService.IsPlayerAlreadyApplyToTeam(userId))
            {
                var playerHaveTeamId = await this.teamService.GetTeamPlayerTeamIdByUserId(userId);
                return this.Redirect($"/Team/TeamPage?teamId={playerHaveTeamId}");
            }

            if (await this.teamService.IsTeamUsernameAlreadyUse(input.Name))
            {
                this.ModelState.AddModelError("Name", "GroupName is already taken");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            // Save TeamImage
            using (FileStream fs = new FileStream(Path.Combine(this.webHostEnvironment.WebRootPath, "TeamImages", $"{userId}.png"), FileMode.Create))
            {
                await input.Image.CopyToAsync(fs);
            }

            var imagePath = this.webHostEnvironment.WebRootFileProvider.GetFileInfo($"/TeamImages/{userId}.png").Name;

            await this.teamService.CreateTeam(userId, input, imagePath);
            var newTeamId = await this.teamService.GetTeamIdByUserId(userId);

            return this.Redirect($"/Team/TeamPage?teamId={newTeamId}");
        }

        [HttpPost]
        public async Task<IActionResult> ApplyToTeam(int teamId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await this.teamService.ApplyToTeam(userId, teamId);
            return this.Redirect($"/Team/TeamPage?teamId={teamId}");
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
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var imagePath = this.webHostEnvironment.WebRootFileProvider.GetFileInfo($"/TeamImages/{userId}.png").PhysicalPath;

            await this.teamService.Abandon(teamId, imagePath);

            return this.Redirect("/Team/Index");
        }

        public async Task<IActionResult> TeamPage(int teamId)
        {
            var viewModel = await this.teamService.GetTeamPageById(teamId);
            return this.View(viewModel);
        }

        public async Task<IActionResult> SearchTeamByName(string name)
        {
            var team = await this.teamService.SearchTeamByName(name);

            if (team == null)
            {
                return this.Redirect($"/Team/Ranking");
            }

            return this.Redirect($"/Team/TeamPage?teamId={team.Id}");
        }
    }
}
