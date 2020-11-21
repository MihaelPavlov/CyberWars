namespace CyberWars.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using CyberWars.Services.Data.CompetitiveCoding;
    using CyberWars.Web.ViewModels.WebViews.CompetitiveCoding;
    using Microsoft.AspNetCore.Mvc;

    public class CompetitiveCodingController : Controller
    {
        private readonly IContestService contestService;

        public CompetitiveCodingController(IContestService contestService)
        {
            this.contestService = contestService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = await this.contestService.GetContests<ContestViewModel>();

            return this.View(viewModel);
        }

        public async Task<IActionResult> Result(int contestId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var viewModel = await this.contestService.ResultFromContestById<ResultContestViewModel>(contestId, userId);

            return this.View(viewModel);
        }
    }
}
