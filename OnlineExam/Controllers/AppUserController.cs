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
            if (TempData["User"] != null)
            {
                string user = TempData["User"].ToString();
                ViewBag.exams = _context.Exams.ToList();
                List<ExamResult> results = _context.ExamResults.Where(x => x.AppUserID == user).ToList(); ;
                return View(results);
            }

            return View();

            


           
        }

        public IActionResult Sinavlar()
        {
           List<QuestionAndOptions> model= _context.QuestionsAndOptions.ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Sinavlar(List<QuestionAndOptions> questionAndOptions)
        {
            int result = 0;
            int correctCount = 0;
            int wrongCount = 0;
            foreach (QuestionAndOptions question in questionAndOptions)
            {
                if (_context.QuestionsAndOptions.Any(x=>x.CorrectAnswer==question.SelectedOption))
                {
                    result = result + 20;
                    correctCount++;
                }
                else
                {
                    wrongCount++;
                }
               
            };
            ExamResult examResult = new ExamResult()
            {
                AppUserID = "3e06c083-939c-4b38-9179-7b67f69ade68",
                ExamId=1,
                CorrectCount=correctCount,
                WrongCount=wrongCount,
                Result=result,

            };
            _context.ExamResults.Add(examResult);
           // _context.SaveChanges();
            
            return RedirectToAction("Index");
        }

    }
}
