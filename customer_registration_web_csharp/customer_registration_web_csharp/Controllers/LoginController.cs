using Microsoft.AspNetCore.Mvc;

namespace customer_registration_web_csharp.Controllers
{
    public class LoginController : Controller
    {
        
  

        public IActionResult Index(string username, string password)
        {
            if(!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                if(username.ToUpper() == "ADMIN" && password == "123456")
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["Mensagem"] = "ola só";
                }
            }      
            return View();
        }
    }
}
