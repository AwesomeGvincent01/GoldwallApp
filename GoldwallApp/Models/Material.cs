using System.ComponentModel.DataAnnotations;

namespace GoldwallApp.Models
{
    public class Material
    {

        //pk
        public int MaterialId { get; set; }

        //fk
        public int BusinessId { get; set; }

        [StringLength(50)]
        public string? Brand { get; set; }

        [StringLength(100)]

        public string? ProductName { get; set; }

        [StringLength(50)]
        public string? MaterialType { get; set; }


        [StringLength(255)]

        public string? Notes { get; set; }


        public Business? Business { get; set; }
    }
}
