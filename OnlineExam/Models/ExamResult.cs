namespace OnlineExam.Models
{
    public class ExamResult
    {
        public int ExamResultId { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int ExamId { get; set; }
        public Exam Exam { get; set; }
        public int CorrectCount { get; set; }
        public int WrongCount { get; set; }
        public double Result { get; set; }
    }
}
