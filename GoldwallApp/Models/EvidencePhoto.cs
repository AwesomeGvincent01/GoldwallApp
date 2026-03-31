using System.ComponentModel.DataAnnotations;

namespace GoldwallApp.Models
{
    public class EvidencePhoto
    {
        public int EvidencePhotoId { get; set; }    

        public int WorkEventId { get; set; }

        public int DefectReportId { get; set; }

        [MaxLength(255)]
        public string? FileUrl { get; set; }

        [MaxLength(100)]
        public string? Caption { get; set; }

        public DateTime TakenAt { get; set; }  

    }
}
