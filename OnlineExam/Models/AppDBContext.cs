using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineExam.ViewModels;

namespace OnlineExam.Models
{
    public class AppDBContext: IdentityDbContext<AppUser, AppRole, string>
    {
        public AppDBContext(DbContextOptions options) : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server=DESKTOP-6H30G4U\\SQLEXPRESS;database=OnlineExam;integrated security=true;TrustServerCertificate=True;");
        //}
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamResult> ExamResults { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<QuestionAndOptions> QuestionsAndOptions { get; set; }
      
        public DbSet<ToDoList> ToDoLists { get; set; }
      
        public DbSet<OnlineExam.ViewModels.QuestionAndOptionsModel> QuestionAndOptionsModel { get; set; } = default!;

       
    }
}

