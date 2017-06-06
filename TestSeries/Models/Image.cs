using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestSeries.Models
{
    public class Image
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ImageId { get; set; }

        public string InameName { get; set; }
        public string ImagePath { get; set; }
        public string ImageType { get; set; }
        public string UploadedBy { get; set; }
        public DateTime UploadedOn { get; set; }
        public bool IsAvtive { get; set; }

        [ForeignKey("UploadedBy")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}