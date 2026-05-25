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

        [Range(1, 5)] //restricts severity to the intended 1-5 scale
        public int Severity { get; set; }

        [Required] //ensures the actual defect description can't be blank
        [StringLength(255)] //limits description length
        public string? Description { get; set; }

        public int? SuspectedCauseEventId { get; set; }
        public int? FixEventId { get; set; }

        [Required] //ensures the defect status is always recorded
        [StringLength(30)] //limits status length
        public string? Status { get; set; }

        public Surface? Surface { get; set; }
        public DefectType? DefectType { get; set; }
        public ICollection<EvidencePhoto>? EvidencePhotos { get; set; }


    }
}