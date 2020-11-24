namespace CyberWars.Web.Controllers
{
    using CyberWars.Services.Data.Academy;
    using CyberWars.Web.ViewModels.Academy;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

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
            var viewModel = await this.academyService.GetLecturesByName<LectureViewModel>(courseName);
            return this.View(viewModel);
        }

        public IActionResult Languages()
        {
            return this.View();
        }
    }
}
