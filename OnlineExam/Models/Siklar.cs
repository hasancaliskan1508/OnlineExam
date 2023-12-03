namespace OnlineExam.Models
{
    public class Siklar
    {
        public int SiklarId { get; set; } 
        public string A { get; set; } 
        public string B { get; set; } 
        public string C { get; set; } 
        public string D { get; set; } 
        public int QuestionId { get; set; } 
        public Question Question { get; set; } 

    }
}
