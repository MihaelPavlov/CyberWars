namespace CyberWars.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class CompetitiveCodingController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
        public IActionResult Result()
        {
            return this.View();
        }
    }
}
