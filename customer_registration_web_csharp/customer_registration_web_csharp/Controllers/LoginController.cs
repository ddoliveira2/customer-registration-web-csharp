using Microsoft.AspNetCore.Mvc;

namespace customer_registration_web_csharp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
