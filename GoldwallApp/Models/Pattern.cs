using System.ComponentModel.DataAnnotations;

namespace GoldwallApp.Models
{
    public class Pattern
    {

        public int PatternId { get; set; }  

        public int BusinessId { get; set; }

        [StringLength(100)]
        public string? Title { get; set; }

        [StringLength(255)]

        public string? Description { get; set; }

        public decimal Confidence { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
