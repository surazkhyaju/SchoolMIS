//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SchoolMISDayLog.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Component
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Component()
        {
            this.ComponentStatusHistories = new HashSet<ComponentStatusHistory>();
            this.ControllerDetails = new HashSet<ControllerDetail>();
        }
    
        public int ComponentId { get; set; }
        public string ComponentName { get; set; }
        public string Status { get; set; }
        public int DeveloperId { get; set; }
        public int ModuleId { get; set; }
        public int CreatedByUserId { get; set; }
        public string CreatedByUserName { get; set; }
        public System.DateTime CreatedByUSerDate { get; set; }
    
        public virtual Developer Developer { get; set; }
        public virtual Module Module { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ComponentStatusHistory> ComponentStatusHistories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ControllerDetail> ControllerDetails { get; set; }
    }
}
