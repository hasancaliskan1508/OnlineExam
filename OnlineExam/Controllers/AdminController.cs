using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Models;
using OnlineExam.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Data;

namespace OnlineExam.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly AppDBContext _context;

        public AdminController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager, AppDBContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _context = context;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
          

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

            var list=_context.ExamResults.FirstOrDefault();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {

            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null  )
            {
                ModelState.AddModelError(string.Empty, "Geçersiz Kullanıcı Adı veya Parola!");
                return View();
            }
            var signInResult = await _signInManager.PasswordSignInAsync(user, model.Password, model.KeepMe, true);

            if (signInResult.Succeeded)
            {
                return RedirectToAction("Index");
            }
            if (signInResult.IsLockedOut)
            {
                ModelState.AddModelError("", "Kullanıcı Girişi " + user.LockoutEnd + " kadar kısıtlanmıştır!");
                return View();
            }
            ModelState.AddModelError("", "Geçersiz Kullanıcı Adı veya Parola Başarısız Giriş Sayısı :" + await _userManager.GetAccessFailedCountAsync(user) + "/3");
            return View();
        }

        public IActionResult AddExam()
        {
            

            return View();

        }

        [HttpPost]
        public IActionResult AddExam(ExamModel model)
        {
            Exam exam = new Exam()
            {
                ExamName = model.ExamName,
                ExamDate = model.ExamDate,
                LessonId = model.LessonID,
            };
            _context.Add(exam);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }

        public IActionResult AddQuestionAndOptions()
        {


            return View();

        }

        [HttpPost]
        public IActionResult AddQuestionAndOptions(QuestionAndOptions model)
        {
            QuestionAndOptions questionAndOptions = new QuestionAndOptions()
            {
                QuestionText = model.QuestionText,
                A = model.A,
                B = model.B,
                C = model.C,
                D = model.D,
                CorrectAnswer = model.CorrectAnswer,
                ExamId = model.ExamId,

            };
            _context.Add(questionAndOptions);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }

        public IActionResult ListExams()
        {
            ViewBag.AppUsers=_context.Users.ToList();
            ViewBag.Exams=_context.Exams.ToList();

            List<ExamResult>list=_context.ExamResults.ToList();

            return View(list);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        public IActionResult AddRole()
        {
            List<AppUser> users = _context.Users.ToList();  
            return View(users);

        }
        [HttpPost]
        public async Task<IActionResult> AddRole(string Role, AppUser appUser)
        {

            var roleExist = await _roleManager.RoleExistsAsync(Role);
            if (!roleExist)
            {
                AppRole appRole2 = new AppRole()
                {
                    Name = Role,
                };
                await _roleManager.CreateAsync(appRole2);
                _context.SaveChanges();
            };

           

            AppUser User=_context.Users.FirstOrDefault(x=>x.FullName==appUser.FullName);

            await _userManager.AddToRoleAsync(User, Role);

                   return RedirectToAction("Index");

        }

      

    }
    
    }
