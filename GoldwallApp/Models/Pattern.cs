using System.ComponentModel.DataAnnotations;

namespace GoldwallApp.Models
{
    public class Pattern
    {
        public int PatternId { get; set; }

        [Display(Name = "Business")]
        public int BusinessId { get; set; }

        [Required]
        [StringLength(100)]
        public string? Title { get; set; }

        [StringLength(255)]
        public string? Description { get; set; }

        [Range(0, 99.99)]
        public decimal Confidence { get; set; }

        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; }

        public Business? Business { get; set; }
        public ICollection<PatternRule>? PatternRules { get; set; }
        public ICollection<PatternOutcome>? PatternOutcomes { get; set; }
    }
}