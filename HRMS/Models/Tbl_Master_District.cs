//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HRMS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_Master_District
    {
        public int pk_Dis_ID { get; set; }
        public string District_Name { get; set; }
        public Nullable<int> fk_Mandal_id { get; set; }
        public string DistrictCode { get; set; }
        public string Field_1 { get; set; }
    }
}
