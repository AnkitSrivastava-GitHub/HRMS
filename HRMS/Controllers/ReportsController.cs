using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMS.Models;

namespace HRMS.Controllers
{
    public class ReportsController : Controller
    {

        DB_HRMSEntities _db = new DB_HRMSEntities();
        //DB_HRMSEntities2 _db = new DB_HRMSEntities2();
        //DB_HRMSEntities3 _db = new DB_HRMSEntities3();
        public ActionResult District_Pariyojana_Verified_Count()
        {
            return View();
        }


        public ActionResult District_Pariyojana_Count()
        {
            return View();
        }

        public JsonResult District_Pariyojana_Wise_Count()
        {
            var obj = _db.sp_District_Pariyojana_RegType_Count_Report().ToList();
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public JsonResult District_Pariyojana_Reg_Wise_Doc_Count()
        {
            var obj = _db.sp_District_Pariyojana_RegType_Count_Report().ToList();
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Reg_Doc_Count()
        {
            return View();
        }

        public JsonResult Reg_Wise_Doc_Count()
        {
           
            var obj = _db.SP_REG_WISE_DOC_COUNT().ToList();
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Display()
        {
            var obj = _db.SP_REPORT_VERIFIED_COUNT().ToList();
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAllData()
        {
            return View();
        }
        
        public ActionResult GetEmpList()
        {
            var EmpList = _db.SP_REG_WISE_DOC_COUNT().ToList();
            return Json(new { data = EmpList }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult delete(int pk_Emp_id)
        {
            tbl_Employee_Registration User = _db.tbl_Employee_Registration.Find(pk_Emp_id);
            _db.tbl_Employee_Registration.Remove(User);
            _db.SaveChanges();
            return Json("success");
        }

        public ActionResult ReportPanel()
        {
            var AllRegisteredForm = _db.tbl_Employee_Registration.Count();
            string AllCount = AllRegisteredForm.ToString();
            ViewBag.AllCount = AllCount;

            var oldFormsCount = _db.tbl_Employee_Registration.Where(x=>x.Registration_Type== "OLD").Count();
            string AllOldCount = oldFormsCount.ToString();
            ViewBag.AllOldCount = AllOldCount;

            var NewFormsCount = _db.tbl_Employee_Registration.Where(x => x.Registration_Type == "NEW").Count();
            string AllNewCount = NewFormsCount.ToString();
            ViewBag.AllNewCount = AllNewCount;

            var VerifiedFormsCount = _db.tbl_Employee_Registration.Where(x => x.Verify_Status =="1").Count();
            string AllVerifiedCount = VerifiedFormsCount.ToString();
            ViewBag.AllVerifiedCount = AllVerifiedCount;

            var DocsCount = (from x in _db.tbl_Employee_Docs
                             join a in _db.tbl_Employee_Registration
                              on x.fk_Emp_Id equals a.pk_Emp_id
                             select new { x.fk_Emp_Id }
                       ).Distinct().Count();
            string UploadedDocsCount = DocsCount.ToString();
            ViewBag.UploadedDocsCount = UploadedDocsCount;

            return View();
        }


        public JsonResult BindMandal()
        {
            var obj = _db.Tbl_Master_Mandal.ToList();
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public JsonResult BindDistrict(int fk_Mandal_id)
        {
            var obj = _db.Tbl_Master_District.Where(x=>x.fk_Mandal_id==fk_Mandal_id).ToList();
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

       public JsonResult District_Pariyojana_Reg_Wise_Doc_Count_Filter(int pk_id,int pk_Dis_ID)
        {
            var obj = _db.SP_REG_WISE_DOC_COUNT_FILTER(pk_id,pk_Dis_ID).ToList();
            return Json(obj,JsonRequestBehavior.AllowGet);
        }

        public ActionResult District_Pariyojana_RegCount_DocCount_View()
        {
            return View();
        }

        public JsonResult District_Pariyojana_RegCount_DocCount()
        {
            var obj = _db.SP_DIST_PARIYOJANA_REG_DOC_COUNT().ToList();
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
    }
}