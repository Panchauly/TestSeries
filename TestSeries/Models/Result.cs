using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestSeries.Models
{
    public class Result
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResultId { get; set; }
        public int ExamId { get; set; }
        public string StudentId { get; set; }
        public string Answers { get; set; }
        public int RightAnswers { get; set; }
        public int WrongAnswers { get; set; }

        [ForeignKey("StudentId")]
        public virtual StudentProfile Student { get; set; }

        [ForeignKey("ExamId")]
        public virtual Exam Exam { get; set; }

    }
}