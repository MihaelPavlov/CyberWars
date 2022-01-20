namespace CyberWars.Web.Controllers
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using CyberWars.Common;
    using CyberWars.Services.Data.CompetitiveCoding;
    using CyberWars.Web.ViewModels.WebViews.CompetitiveCoding;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Controller that handles requests that come from the CompetitiveCoding.
    /// </summary>
    [Authorize(Roles = GlobalConstants.UserRoleName)]
    public class CompetitiveCodingController : Controller
    {
        private readonly IContestService contestService;

        /// <summary>
        /// Constructor that instantiates CompetitiveCoding controller.
        /// </summary>
        public CompetitiveCodingController(IContestService contestService)
        {
            this.contestService = contestService ?? throw new ArgumentNullException(nameof(contestService)); ;
        }

        /// <summary>
        /// Use this method to visualize four different competitive coding challenges.
        /// </summary>
        [HttpGet] // GET /CompetitiveCoding/Index
        public async Task<IActionResult> Index()
        {
            var viewModel = await this.contestService.GetContests<ContestViewModel>();

            return this.View(viewModel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contestId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Result(int contestId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var viewModel = await this.contestService.ResultFromContestById(contestId, userId);

            // Need to be Error
            if (viewModel == null)
            {
                return this.Redirect("/CompetitiveCoding/Index");
            }

            return this.View(viewModel);
        }
    }
}
