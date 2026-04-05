using System.ComponentModel.DataAnnotations;

namespace GoldwallApp.Models
{
    public class Material
    {

        //pk
        public int MaterialId { get; set; }

        //fk
        [Required]
        [StringLength(50)]
        [Display(Name = "Business")]
        public int BusinessId { get; set; }

        [Required] 
        [StringLength(50)]
        public string? Brand { get; set; }

        [StringLength(100)] 
        [Required]

        [Display(Name = "Product Name")]


        public string? ProductName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Material Type")]
        public string? MaterialType { get; set; }


        [StringLength(255)]

        public string? Notes { get; set; }


        public Business? Business { get; set; }
        public ICollection<EventContext>? EventContexts { get; set; }
    }
}
