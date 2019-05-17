//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CasePortal.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Log
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Log()
        {
            this.Documents = new HashSet<Document>();
            this.Media = new HashSet<Medium>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public System.DateTime NotificationDate { get; set; }
        public System.DateTime IncidentDate { get; set; }
        public int DistrictId { get; set; }
        public int IncidentTypeId { get; set; }
        public Nullable<System.DateTime> CreateAt { get; set; }
    
        public virtual District District { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Document> Documents { get; set; }
        public virtual IncidentType IncidentType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Medium> Media { get; set; }
    }
}
