using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using HRMS.Models;
using System.IO;

namespace HRMS.Controllers
{
    public class AdminController : Controller
    {

        DB_HRMSEntities db = new DB_HRMSEntities();
        ////DB_HRMSEntities2 db = new DB_HRMSEntities2();
        //DB_HRMSEntities3 db = new DB_HRMSEntities3();
        Common_Code com = new Common_Code();

        public ActionResult Index()
        {
            return View();
        }


        #region  Login
        public ActionResult Login()
        {
            string cook_val = "USER";
            com.Set_Cookies(cook_val);
            return View();

        }

        [HttpPost]
        public JsonResult Login(string name, string password)
        {

            var result = (from a in db.tbl_UserDetail
                          where a.UserName == name
 && a.Password == password
                          select a).ToList();
            bool status = false;
            string cook_val = "";
            if (result.Count != 0)
            {
                status = true;
                cook_val = result[0].Pk_Login_Id.ToString() + "#" + result[0].UserName;
                com.Set_Cookies(cook_val);
            }
            return Json(new { success = status, responseText = "" }, JsonRequestBehavior.AllowGet);


        }

        #endregion


        #region dashboard
        public ActionResult Dashboard()        {


            #region dashboard
            var result = (from a in db.tbl_Employee_Registration                          select a.pk_Emp_id).Count();            ViewBag.tot_count = result;            var pendingform = (from a in db.tbl_Employee_Registration
                               where a.Verify_Status == null
                               select a.pk_Emp_id).Count();            ViewBag.pending = pendingform;            var verifyform = (from a in db.tbl_Employee_Registration
                              where a.Verify_Status != null
                              select a.pk_Emp_id).Count();            ViewBag.verifyform = verifyform;


            var newreg = (from a in db.tbl_Employee_Registration
                          where a.Registration_Type == "NEW"
                          select a.pk_Emp_id).Count();            ViewBag.newreg = newreg;            var oldreg = (from a in db.tbl_Employee_Registration                          where a.Registration_Type == "OLD"                          select a.pk_Emp_id).Count();            ViewBag.oldreg = oldreg;




            #endregion
            #region Prayagraj
            var Prayagraj = (from a in db.tbl_Employee_Registration
                             where a.fk_Mandal_id == 1
                             select a.pk_Emp_id).Count();            ViewBag.Prayagraj = Prayagraj;            var Prayagrajup = (from a in db.tbl_Employee_Docs
                               join b in db.tbl_Employee_Registration
                               on a.fk_Emp_Id equals b.pk_Emp_id
                               where b.fk_Mandal_id == 1
                               select a.fk_Emp_Id).Distinct().Count();            ViewBag.Prayagrajup = Prayagrajup;


            var Prayagrajveri = (from a in db.tbl_Employee_Docs
                                 join b in db.tbl_Employee_Registration
                                 on a.fk_Emp_Id equals b.pk_Emp_id
                                 where b.fk_Mandal_id == 1 && a.Verify_Status != null
                                 select a.fk_Emp_Id).Distinct().Count();            ViewBag.Prayagrajveri = Prayagrajveri;





            #endregion


            #region Azamgarh            var Azamgarh = (from a in db.tbl_Employee_Registration
                                                         where a.fk_Mandal_id == 2
                                                         select a.pk_Emp_id).Count();
            ViewBag.Azamgarh = Azamgarh;            var Azamgarhup = (from a in db.tbl_Employee_Docs
                              join b in db.tbl_Employee_Registration
                              on a.fk_Emp_Id equals b.pk_Emp_id
                              where b.fk_Mandal_id == 2
                              select a.fk_Emp_Id).Distinct().Count();            ViewBag.Azamgarhup = Azamgarhup;            var Azamgarhveri = (from a in db.tbl_Employee_Docs                                join b in db.tbl_Employee_Registration                                on a.fk_Emp_Id equals b.pk_Emp_id                                where b.fk_Mandal_id == 2 && a.Verify_Status != null                                select a.fk_Emp_Id).Distinct().Count();            ViewBag.Azamgarhveri = Azamgarhveri;





            #endregion

            #region Chitrakoot
            var Chitrakoot = (from a in db.tbl_Employee_Registration
                              where a.fk_Mandal_id == 3
                              select a.pk_Emp_id).Count();            ViewBag.Chitrakoot = Chitrakoot;            var Chitrakootup = (from a in db.tbl_Employee_Docs
                                join b in db.tbl_Employee_Registration
                                on a.fk_Emp_Id equals b.pk_Emp_id
                                where b.fk_Mandal_id == 3
                                select a.fk_Emp_Id).Distinct().Count();            ViewBag.Chitrakootup = Chitrakootup;            var Chitrakootveri = (from a in db.tbl_Employee_Docs
                                  join b in db.tbl_Employee_Registration
                                  on a.fk_Emp_Id equals b.pk_Emp_id
                                  where b.fk_Mandal_id == 3 && a.Verify_Status != null
                                  select a.fk_Emp_Id).Distinct().Count();            ViewBag.Chitrakootveri = Chitrakootveri;





            #endregion


            #region mirzapur
            var Mirzapur = (from a in db.tbl_Employee_Registration
                            where a.fk_Mandal_id == 4
                            select a.pk_Emp_id).Count();            ViewBag.Mirzapur = Mirzapur;            var Mirzapurup = (from a in db.tbl_Employee_Docs
                              join b in db.tbl_Employee_Registration
                              on a.fk_Emp_Id equals b.pk_Emp_id
                              where b.fk_Mandal_id == 4
                              select a.fk_Emp_Id).Distinct().Count();            ViewBag.Mirzapurup = Mirzapurup;            var Mirzapurveri = (from a in db.tbl_Employee_Docs
                                join b in db.tbl_Employee_Registration
                                on a.fk_Emp_Id equals b.pk_Emp_id
                                where b.fk_Mandal_id == 4 && a.Verify_Status != null
                                select a.fk_Emp_Id).Distinct().Count();            ViewBag.Mirzapurveri = Mirzapurveri;





            #endregion

            #region varanasi
            var Varanasi = (from a in db.tbl_Employee_Registration
                            where a.fk_Mandal_id == 5
                            select a.pk_Emp_id).Count();            ViewBag.Varanasi = Varanasi;            var Varanasiup = (from a in db.tbl_Employee_Docs                              join b in db.tbl_Employee_Registration                              on a.fk_Emp_Id equals b.pk_Emp_id                              where b.fk_Mandal_id == 5                              select a.fk_Emp_Id).Distinct().Count();            ViewBag.Varanasiup = Varanasiup;            var Varanasiveri = (from a in db.tbl_Employee_Docs                                join b in db.tbl_Employee_Registration                                on a.fk_Emp_Id equals b.pk_Emp_id                                where b.fk_Mandal_id == 5 && a.Verify_Status != null                                select a.fk_Emp_Id).Distinct().Count();            ViewBag.Varanasiveri = Varanasiveri;




            #endregion




            return View();

        }

        [HttpPost]
        public JsonResult Dashboard_Value()
        {

            var result = (from a in db.tbl_Employee_Registration
                          select a.pk_Emp_id).Count();


            return Json(new { success = true, responseText = result }, JsonRequestBehavior.AllowGet);

        }

        public JsonResult incomplete()
        {
            var result = (from a in db.tbl_Employee_Registration
                          where a.Verify_Status == null
                          select a.pk_Emp_id).Count();
            return Json(new { success = true, responseText = result }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult newreg()
        {
            var result = (from a in db.tbl_Employee_Registration
                          where a.Registration_Type=="NEW"
                          select a.pk_Emp_id).Count();
            return Json(new { success = true, responseText = result }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult oldreg()
        {
            var result = (from a in db.tbl_Employee_Registration
                          where a.Registration_Type=="OLD"
                          select a.pk_Emp_id).Count();
            return Json(new { success = true, responseText = result }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult complete()
        {


            var result = (from a in db.tbl_Employee_Registration
                          where a.Verify_Status != null
                          select a.pk_Emp_id).Count();


            return Json(new { success = true, responseText = result }, JsonRequestBehavior.AllowGet);
        }



        #endregion


        #region Report

        public ActionResult Report()
        {
            return View();
        }

        public JsonResult bind_candidate()        {            var result = (from a in db.tbl_Employee_Registration                          orderby a.Emp_Code                          select new { a.pk_Emp_id, a.Emp_Code }).Distinct().ToList();            return Json(result, JsonRequestBehavior.AllowGet);        }

        public JsonResult Bind_Janpad()
        {
            var result = (from a in db.Tbl_Master_Mandal
                          orderby a.Mandal_Name
                          select new { a.pk_id, a.Mandal_Name }).Distinct().ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Bind_District(int StateID)
        {
            var result = (from a in db.Tbl_Master_District
                          where a.fk_Mandal_id == StateID
                          orderby a.District_Name
                          select new { a.pk_Dis_ID, a.District_Name }).Distinct().ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        //public JsonResult Bind_List(int districtid, int mandalid)
        //{
        //    var result = (from a in db.tbl_Employee_Registration
        //                  where a.fk_Dist_Id == districtid && a.fk_Mandal_id == mandalid
        //                  orderby a.pk_Emp_id
        //                  select a.pk_Emp_id).ToList().Count();
        //    if (result != 0)
        //    {
        //        //var response = (from a in db.tbl_Employee_Registration
        //        //                where a.fk_Dist_Id == districtid && a.fk_Mandal_id == mandalid
        //        //                orderby a.pk_Emp_id
        //        //                select a).ToList();

        //        var offer = (from p in db.tbl_Employee_Registration
        //                     where p.fk_Dist_Id == districtid && p.fk_Mandal_id == mandalid
        //                     select new
        //                     {
        //                         Emp_Code = p.Emp_Code,
        //                         Mandal_Name = p.Mandal_Name,
        //                         District_Name = p.District_Name,
        //                         Emp_Name = p.Emp_Name,
        //                         F_Name = p.F_Name,
        //                         DOB = p.DOB,
        //                         Gender = p.Gender,
        //                         Address = p.Address,
        //                         Mobile_No = p.Mobile_No,
        //                         Alternate_Mob_No = p.Alternate_Mob_No,
        //                         Identification_Id = p.Identification_Id,
        //                         Aadhar_No = p.Aadhar_No,
        //                         PAN_NO = p.PAN_NO,
        //                         Email_id = p.Email_id,
        //                         SPR_NO = p.SPR_NO,
        //                         Emp_Category = p.Emp_Category,
        //                         Sub_category = p.Sub_category,
        //                         Bank_Name = p.Bank_Name,
        //                         Account_No = p.Account_No,
        //                         IFSC_Code = p.IFSC_Code,
        //                         Branch_Name = p.Branch_Name,
        //                         UAN_No = p.UAN_No,
        //                         ESIC_No = p.ESIC_No,
        //                         Physically_Challenged = p.Physically_Challenged,
        //                         Exp_In_Yrs = p.Exp_In_Yrs
        //                     })
        //             .ToList()
        //             .Select(x => new
        //             {
        //                 Emp_Code = x.Emp_Code,
        //                 Mandal_Name = x.Mandal_Name,
        //                 District_Name = x.District_Name,
        //                 Emp_Name = x.Emp_Name,
        //                 F_Name = x.F_Name,

        //                 Gender = x.Gender,
        //                 Address = x.Address,
        //                 Mobile_No = x.Mobile_No,
        //                 Alternate_Mob_No = x.Alternate_Mob_No == null ? "" : x.Alternate_Mob_No,
        //                 Identification_Id = x.Identification_Id,
        //                 Aadhar_No = x.Aadhar_No,
        //                 PAN_NO = x.PAN_NO,
        //                 Email_id = x.Email_id,
        //                 SPR_NO = x.SPR_NO,
        //                 Emp_Category = x.Emp_Category,
        //                 Sub_category = x.Sub_category,
        //                 Bank_Name = x.Bank_Name,
        //                 Account_No = x.Account_No,
        //                 IFSC_Code = x.IFSC_Code,
        //                 Branch_Name = x.Branch_Name,
        //                 UAN_No = x.UAN_No,
        //                 ESIC_No = x.ESIC_No,
        //                 Physically_Challenged = x.Physically_Challenged,
        //                 Exp_In_Yrs = x.Exp_In_Yrs,
        //                 DOB = Convert.ToDateTime(x.DOB).ToString("dd.MMM.yyyy")
        //             }).ToList();
        //        return Json(offer, JsonRequestBehavior.AllowGet);

        //    }

        //    else
        //    {
        //        var response = "";
        //        return Json(response, JsonRequestBehavior.AllowGet);
        //    }
        //    // return Json(result, JsonRequestBehavior.AllowGet);
        //}

        #endregion

        public JsonResult Bind_List(int districtid, int mandalid)        {



            ViewBag.disid = districtid;            ViewBag.mandid = mandalid;            var result = (from a in db.tbl_Employee_Registration                          where a.fk_Dist_Id == districtid && a.fk_Mandal_id == mandalid                          orderby a.pk_Emp_id                          select a.pk_Emp_id).ToList().Count();            if (result != 0)            {


                var offer = (from p in db.tbl_Employee_Registration                             where p.fk_Dist_Id == districtid && p.fk_Mandal_id == mandalid                             select new                             {

                                 pk_Emp_id = p.pk_Emp_id,                                 Emp_Code = p.Emp_Code,                                 Mandal_Name = p.Mandal_Name,                                 District_Name = p.District_Name,                                 Emp_Name = p.Emp_Name,                                 F_Name = p.F_Name,                                 DOB = p.DOB,                                 Gender = p.Gender,                                 Address = p.Address,                                 Mobile_No = p.Mobile_No,                                 Alternate_Mob_No = p.Alternate_Mob_No,                                 Identification_Id = p.Identification_Id,                                 Aadhar_No = p.Aadhar_No,                                 PAN_NO = p.PAN_NO,                                 Email_id = p.Email_id,                                 SPR_NO = p.SPR_NO,                                 Emp_Category = p.Emp_Category,                                 Sub_category = p.Sub_category,                                 Bank_Name = p.Bank_Name,                                 Account_No = p.Account_No,                                 IFSC_Code = p.IFSC_Code,                                 Branch_Name = p.Branch_Name,                                 UAN_No = p.UAN_No,                                 ESIC_No = p.ESIC_No,                                 Physically_Challenged = p.Physically_Challenged,                                 Exp_In_Yrs = p.Exp_In_Yrs,                                 Verify_Status = p.Verify_Status                             })                     .ToList()                     .Select(x => new                     {

                         pk_Emp_id = x.pk_Emp_id,                         Emp_Code = x.Emp_Code,                         Mandal_Name = x.Mandal_Name,                         District_Name = x.District_Name,                         Emp_Name = x.Emp_Name,                         F_Name = x.F_Name,                         Gender = x.Gender,                         Address = x.Address,                         Mobile_No = x.Mobile_No,                         Alternate_Mob_No = x.Alternate_Mob_No == null ? "" : x.Alternate_Mob_No,                         Identification_Id = x.Identification_Id,                         Aadhar_No = x.Aadhar_No,                         PAN_NO = x.PAN_NO,                         Email_id = x.Email_id,                         SPR_NO = x.SPR_NO,                         Emp_Category = x.Emp_Category,                         Sub_category = x.Sub_category,                         Bank_Name = x.Bank_Name,                         Account_No = x.Account_No,                         IFSC_Code = x.IFSC_Code,                         Branch_Name = x.Branch_Name,                         UAN_No = x.UAN_No,                         ESIC_No = x.ESIC_No,                         Physically_Challenged = x.Physically_Challenged,                         Exp_In_Yrs = x.Exp_In_Yrs,                         DOB = Convert.ToDateTime(x.DOB).ToString("dd.MMM.yyyy"),                         Verify_Status = x.Verify_Status                     }).ToList();




                return Json(offer, JsonRequestBehavior.AllowGet);            }

            else            {                var response = "";                return Json(response, JsonRequestBehavior.AllowGet);            }
            // return Json(result, JsonRequestBehavior.AllowGet);
        }



        #region upload
        [HttpGet]
        public ActionResult Upload_Notice()
        {
            return View();
        }



        [HttpPost]        public ActionResult Upload_Notice(FILE_UPLOAD_ADMIN ADMIN, string txt, string mandal, string candidate)        {            var FILES = ADMIN.File;            ViewBag.Message = "";            try            {                if (txt.Length != 0)                {                    if (FILES != null)                    {                        var InputFileName = Path.GetFileName(FILES.FileName);
                        string DocumentPath = "/UploadDocument/" + FILES.FileName;
                        FILES.SaveAs(Server.MapPath("/UploadDocument/" + FILES.FileName));
                        BinaryReader reader = new BinaryReader(FILES.InputStream);
                        string myFilePath = FILES.FileName;                        var cand = Convert.ToInt32(candidate);                                                Tbl_Notice notice = new Tbl_Notice();                                               notice.Notice_Path = DocumentPath;                        notice.Notice_Name = txt;                        notice.Fk_Emp_id = cand;                        notice.Fk_Mandal_id = mandal;                        notice.Is_Active = true;                                               db.Tbl_Notice.Add(notice);                        db.SaveChanges();
                       

                        ViewBag.Message = "File Uploaded Successfully!!";                        return View();                    }



                    else                    {

                        ViewBag.Message = "Pleae Select file";                        return View();                    }                }                else
                {                    ViewBag.Message = "Pleae Enter Title";                    return View();                }            }

            catch
            {                ViewBag.Message = "File upload failed!!";                return View();            }

        }







        #endregion








        #region  Check Cookies
        public JsonResult check_cookies()
        {
            bool retval = false;
            string user_type = "admin";
            if (user_type == "admin") { retval = true; }
            return Json(new { success = retval, responseText = "" }, JsonRequestBehavior.AllowGet);
        }


        #endregion




        #region doc
        public ActionResult doc()        {            return View();        }



        public JsonResult Verify_Doc(string Emp_Code)        {            string Emp_Codee = Emp_Code;            var res = (from a in db.tbl_Employee_Docs
                       where a.Emp_Code == Emp_Codee && a.Verify_Status == null
                       select new { a.pk_Doc_Id }).Count();            if (res == 0)            {                var response = "";                return Json(response, JsonRequestBehavior.AllowGet);            }            else

            {
                //var result = db.Proc_verify_document(Emp_Code).ToList();
                var result = (from a in db.tbl_Employee_Docs                              join b in db.tbl_Employee_Registrationon a.fk_Emp_Id equals b.pk_Emp_id                              where a.Emp_Code == Emp_Code && a.Doc_Path != null                              select new                              {                                  b.Emp_Name,                                  b.Emp_Category,                                  b.District_Name,                                  b.Designation,                                  b.Pariyojana,                                  b.F_Name,                                  b.DOB,                                  b.Gender,                                  b.Mandal_Name,                                  a.Emp_Code,                                  a.Doc_Name,                                  a.Doc_Type,                                  a.pk_Doc_Id,                                  a.Doc_Path,                                  b.Mobile_No,                                  b.ESIC_No,                                  b.PAN_NO,                                  b.Aadhar_No,                                  b.UAN_No                              }).ToList().Select(x => new                              {                                  x.Emp_Name,                                  x.Emp_Category,                                  x.District_Name,                                  x.Designation,                                  x.Pariyojana,                                  x.F_Name,                                  DOB = Convert.ToDateTime(x.DOB).ToString("dd.MMM.yyyy"),                                  x.Gender,                                  x.Mandal_Name,                                  x.Emp_Code,                                  x.Doc_Name,                                  x.Doc_Path,                                  x.pk_Doc_Id,                                  x.Doc_Type,                                  x.Mobile_No,                                  x.ESIC_No,                                  x.PAN_NO,                                  x.Aadhar_No,                                  x.UAN_No                              }).ToList();                return Json(result, JsonRequestBehavior.AllowGet);            }




        }        public JsonResult Verification(string Emp_Code)        {            var result = db.Proc_Verify_doc_Admin(Emp_Code).ToList();            return Json(result, JsonRequestBehavior.AllowGet);        }        #endregion

    }
}