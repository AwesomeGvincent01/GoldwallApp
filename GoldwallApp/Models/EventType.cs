using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


  namespace GoldwallApp.Models;

    public class EventType {


    //pk
    public int EventTypeId { get; set; }


    //business fk

    [Display(Name = "Business")]
    public int BusinessId { get; set; }

    public string Name { get; set; }

    public string Categoery { get; set; }

    [Display(Name = "Is Active")]
    public bool IsActive { get; set; }

    public Business Business { get; set; }

    public ICollection<WorkEvent> WorkEvents { get; set; }

}
}
