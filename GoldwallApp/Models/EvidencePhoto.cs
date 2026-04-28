using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldwallApp.Models
{


    public class EvidencePhoto
    {
        public int EvidencePhotoId { get; set; }

        public int WorkEventId { get; set; }

        public int? DefectReportId { get; set; }

        [StringLength(150)] //limits caption length
        [Display(Name = "Caption")]
        public string? Caption { get; set; }

        [NotMapped]
        [Required] //ensures the photo file path/url is entered
        [StringLength(255)] //limits file url length
        [Display(Name = "File URL")]
        public IFormFile? FileUrl { get; set; }

      

        [Display(Name = "Taken At")]
        public DateTime TakenAt { get; set; }


        public WorkEvent? WorkEvent { get; set; }
        public DefectReport? DefectReport { get; set; }

    }
}