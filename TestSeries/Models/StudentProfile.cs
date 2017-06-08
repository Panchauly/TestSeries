using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestSeries.Models
{
    public class StudentProfile
    {
        [Key]
        public string StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public int Batch { get; set; }
        public string AddressLineFirst { get; set; }
        public string AddressLineSecond { get; set; }
        public int CityId { get; set; }
        public int ProfileImage { get; set; }
        public string RequestStatus { get; set; }
        public string InstituteWebsite { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("CityId")]
        public virtual City City { get; set; }

        [ForeignKey("Batch")]
        public virtual Batch Bathes { get; set; }

        [ForeignKey("ProfileImage")]
        public virtual Image Image { get; set; }
    }
}