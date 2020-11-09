namespace CyberWars.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class DarkWebController : Controller
    {
        public IActionResult Attack()
        {
            return this.View();
        }

        public IActionResult Search()
        {
            return this.View();
        }
        public IActionResult Result()
        {
            return this.View();
        }
    }
}
