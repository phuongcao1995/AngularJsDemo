using System.ComponentModel;

namespace CasePortal.ViewModel
{
    public class LogViewModel
    {
        public int Id { get; set; }

        [DisplayName("Log#")]
        public string Name { get; set; }

        [DisplayName("IPRA/COPA Notification Date")]
        public string NotificationDate { get; set; }

        [DisplayName("Incident Date & Time")]
        public string IncidentDate { get; set; }

        public int DistrictId { get; set; }

        [DisplayName("District of Occurrence")]
        public string DistrictName { get; set; }
        public int IncidentTypeId { get; set; }

        [DisplayName("Incident Types")]
        public string IncidentTypeName { get; set; }

        public string CreateAt { get; set; }

    }
}