namespace CyberWars.Web.Controllers
{
    using CyberWars.Services.Data.Web;
    using Microsoft.AspNetCore.Mvc;
    using CyberWars.Web.ViewModels.WebViews.Job;
    using System.Threading.Tasks;

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
    }
}
