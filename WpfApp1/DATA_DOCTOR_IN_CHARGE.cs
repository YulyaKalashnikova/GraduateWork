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
    
    public partial class DATA_DOCTOR_IN_CHARGE
    {
        public int DATA_DOCTOR_IN_CHARGE_ID { get; set; }
        public Nullable<System.DateTime> DATA_NAZNAHENIQ { get; set; }
        public Nullable<int> FK_MOTCONSU_ID { get; set; }
        public Nullable<int> FK_MEDECINS_ID { get; set; }
    
        public virtual MEDECINS MEDECINS { get; set; }
        public virtual MOTCONSU MOTCONSU { get; set; }
    }
}
