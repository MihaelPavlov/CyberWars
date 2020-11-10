namespace CyberWars.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class AcademyController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Lectures()
        {
            return this.View();
        }

        public IActionResult Languages()
        {
            return this.View();
        }
    }
}
