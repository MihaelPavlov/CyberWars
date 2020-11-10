namespace CyberWars.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class WebController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Job()
        {
            return this.View();
        }
    }
}
