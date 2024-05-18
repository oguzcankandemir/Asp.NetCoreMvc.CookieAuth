using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCoreMvc.CookieAuth.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
