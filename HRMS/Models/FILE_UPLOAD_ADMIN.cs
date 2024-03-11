using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Models
{
    public class FILE_UPLOAD_ADMIN
    {
        public int PK_Notice_ID { get; set; }
        public string Notice_Path { get; set; }
        public string Notice_Name { get; set; }
        public Nullable<bool> Is_Active { get; set; }
        public string Notice_Type { get; set; }
        public Nullable<long> Fk_Emp_id { get; set; }
        public string Fk_Mandal_id { get; set; }

        public HttpPostedFileWrapper File { get; set; }
    }
}