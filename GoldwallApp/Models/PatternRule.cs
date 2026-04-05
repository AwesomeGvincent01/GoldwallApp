using System.ComponentModel.DataAnnotations;

namespace GoldwallApp.Models
{
    public class PatternRule
    {
        public int PatternRuleId { get; set; }

        public int PatternId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Field Name")]
        public string? FieldName { get; set; }

        [Required]
        [StringLength(20)]
        public string? Operator { get; set; }

        [StringLength(50)]
        [Display(Name = "Value 1")]
        public string? Value1 { get; set; }

        [StringLength(50)]
        [Display(Name = "Value 2")]
        public string? Value2 { get; set; }

        public Pattern? Pattern { get; set; }
    }
}