namespace CyberWars.Web.Controllers
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using CyberWars.Common;
    using CyberWars.Services.Data.Academy;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Controller that handles requests that come from the Academy.
    /// </summary>
    [Authorize(Roles = GlobalConstants.UserRoleName)]
    public class AcademyController : Controller
    {
        private readonly IAcademyService academyService;

        /// <summary>
        /// Constructor that instantiates Academy controller.
        /// </summary>
        public AcademyController(IAcademyService academyService)
        {
            this.academyService = academyService ?? throw new ArgumentNullException(nameof(academyService));
        }

        /// <summary>
        /// Use this method to visualize index page of the academy.
        /// </summary>
        [HttpGet] // GET /Academy/Index
        public IActionResult Index()
        {
            return this.View();
        }

        /// <summary>
        /// Use this method to visualize basic page of the academy. The main page contains the two courses that you need to complete first.
        /// </summary>
        [HttpGet] // GET /Academy/Basic?courseName={courseName}
        public IActionResult Basic()
        {
            return this.View();
        }

        /// <summary>
        /// Use this method to visualize all the paths of courses you can complete. Divided by languages.
        /// </summary>
        [HttpGet] // GET /Academy/Languages
        public IActionResult Languages()
        {
            return this.View();
        }

        /// <summary>
        /// Use this method to visualize all lectures from the desired course.
        /// </summary>
        /// <param name="courseName">A string that contains the name of the course we want.</param>
        /// <returns>View with all leactures from the desired course.</returns>
        [HttpGet] // GET /Academy/Lectures?courseName={courseName}
        public async Task<IActionResult> Lectures(string courseName)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var viewModel = await this.academyService.GetLecturesByName(courseName, userId);
            return this.View(viewModel);
        }

        /// <summary>
        /// Use this method to complete lecture from course.
        /// </summary>
        /// <param name="lectureId">A string that contains which lecture we will finish.</param>
        /// <returns>Redirect to the course from which the lecture was completed.</returns>
        [HttpPost] // POST /Academy/CompleteLecture?lectureId={lectureId}
        public async Task<IActionResult> CompleteLecture(int lectureId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            await this.academyService.CompleteLectureById(userId, lectureId);

            var courseName = await this.academyService.GetCourseNameByLectureId(lectureId);

            return this.Redirect($"/Academy/Lectures?courseName={courseName}");
        }
    }
}
