using System.ComponentModel.DataAnnotations;

namespace GoldwallApp.Models
{
    public class DefectType
    {
        public int DefectTypeId { get; set; }

        public int BusinessId { get; set; }



        [StringLength(50)]
        public string Name { get; set; }


        [StringLength(255)]
        public string Notes { get; set; }
    }
}
