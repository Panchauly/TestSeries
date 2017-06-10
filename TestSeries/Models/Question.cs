using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestSeries.Models
{
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionId { get; set; }
        public string QuestionBody { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
        public char RightAnswer { get; set; }
        public bool AnyImage { get; set; }
        public int DificultyLevel { get; set; }
        public int? QuestionImage { get; set; }
        public string UploadedBy { get; set; }
        public DateTime UploadedOn { get; set; }
        public int PatternId { get; set; }

        [ForeignKey("QuestionImage")]
        public virtual Image Image { get; set; }

        [ForeignKey("UploadedBy")]
        public virtual InstituteProfile Institute { get; set; }

        [ForeignKey("PatternId")]
        public virtual Pattern Pattern { get; set; }
    }
}