using GoldwallApp.Models;

namespace GoldwallApp.ViewModels
{
    public class ClientsViewModel
    {
        public int TotalClientsCount { get; set; }

        public int ClientsWithEmailCount { get; set; }

        public int ClientsWithoutEmailCount { get; set; }

        public List<Client> ClientsList { get; set; } = new();
    }
}