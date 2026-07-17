namespace GoldwallApp.ViewModels;
using GoldwallApp.Models;

    public class EvidencePhotosViewModel
    {
        public List<EvidencePhoto> EvidencePhotos { get; set; } = new List<EvidencePhoto>();

        public EvidencePhoto? SelectedPhoto { get; set; }
    }

