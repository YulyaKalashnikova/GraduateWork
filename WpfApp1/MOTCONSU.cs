//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    
    public partial class MOTCONSU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MOTCONSU()
        {
            this.DATA_DIAGNOSIS = new HashSet<DATA_DIAGNOSIS>();
            this.DATA_DOCTOR_IN_CHARGE = new HashSet<DATA_DOCTOR_IN_CHARGE>();
        }
    
        public int MOTCONSU_ID { get; set; }
        public Nullable<System.DateTime> DATE_CONSULTATION { get; set; }
        public Nullable<System.DateTime> CREATE_DATE_TIME { get; set; }
        public Nullable<int> FK_PATIENTS_ID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DATA_DIAGNOSIS> DATA_DIAGNOSIS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DATA_DOCTOR_IN_CHARGE> DATA_DOCTOR_IN_CHARGE { get; set; }
        public virtual PATIENTS PATIENTS { get; set; }
    }
}
