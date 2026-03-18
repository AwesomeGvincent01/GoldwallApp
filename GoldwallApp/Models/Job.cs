using System;

namespace GoldwallApp.Models
{
    public class Job
    {
        //pk
        public int JobId { get; set; }


        //fk
        public int BusinessId { get; set; }
        public int ClientId { get; set; }

        public string Title { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }

        //planned dates need more exact time so we use DateTime instead of just Date
        public DateTime StartDatePlanned { get; set; }
        public DateTime EndDatePlanned { get; set; }

        public DateTime CreatedAt { get; set; }

        //navigation props
        public Business Business { get; set; }
        public Client Client { get; set; }
    }
}
