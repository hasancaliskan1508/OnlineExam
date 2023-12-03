namespace OnlineExam.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public int ExamId { get; set; }
        public Exam Exam { get; set; }
        public string CorrectAnswer { get; set; }
        public List<Siklar> Siklars { get; set; }

    }
}
