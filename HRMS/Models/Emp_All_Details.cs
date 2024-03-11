using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRMS.Models
{
    public class Emp_All_Details
    {
        public int pk_Emp_id { get; set; }

        [Required(ErrorMessage = "Employee Name is mandatory")]
        public string Emp_Name { get; set; }

        [Required(ErrorMessage = "Father Name is mandatory")]
        public string F_Name { get; set; }

        [Required(ErrorMessage = "Date Of Birth is mandatory")]
        [DataType(DataType.Date)]
        [Range(typeof(DateTime), "1/1/1900", "1/1/2010",ErrorMessage = "Invalid date of birth !")]

        public DateTime? DOB { get; set; }

        [Required(ErrorMessage = "Address is mandatory")]     
        public string Address { get; set; }

        [Required(ErrorMessage = "Mobile Number is mandatory")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number!")]
        public string Mobile_No { get; set; }

        //[Required(ErrorMessage = "State is mandatory")]
        public string Alternate_Mob_No { get; set; }

        [Required(ErrorMessage = "Aadhar Number is mandatory")]
        [RegularExpression(@"^([0-9]{12})$", ErrorMessage = "Invalid Aadhar number!")]
        public string Aadhar_No { get; set; }


        [Required(ErrorMessage = "Gender is mandatory")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "PAN Number is mandatory")]
        [RegularExpression("^([A-Za-z]){5}([0-9]){4}([A-Za-z]){1}$", ErrorMessage = "Invalid PAN Number !")]
        public string PAN_NO { get; set; }

        [Required(ErrorMessage = "Email id is mandatory")]
        [EmailAddress]
        public string Email_id { get; set; }
        //public string Password { get; set; }

        [Required(ErrorMessage = "SPR Number is mandatory")]
        public string SPR_NO { get; set; }

        [Required(ErrorMessage = "Employee Category is mandatory")]
        public string Emp_Category { get; set; }

        //[Required(ErrorMessage = "Sub category is mandatory")]
        public string Sub_category { get; set; }

        [Required(ErrorMessage = "Bank Name is mandatory")]
        public string Bank_Name { get; set; }

        [Required(ErrorMessage = "Account Number is mandatory")]
        public string Account_No { get; set; }

        [Required(ErrorMessage = "Please Confirm Account Number !")]
        [Compare(nameof(Account_No), ErrorMessage = "AccountNumber do not match !")]
        public string Confirm_Account_No { get; set; }

        [Required(ErrorMessage = "IFSC Code is mandatory")]
        public string IFSC_Code { get; set; }

        [Required(ErrorMessage = "Branch Name is mandatory")]
        public string Branch_Name { get; set; }

        [Required(ErrorMessage = "UAN Number is mandatory")]
        public string UAN_No { get; set; }

        [Required(ErrorMessage = "ESIC Number is mandatory")]
        public string ESIC_No { get; set; }

        //[Required(ErrorMessage = "State is mandatory")]
        public string Nationality { get; set; }

        [Required(ErrorMessage = "Correspondence Address is mandatory")]
        public string Corres_Address { get; set; }

        [Required(ErrorMessage = "Are you Physically Challenged ?")]
        public string Physically_Challenged { get; set; }
        //public string Territory { get; set; }

        [Required(ErrorMessage = "Please fill your Experience in Years !")]
        public Nullable<int> Exp_In_Yrs { get; set; }
        //public string Img { get; set; }
        //public string Profile_Status { get; set; }

        //[Required(ErrorMessage = "Post is mandatory")]
        public string Post { get; set; }

        //[Required(ErrorMessage = "Mandal is mandatory")]
        public string Mandal { get; set; }

        //[Required(ErrorMessage = "District is mandatory")]
        public string District { get; set; }


        //[Required(ErrorMessage = "City is mandatory")]
        public string City { get; set; }

        //[Required(ErrorMessage = "State is mandatory")]
        public string State { get; set; }

        //[Required(ErrorMessage = "Country is mandatory")]
        public string Country { get; set; }

        //[Required(ErrorMessage = "PinCode is mandatory")]
        public string PinCode { get; set; }

        public string Salary { get; set; }

        //[Required(ErrorMessage = "Pariyojana is mandatory")]
        public string Pariyojana { get; set; }

        //public string Pariyojana { get; set; }

        //[Required(ErrorMessage = "Designation is mandatory")]
        public string Designation { get; set; }

        //[Required(ErrorMessage = "Salary is mandatory")]
        //public string Salary_ID { get; set; }

        //public string Designation { get; set; }

        public string RegistartionType { get; set; }
    }
   
}