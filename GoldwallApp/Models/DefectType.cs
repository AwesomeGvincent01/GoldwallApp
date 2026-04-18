using System.ComponentModel.DataAnnotations;

namespace GoldwallApp.Models
{
    public class DefectType
    {
        public int DefectTypeId { get; set; }


        [Display(Name = "Business")]
        public int BusinessId { get; set; }

        [Required] //ensures the defect type name is entered
        [StringLength(50)] //limits the defect type name length
        public string? Name { get; set; }

        [StringLength(255)] //limits notes
        public string? Notes { get; set; }

        public Business? Business { get; set; }
        public ICollection<DefectReport>? DefectReports { get; set; }
    }
}