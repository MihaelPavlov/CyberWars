namespace CyberWars.Web.Controllers
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using CyberWars.Common;
    using CyberWars.Services.Data.Web;
    using CyberWars.Web.ViewModels.WebViews.Job;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Controller that handles requests that come from the web.
    /// </summary>
    [Authorize(Roles = GlobalConstants.UserRoleName)]
    public class WebController : Controller
    {
        private readonly IWebService webService;

        /// <summary>
        /// Constructor that instantiates Web controller.
        /// </summary>
        public WebController(IWebService webService)
        {
            this.webService = webService ?? throw new ArgumentNullException(nameof(webService));
        }

        /// <summary>
        /// Use this method to visualize index page of the web.
        /// </summary>
        [HttpGet] // GET /Web/Index
        public IActionResult Index()
        {
            return this.View();
        }

        /// <summary>
        /// Use this method to visualize job page of the web.
        /// </summary>
        [HttpGet] // GET /Web/Job
        public async Task<IActionResult> Job()
        {
            var viewModel = await this.webService.GetRandomJobs<JobViewModel>();
            return this.View(viewModel);
        }

        /// <summary>
        /// Use this method to make request for get reward from job by Id.
        /// </summary>
        /// <param name="jobId">A integer representing job Id.</param>
        [HttpPost] // POST /Web/GetRewardFromJob?jobId={jobId}
        public async Task<IActionResult> GetRewardFromJob(int jobId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            await this.webService.CompleteJob(jobId, userId);

            return this.Redirect("/Web/Job");
        }
    }
}
