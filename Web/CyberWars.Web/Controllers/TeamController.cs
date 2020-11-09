namespace CyberWars.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class TeamController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Ranking()
        {
            return this.View();
        }

        public IActionResult Register()
        {
            return this.View();
        }
    }
}
