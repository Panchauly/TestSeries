using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestSeries.Models
{
    public class InstituteProfile
    {
        [Key]
        public string InstituteId { get; set; }
        public string InstituteName { get; set; }
        public string AddressLineFirst { get; set; }
        public string AddressLineSecond { get; set; }
        public int CityId { get; set; }
        public int Logo { get; set; }
        public string RequestStatus { get; set; }
        public string InstituteWebsite { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("CityId")]
        public virtual City City { get; set; }

        [ForeignKey("Logo")]
        public virtual Image Image { get; set; }

    }
}