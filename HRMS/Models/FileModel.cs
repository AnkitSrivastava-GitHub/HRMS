using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRMS.Models
{
    public class FileModel
    {
        [Required(ErrorMessage = "Please select file.")]
        //[Display(Name = "Browse File")]
        //[RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.jpeg)$", ErrorMessage = "Only Image files allowed and should be 5MB or lower.")]
        public HttpPostedFileBase[] files { get; set; }

       // public int fk_Emp_Id { get; set; }
    }
}