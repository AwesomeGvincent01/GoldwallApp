using System.ComponentModel.DataAnnotations;

namespace GoldwallApp.Models
{
    public class Material
    {

        //pk
        public int MaterialId { get; set; }

        //fk
        [Display(Name = "Business")]
        public int BusinessId { get; set; }

        [Required] //ensures a material brand is entered
        [StringLength(50)] //limits the brand length
        public string? Brand { get; set; }

        [Required] //ensures the product name can't be blank
        [StringLength(100)] //limits product name length
        [Display(Name = "Product Name")]
        public string? ProductName { get; set; }

        [Required] //ensures each material has a type recorded
        [StringLength(50)] //limits the type length
        [Display(Name = "Material Type")]
        public string? MaterialType { get; set; }

        [StringLength(255)] //limits note length
        public string? Notes { get; set; }

        public Business? Business { get; set; }
        public ICollection<EventContext>? EventContexts { get; set; }
    }
}