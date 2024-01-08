using Microsoft.AspNetCore.Mvc;

namespace OnlineExam.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
