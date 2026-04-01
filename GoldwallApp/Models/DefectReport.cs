using System.ComponentModel.DataAnnotations;

namespace GoldwallApp.Models
{
    public class DefectReport
    {
        public int DefectReportId { get; set; }

        public int SurfaceId { get; set; }

        public int DefectTypeId { get; set; }

        public DateTime ReportedAt { get; set; }

        public int Severity { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        public int SuspectedCauseEventId { get; set; }

        public int FixEventId { get; set; }

        public string? Status { get; set; }


        public Surface? Surface { get; set; }   

    }
}
