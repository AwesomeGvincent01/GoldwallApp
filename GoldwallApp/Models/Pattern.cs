using System.ComponentModel.DataAnnotations;

namespace GoldwallApp.Models
{
    public class Pattern
    {

        public int PatternId { get; set; }  

        public int BusinessId { get; set; }

        [MaxLength(100)]
        public string? Title { get; set; }

        [MaxLength(255)]

        public string? Description { get; set; }

        public decimal Confidence { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
