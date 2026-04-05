using System.ComponentModel.DataAnnotations;

namespace GoldwallApp.Models
{
    public class DefectReport
    {
        public int DefectReportId { get; set; }

        public int SurfaceId { get; set; }
        public int DefectTypeId { get; set; }

        [Display(Name = "Reported At")]
        public DateTime ReportedAt { get; set; }

        [Range(1, 5)]
        public int Severity { get; set; }

       
        [Required]
        [StringLength(255)]
        public string? Description { get; set; }

        public int? SuspectedCauseEventId { get; set; }
        public int? FixEventId { get; set; }

        [Required]
        [StringLength(30)]
        public string? Status { get; set; }

        public Surface? Surface { get; set; }
        public DefectType? DefectType { get; set; }
        public ICollection<EvidencePhoto>? EvidencePhotos { get; set; }
    }
}