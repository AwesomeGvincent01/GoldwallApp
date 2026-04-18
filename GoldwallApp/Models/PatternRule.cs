using System.ComponentModel.DataAnnotations;

namespace GoldwallApp.Models
{
    public class PatternRule
    {
        public int PatternRuleId { get; set; }

        public int PatternId { get; set; }

        [Required] //ensures the field name is recorded
        [StringLength(50)] //limits field name length
        [Display(Name = "Field Name")]
        public string? FieldName { get; set; }

        [Required] //ensures an operator is always recorded
        [StringLength(20)] //limits operator length
        public string? Operator { get; set; }

        [StringLength(50)] //limits first value length
        [Display(Name = "Value 1")]
        public string? Value1 { get; set; }

        [StringLength(50)] //limits second value length
        [Display(Name = "Value 2")]
        public string? Value2 { get; set; }

        public Pattern? Pattern { get; set; }
    }
}