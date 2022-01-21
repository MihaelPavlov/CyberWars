namespace CyberWars.Web.Controllers
{
    using System;
    using System.IO;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using CyberWars.Common;
    using CyberWars.Services.Data.Teams;
    using CyberWars.Web.ViewModels.Team;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Controller that handles requests that come from the Team.
    /// </summary>
    [Authorize(Roles = GlobalConstants.UserRoleName)]
    public class TeamController : Controller
    {
        private readonly ITeamService teamService;
        private readonly IWebHostEnvironment webHostEnvironment;

        /// <summary>
        /// Constructor that instantiates Team controller.
        /// </summary>
        public TeamController(ITeamService teamService, IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment ?? throw new ArgumentNullException(nameof(webHostEnvironment));
            this.teamService = teamService ?? throw new ArgumentNullException(nameof(teamService));
        }

        /// <summary>
        /// Use this method to visualize index page of team.
        /// </summary>
        [HttpGet] // GET /Team/Index
        public async Task<IActionResult> Index()
        {
            var viewModel = await this.teamService.Get10StrongerTeam<TeamViewModel>();
            return this.View(viewModel);
        }

        /// <summary>
        /// Use this method to visualize ranking page.
        /// </summary>
        /// <param name="id">A integer representing the number of the page.</param>
        [HttpGet] // GET /Team/Ranking
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

        /// <summary>
        /// Use this method to visualize create team page.
        /// </summary>
        [HttpGet] // GET /Team/Register
        public IActionResult Register()
        {
            return this.View();
        }

        /// <summary>
        /// Use this method to visualize team page information.
        /// </summary>
        /// <param name="teamId">A integer representing Id of the team that we want to see.</param>
        [HttpGet] // GET /Team/TeamPage?teamId={teamId}
        public async Task<IActionResult> TeamPage(int teamId)
        {
            var viewModel = await this.teamService.GetTeamPageById(teamId);
            return this.View(viewModel);
        }

        /// <summary>
        /// Use this method to find a team by name.
        /// </summary>
        /// <param name="teamId">A string representing the name of the team.</param>
        [HttpGet] // GET /Team/SearchTeamByName?name={name}
        public async Task<IActionResult> SearchTeamByName(string name)
        {
            var team = await this.teamService.SearchTeamByName(name);

            if (team == null)
            {
                return this.Redirect($"/Team/Ranking");
            }

            return this.Redirect($"/Team/TeamPage?teamId={team.Id}");
        }

        /// <summary>
        /// Use this method to make request for creating a team.
        /// </summary>
        /// <param name="input"><see cref="RegisterTeamInputModel"/></param>
        [HttpPost] // POST /Team/Register?name={name}&motivationalMotto={motivationalMotto}&description={description}&image={image}
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

            var isCreated = await this.teamService.CreateTeam(userId, input, imagePath);

            if (!isCreated)
            {
                this.ModelState.AddModelError("Name", "You dont have enough money!!");

                var falseimagePath = this.webHostEnvironment.WebRootFileProvider.GetFileInfo($"/TeamImages/{userId}.png").PhysicalPath;

                await this.teamService.RemoveImage(falseimagePath);

                return this.View();
            }

            var newTeamId = await this.teamService.GetTeamIdByUserId(userId);

            return this.Redirect($"/Team/TeamPage?teamId={newTeamId}");
        }

        /// <summary>
        /// Use this method to make request for applying to team.
        /// </summary>
        /// <param name="teamId">A integer representing Id of the team that we want candidate.</param>
        [HttpPost] // POST /Team/ApplyToTeam?teamId={teamId}
        public async Task<IActionResult> ApplyToTeam(int teamId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await this.teamService.ApplyToTeam(userId, teamId);
            return this.Redirect($"/Team/TeamPage?teamId={teamId}");
        }

        /// <summary>
        /// Use this method to make request for leaving a team.
        /// </summary>
        /// <param name="teamId">A integer representing Id of the team that we want leave.</param>
        /// <returns></returns>
        [HttpPost] // POST /Team/LeaveGroup?teamId={teamId}
        public async Task<IActionResult> LeaveGroup(int teamId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            await this.teamService.LeaveGroup(userId, teamId);

            return this.Redirect("/Team/Index");
        }

        /// <summary>
        /// Use this method to abandon your team. Only for players who create a team.
        /// </summary>
        /// <param name="teamId">A integer representing Id of the team that we want to abandon.</param>
        [HttpPost] // POST /Team/Abandon?teamId={teamId}
        public async Task<IActionResult> Abandon(int teamId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var imagePath = this.webHostEnvironment.WebRootFileProvider.GetFileInfo($"/TeamImages/{userId}.png").PhysicalPath;

            await this.teamService.Abandon(teamId, imagePath);

            return this.Redirect("/Team/Index");
        }
    }
}
