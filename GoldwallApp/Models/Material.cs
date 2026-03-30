using System.ComponentModel.DataAnnotations;

namespace GoldwallApp.Models
{
    public class Material
    {

        //pk
        public int MaterialId { get; set; }

        //fk
        public int BusinessId { get; set; }

        [MaxLength(50)]
        public string? Brand { get; set; }

        [MaxLength(100)]

        public string? ProductName { get; set; }

        [MaxLength(50)]
        public string? MaterialType { get; set; }


        [MinLength(255)]

        public string? Notes { get; set; }


        public Business? Business { get; set; }
    }
}
