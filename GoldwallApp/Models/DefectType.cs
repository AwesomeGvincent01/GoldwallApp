using System.ComponentModel.DataAnnotations;

namespace GoldwallApp.Models
{
    public class DefectType
    {
        public int DefectTypeId { get; set; }


        [StringLength(50)]
        [Display(Name = "Business")]
        public int BusinessId { get; set; }



       

        [Required]
        [StringLength(50)]
        public string Name { get; set; }


        [StringLength(255)]
        public string Notes { get; set; }


        public Business? Business { get; set; }
        public ICollection<DefectReport>? DefectReports { get; set; }
    }
}
