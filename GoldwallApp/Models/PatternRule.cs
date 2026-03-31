using System.ComponentModel.DataAnnotations;

namespace GoldwallApp.Models
{
    public class PatternRule
    {

        public int PatternRuleId { get; set; }  

        public int PatternId { get; set; }

        [MaxLength(50)]
        public string? FieldName { get; set; }

        [MaxLength (20)]
        public string? Operator { get; set; }

        [MaxLength(50)]
        public string? Value1 { get; set; }

        [MaxLength(50)  ]
        public string Value2 { get; set; }
    }
}
