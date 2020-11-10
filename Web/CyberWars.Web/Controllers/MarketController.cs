namespace CyberWars.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class MarketController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Animals()
        {
            return this.View();
        }

        public IActionResult Food()
        {
            return this.View();
        }
    }
}
