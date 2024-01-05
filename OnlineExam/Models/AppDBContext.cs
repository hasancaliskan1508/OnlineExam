using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<Student> Students { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamResult> ExamResults { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Siklar> Siklars { get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }
    }
}

