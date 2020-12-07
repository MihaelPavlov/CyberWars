namespace CyberWars.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;


    using CyberWars.Common;
    using CyberWars.Services.Data.Academy;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.UserRoleName)]
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

        [HttpPost]
        public async Task<IActionResult> CompleteLecture(int lectureId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            await this.academyService.CompleteLectureById(userId, lectureId);

            var courseName = await this.academyService.GetCourseNameByLectureId(lectureId);


            return this.Redirect($"/Academy/Lectures?courseName={courseName}");
        }

        public IActionResult Languages()
        {
            return this.View();
        }
    }
}
