using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Models
{
    public class ReturnData
    {
        public int pk_Emp_id { get; set; }
        public string Emp_Code { get; set; }
        public Nullable<int> fk_Mandal_id { get; set; }
        public string Mandal_Name { get; set; }
        public Nullable<int> fk_Dist_Id { get; set; }
        public string District_Name { get; set; }
        public Nullable<int> fk_Pariyojana_ID { get; set; }
        public string Pariyojana { get; set; }
        public Nullable<int> fk_Designation_ID { get; set; }
        public string Designation { get; set; }
        public string Salary { get; set; }
        public Nullable<int> Emp_post_id { get; set; }
        public string Emp_post_Add { get; set; }
        public string Postal_Code { get; set; }
        public string Emp_Name { get; set; }
        public string F_Name { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string Address { get; set; }
        public string Mobile_No { get; set; }
        public string Alternate_Mob_No { get; set; }
        public string Aadhar_No { get; set; }
        public string Gender { get; set; }
        public string PAN_NO { get; set; }
        public string Email_id { get; set; }
        public string Password { get; set; }
        public string SPR_NO { get; set; }
        public string Emp_Category { get; set; }
        public string Sub_category { get; set; }
        public string Bank_Name { get; set; }
        public string Account_No { get; set; }
        public string IFSC_Code { get; set; }
        public string Branch_Name { get; set; }
        public string UAN_No { get; set; }
        public string ESIC_No { get; set; }
        public string Nationality { get; set; }
        public string Corres_Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Physically_Challenged { get; set; }
        public string Territory { get; set; }
        public Nullable<int> Exp_In_Yrs { get; set; }
        public string Photo { get; set; }
        public string Sign { get; set; }
        public string Is_Active { get; set; }
        public Nullable<System.DateTime> Created_date { get; set; }
        public string Profile_Status { get; set; }
        public string Verify_Status { get; set; }
        public string Verified_By { get; set; }
        public Nullable<System.DateTime> Verify_Date { get; set; }
        public string Verify_Remark { get; set; }
        public string Identification_Id { get; set; }
        public string field_3 { get; set; }
    }
}