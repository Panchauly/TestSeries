using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestSeries.Models
{
    public class Batch
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BatchId { get; set; }
        public string Institute { get; set; }
        public int AllotedSeats { get; set; }
        public int EnrolledSeates { get; set; }

        [ForeignKey("Institute")]
        public virtual InstituteProfile InstituteProfile { get; set; }
    }
}