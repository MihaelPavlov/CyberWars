namespace CyberWars.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using CyberWars.Services.Data.Academy;
    using CyberWars.Web.ViewModels.Academy;

    public class AcademyController : Controller
    {
        private readonly IAcademyService academyService;

        public AcademyController(IAcademyService academyService)
        {
            this.academyService = academyService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public async Task<IActionResult> Lectures(string courseName)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var viewModel = await this.academyService.GetLecturesByName(courseName, userId);
            return this.View(viewModel);
        }

        public IActionResult Languages()
        {
            return this.View();
        }
    }
}
