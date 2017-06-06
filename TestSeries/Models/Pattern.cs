using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestSeries.Models
{
    public class Pattern
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PatternId { get; set; }

        public int Branch { get; set; }
        public int Level { get; set; }
        public int Subject { get; set; }
        public int Chapter { get; set; }

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