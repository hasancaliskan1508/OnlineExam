using System.ComponentModel.DataAnnotations;

namespace OnlineExam.Models
{
    public class ToDoList
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int Status { get; set; }
    }
}
