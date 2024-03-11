using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMS.Models;

namespace HRMS.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        DB_HRMSEntities _db = new DB_HRMSEntities();
        //DB_HRMSEntities2 _db = new DB_HRMSEntities2();
        //DB_HRMSEntities3 _db = new DB_HRMSEntities3();
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public JsonResult Employee_login(string Emp_Code, string Emp_Password)
        {
            var result = _db.Emp_Login(Emp_Code, Emp_Password).ToList();
            bool status = false;
            string msg = "No record found !";
            if (result.Count != 0)
            {
                if (result[0].msg != "")
                {
                    msg = result[0].msg;
                    status = false;
                    
                }

                else
                {
                    var data = _db.Tbl_Emp_Credential.Where(x => x.Emp_Code == Emp_Code).FirstOrDefault();
                    //Session["Identification_Id"] = data.Emp_Code;
                    Temp_Data Emp_data = new Temp_Data { fk_Emp_id = Convert.ToInt32(data.Fk_Emp_Id) };
                    TempData["pk_Emp_d"] = Emp_data;
                    msg = "";
                    status = true;
                }
            }
            return Json(new { success = status, responseText = msg }, JsonRequestBehavior.AllowGet);
        }
        
    }
}