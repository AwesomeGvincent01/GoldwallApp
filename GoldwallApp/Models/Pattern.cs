using System.ComponentModel.DataAnnotations;

namespace GoldwallApp.Models
{
    public class Pattern
    {
        public int PatternId { get; set; }

        [Display(Name = "Business")]
        public int BusinessId { get; set; }

        [Required] //ensures each pattern has a title
        [StringLength(100)] //limits title length
        public string? Title { get; set; }

        [StringLength(255)] //limits description length
        public string? Description { get; set; }

        [Range(0, 99.99)] //keeps confidence inside the intended range
        public decimal Confidence { get; set; }

        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; }

        public Business? Business { get; set; }
        public ICollection<PatternRule>? PatternRules { get; set; }
        public ICollection<PatternOutcome>? PatternOutcomes { get; set; }
    }
}