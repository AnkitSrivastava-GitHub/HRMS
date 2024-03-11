using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRMS.Models
{
    public class Emp_Detail
    {
        [Required(ErrorMessage = "Mandal is mandatory")]
        public string Mandal_ID { get; set; }

        [Required(ErrorMessage = "District is mandatory")]
        public string District_ID { get; set; }

        //[Required(ErrorMessage = "City is mandatory")]
        //public string City { get; set; }

        [Required(ErrorMessage = "Pariyojana is mandatory")]
        public string Pariyojana_ID { get; set; }

        //public string Pariyojana { get; set; }

        [Required(ErrorMessage = "Designation is mandatory")]
        public string Designation_ID { get; set; }

        [Required(ErrorMessage = "Salary is mandatory")]
        public string Salary_ID { get; set; }

        //public string Designation { get; set; }

        //[Required(ErrorMessage = "Post is mandatory")]
        //public string Post { get; set; }
        //[Required(ErrorMessage = "Post is mandatory")]
        //public string Post_id { get; set; }
        //[Required(ErrorMessage = "State is mandatory")]
        //public string State { get; set; }

        //[Required(ErrorMessage = "Country is mandatory")]
        //public string Country { get; set; }

        //[Required(ErrorMessage = "PinCode is mandatory")]
        //public string PinCode { get; set; }
        public string RegistartionType { get; set; }

    }
}