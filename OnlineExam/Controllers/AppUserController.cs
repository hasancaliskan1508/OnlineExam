using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Models;

namespace OnlineExam.Controllers
{
    public class AppUserController : Controller
    {
        private readonly AppDBContext _context;
        private readonly UserManager<AppUser> _userManager;

        public AppUserController(AppDBContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            string user = TempData["User"].ToString();

            ViewBag.exams = _context.Exams.ToList() ;


            List<ExamResult> results = _context.ExamResults.Where(x => x.AppUserID == user).ToList(); ;


            return View(results);
        }
    }
}
