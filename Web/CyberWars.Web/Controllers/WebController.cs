namespace CyberWars.Web.Controllers
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Hangfire;
    using Microsoft.AspNetCore.Mvc;
    using CyberWars.Services.Data.Hangfire;
    using CyberWars.Services.Data.Web;
    using CyberWars.Web.ViewModels.WebViews.Job;

    public class WebController : Controller
    {

        private readonly IWebService webService;

        public WebController(IWebService webService)
        {
            this.webService = webService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public async Task<IActionResult> Job()
        {
            var viewModel = await this.webService.GetRandomJobs<JobViewModel>();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> GetRewardFromJob(int jobId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            await this.webService.CompleteJob(jobId, userId);

            return this.Redirect("/Web/Job");
        }
    }
}
