using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestSeries.Models
{
    public class Exam
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExamId { get; set; }
        public int Time { get; set; }
        public int Questions { get; set; }
        public DateTime ExamDate { get; set; }
        public string InstituteId { get; set; }
        public int Marks { get; set; }
        public int NegativeMarks { get; set; }
        public int Pattern { get; set; }

        [ForeignKey("InstituteId")]
        public virtual InstituteProfile Instituteprofile { get; set; }

        [ForeignKey("Pattern")]
        public virtual Pattern Patterns { get; set; }
    }
}