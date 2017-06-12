using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestSeries.Models.ViewModel
{
    public class QuestionViewModel
    {
        public int Branch { get; set; }
        public int Level { get; set; }
        public int Subject { get; set; }
        public int Chapter { get; set; }

        [Display(Name ="Question")]
        public string QuestionBody { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }

        [MaxLength(1)]
        public string RightAnswer { get; set; }
        public bool AnyImage { get; set; }
        public int DificultyLevel { get; set; }
        public int? QuestionImage { get; set; }
        public string UploadedBy { get; set; }
        public DateTime UploadedOn { get; set; }

        [ForeignKey("QuestionImage")]
        public virtual Image Image { get; set; }

        [ForeignKey("Branch")]
        public virtual Branch Branches { get; set; }

        [ForeignKey("Level")]
        public virtual Level Levels { get; set; }

        [ForeignKey("Subject")]
        public virtual Subject Subjects { get; set; }

        [ForeignKey("Chapter")]
        public virtual Chapter Chapters { get; set; }
    }
}