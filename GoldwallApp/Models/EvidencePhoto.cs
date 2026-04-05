using System.ComponentModel.DataAnnotations;

namespace GoldwallApp.Models
{
    public class EvidencePhoto
    {
        public int EvidencePhotoId { get; set; }    

        public int WorkEventId { get; set; }

        public int DefectReportId { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "File URL")]
        public string? FileUrl { get; set; }

        [StringLength(100)]
        public string? Caption { get; set; }

        [StringLength(150)]
        public DateTime TakenAt { get; set; }


        public WorkEvent? WorkEvent { get; set; }
        public DefectReport? DefectReport { get; set; }

    }
}
