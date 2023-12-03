using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Models;
using OnlineExam.ViewModels;
using System.Security.Claims;

namespace OnlineExam.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDBContext _context;
        public AdminController(AppDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var studentCount = _context.Students.Count();
            ViewBag.students = studentCount;

            var activeToDo = _context.ToDoLists.Where(x => x.Status==1).Count();
            ViewBag.activeToDo = activeToDo;

            var waitingToDo = _context.ToDoLists.Where(x =>x.Status==0).Count();
            ViewBag.waitingToDo = waitingToDo;

            var allToDo = _context.ToDoLists.Count();
            ViewBag.allToDo = allToDo;
            return View();                       
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            var user = _context.Admins.Where(s => s.UserName == model.UserName && s.Password == model.Password).SingleOrDefault();
            if (user == null)
            {
                return View();
            }
           

            return RedirectToAction("Index", "Admin");
        }

    }
}
