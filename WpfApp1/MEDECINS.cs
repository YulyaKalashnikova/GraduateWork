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
    
    public partial class MEDECINS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MEDECINS()
        {
            this.DATA_DOCTOR_IN_CHARGE = new HashSet<DATA_DOCTOR_IN_CHARGE>();
            this.DATA_STAT_HOSPITALIZATION = new HashSet<DATA_STAT_HOSPITALIZATION>();
            this.MEDDEP = new HashSet<MEDDEP>();
        }
    
        public int MEDECINS_ID { get; set; }
        public string NOM { get; set; }
        public string PRENOM { get; set; }
        public string PATRONYME { get; set; }
        public string SURNAME_IO { get; set; }
        public string LOGIN { get; set; }
        public string TELEMED_PASSWORD { get; set; }
        public Nullable<int> FK_SPECIALISATION_ID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DATA_DOCTOR_IN_CHARGE> DATA_DOCTOR_IN_CHARGE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DATA_STAT_HOSPITALIZATION> DATA_STAT_HOSPITALIZATION { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MEDDEP> MEDDEP { get; set; }
        public virtual SPECIALISATION SPECIALISATION { get; set; }
    }
}
