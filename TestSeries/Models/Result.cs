using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestSeries.Models
{
    public class Result
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResultId { get; set; }
        public int Exam { get; set; }
        public string Student { get; set; }
        public string Answers { get; set; }
        public int RightAnswers { get; set; }
        public int WrongAnswers { get; set; }

        [ForeignKey("Student")]
        public virtual Student Students { get; set; }

        [ForeignKey("Exam")]
        public virtual Exam Exams { get; set; }

    }
}