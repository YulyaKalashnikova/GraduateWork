﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class dbData : DbContext
    {
        public dbData()
            : base("name=dbData")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DATA_DIAGNOSIS> DATA_DIAGNOSIS { get; set; }
        public virtual DbSet<DATA_DOCTOR_IN_CHARGE> DATA_DOCTOR_IN_CHARGE { get; set; }
        public virtual DbSet<DATA_STAT_HOSPITALIZATION> DATA_STAT_HOSPITALIZATION { get; set; }
        public virtual DbSet<DATA_TRANSFERS> DATA_TRANSFERS { get; set; }
        public virtual DbSet<DIAGNOZ> DIAGNOZ { get; set; }
        public virtual DbSet<ED_PATIENTS_STATUS> ED_PATIENTS_STATUS { get; set; }
        public virtual DbSet<ED_TREATMENT_RESULTS> ED_TREATMENT_RESULTS { get; set; }
        public virtual DbSet<FM_DEP> FM_DEP { get; set; }
        public virtual DbSet<HO_BED> HO_BED { get; set; }
        public virtual DbSet<HO_BED_TYPE> HO_BED_TYPE { get; set; }
        public virtual DbSet<HO_RESERV> HO_RESERV { get; set; }
        public virtual DbSet<HO_ROOM> HO_ROOM { get; set; }
        public virtual DbSet<MEDDEP> MEDDEP { get; set; }
        public virtual DbSet<MEDECINS> MEDECINS { get; set; }
        public virtual DbSet<MOTCONSU> MOTCONSU { get; set; }
        public virtual DbSet<MOTCONSU_EVENT_TYPES> MOTCONSU_EVENT_TYPES { get; set; }
        public virtual DbSet<PATIENTS> PATIENTS { get; set; }
        public virtual DbSet<PL_EXAM> PL_EXAM { get; set; }
        public virtual DbSet<PLANNING> PLANNING { get; set; }
        public virtual DbSet<SPECIALISATION> SPECIALISATION { get; set; }
        public virtual DbSet<VID_STACIONARA> VID_STACIONARA { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<HO_RESERV_STATUS> HO_RESERV_STATUS { get; set; }
    }
}
