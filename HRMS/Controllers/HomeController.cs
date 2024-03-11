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
using Newtonsoft.Json;

namespace HRMS.Controllers
{
    public class HomeController : Controller
    {
        DB_HRMSEntities _db = new DB_HRMSEntities();
        //DB_HRMSEntities2 _db = new DB_HRMSEntities2();

        //DB_HRMSEntities3 _db = new DB_HRMSEntities3();
        
        //DataSet ds = new DataSet();

        #region Index GetMethod
        public ActionResult Index()
        {
            Emp_All_Details obj1 = new Emp_All_Details();
            //Tbl_Master_Mandal obj1 = new Tbl_Master_Mandal();

            BindCategoryWithViewBag();
            BindGender();
            BindPhysically_Disabled();
            GetMandalDistrictNameById();
            
            return View(obj1);
        }
        #endregion

        #region function to get MandalName,DistrictName,ParioyjanaName and designation
        protected void GetMandalDistrictNameById()
        {
            if (Session["Mandal_ID"] != null && Session["District_ID"] != null && Session["Pariyojana_ID"] != null && Session["Designation_ID"] != null && Session["Salary_ID"] != null)
            {
                
                int Mandal_ID = Convert.ToInt32(Session["Mandal_ID"]);
                int District_ID = Convert.ToInt32(Session["District_ID"]);
                int Pariyojana_ID = Convert.ToInt32(Session["Pariyojana_ID"]);
                int Designation_ID = Convert.ToInt32(Session["Designation_ID"]);
                //int Salary_ID = Convert.ToInt32(Session["Salary_ID"]);
                
                var Mandal = (from a in _db.Tbl_Master_Mandal
                            where a.pk_id == Mandal_ID
                              select a).FirstOrDefault();
                Session["Mandal"] = Mandal.Mandal_Name.ToString();

                var District = (from a in _db.Tbl_Master_District
                             where a.pk_Dis_ID == District_ID
                                select a).FirstOrDefault();
                Session["District"] = District.District_Name.ToString();

                var Pariyojana = (from a in _db.Tbl_Master_Pariyojana
                               where a.pk__Pariyojana_Id == Pariyojana_ID
                                 select a).FirstOrDefault();
                Session["Pariyojana"] = Pariyojana.Pariyojana.ToString();

                var Designation = (from a in _db.Tbl_Master_Designation
                                  where a.pk_Designation_id == Designation_ID
                                  select a).FirstOrDefault();
                Session["Designation"] = Designation.Designation.ToString();

               
            }
        }
        #endregion

        #region final save postmethod
        [HttpPost]
        public ActionResult Index(Emp_All_Details obj)
        {
            
            if (ModelState.IsValid)
            {
                Session["Identification_Id"] = Idenfication_Id();
                int Mandal_ID = Convert.ToInt32(Session["Mandal_ID"]);
                int District_ID = Convert.ToInt32(Session["District_ID"]);
                int Pariyojana_ID = Convert.ToInt32(Session["Pariyojana_ID"]);
                int Designation_ID = Convert.ToInt32(Session["Designation_ID"]);

                var data=_db.Sp_Emp_Reg(Mandal_ID, Session["Mandal"].ToString(), District_ID, Session["District"].ToString(), Designation_ID, Pariyojana_ID, Session["Salary_ID"].ToString(),
                    obj.Post, obj.PinCode,obj.Emp_Name, obj.F_Name, obj.DOB, obj.Address, obj.Mobile_No, obj.Alternate_Mob_No, obj.Aadhar_No, obj.Gender, obj.PAN_NO
                    , obj.Email_id, obj.SPR_NO, obj.Emp_Category, obj.Sub_category, obj.Bank_Name, obj.Account_No, obj.IFSC_Code, obj.Branch_Name
                    , obj.UAN_No, obj.ESIC_No, obj.Country, obj.Corres_Address,obj.City, obj.State, obj.Country, obj.Physically_Challenged, obj.District, obj.Exp_In_Yrs,
                    DateTime.Now, Session["Identification_Id"].ToString(), Session["Reg_Type"].ToString()).FirstOrDefault();

                if (data == null) { }
                else
                {
                    int a = data.pk_Emp_id;
                    Session["pk_Emp_id"] = a;
                    Session["Emp_Code_Popup"] = data.Emp_Code.ToString();
                    Session["Emp_Pass_Popup"] = data.DOB.ToString().Replace("-", "");
                    TempData["Message"] = "Success";

                }
                Clear();
               
                return RedirectToAction("Profile1", "Home");
            }
            GetMandalDistrictNameById();
            BindCategoryWithViewBag();
            BindGender();
            BindPhysically_Disabled();
            
            return View("Index");
        }
        #endregion

        #region actionmethod to bind all dropdownlist
        public ActionResult Emp_Details()
        {
            try
            {
                BindAll();
            }
            catch
            {
                return View("ErrorPage");
            }
            return View();
        }
        #endregion

        #region storing id's into session
        [HttpPost]
        public ActionResult Emp_Details(Emp_Detail obj)
        {
            if (ModelState.IsValid)
            {
                Session["Mandal_ID"] = obj.Mandal_ID;
                Session["District_ID"] = obj.District_ID;
                Session["Pariyojana_ID"] = obj.Pariyojana_ID;
                Session["Designation_ID"] = obj.Designation_ID;
                Session["Salary_ID"] = obj.Salary_ID;
                Session["Reg_Type"] = obj.RegistartionType;

                return RedirectToAction("Index", "Home");
            }
            BindAll();
            return View("Emp_Details"); 
            
        }
        #endregion

        #region function to get dropdown data from database
        protected void BindAll()
        {
            
                var Mandal = _db.Tbl_Master_Mandal.ToList();
                ViewBag.Mandal = Mandal;

                var District = _db.Tbl_Master_District.ToList();
                ViewBag.District = District;

                var Pariyojana = _db.Tbl_Master_Pariyojana.ToList();
                ViewBag.Pariyojana = Pariyojana;

                var Designation = _db.Tbl_Master_Designation.ToList();
                ViewBag.Designation = Designation;

                var Salary = _db.tbl_Master_Salary.ToList();
                ViewBag.Salary = Salary;

               OldNewRegistration();
        }
        #endregion

        #region function to clear the sessions once data hasbeen saved
        public void Clear()
        {
            Session["Mandal"] = "";
            Session["District"] = "";
            Session["Pariyojana"] = "";
            Session["Designation"] ="";
            Session["Man"] = "";
            Session["Dist"] = "";
        }
        #endregion

        #region action method to getdata of employee to show on profile page
        public ActionResult Profile1()
        {
            Temp_Data Emp_data = TempData["pk_Emp_d"] as Temp_Data;
            if (Emp_data != null)
            {
                Session["pk_Emp_id"] = Emp_data.fk_Emp_id.ToString();
            }
            int Identification_Id = Convert.ToInt32(Session["pk_Emp_id"]);
            var data = _db.tbl_Employee_Registration.Where(x => x.pk_Emp_id == Identification_Id).FirstOrDefault();

            Profile obj = new Profile {
                pk_Emp_id = data.pk_Emp_id,
                Emp_Name = data.Emp_Name,
                Emp_Code = data.Emp_Code,
                F_Name = data.F_Name,
                Mobile_No = data.Mobile_No,
                Alternate_Mob_No = data.Alternate_Mob_No,
                DOB1 = Convert.ToDateTime(data.DOB).ToString("dd-MMM-yyyy"),
                Address = data.Address,
                Aadhar_No = data.Aadhar_No,
                Gender = data.Gender,
                PAN_NO = data.PAN_NO,
                Email_id = data.Email_id,
                SPR_NO = data.SPR_NO,
                Emp_Category = data.Emp_Category,
                Sub_category = data.Sub_category,
                Nationality = data.Country,
                Corres_Address = data.Corres_Address,
                Physically_Challenged = data.Physically_Challenged,
                PinCode = data.Postal_Code,
                Exp_In_Yrs = data.Exp_In_Yrs,
                Post = data.Emp_post_Add,
                Mandal = data.Mandal_Name,
                District = data.District_Name,
                City = data.City,
                State = data.State,
                Country = data.Country,
                Pariyojana = data.Pariyojana,
                Designation = data.Designation.ToUpper(),
                Salary = data.Salary,
                fk_Mandal_id = data.fk_Mandal_id
            };
            if (Emp_data == null)
            {
                //Profile obj1 = new Profile();
                var password = (from a in _db.Tbl_Emp_Credential
                                where a.Fk_Emp_Id == Identification_Id
                                select a).FirstOrDefault();
                obj.Password = password.Emp_Password.ToString();
                TempData["Message"] = "Success";

            }
            else
            {
                TempData["Pass"] = "";
                TempData["Message"] = "failed";
            }
            ViewBag.Profile = obj;
            List<Tbl_Notice> NoticeDeatilsobj = _db.Tbl_Notice.ToList();
            ViewBag.Notice = NoticeDeatilsobj;
            return View();
        }
        #endregion

        #region function for random number generation
        protected int Idenfication_Id()
        {
            Random r = new Random();
            return r.Next(10000000, 99999999);
        }
        #endregion

        #region json function to bind the district
        [HttpPost]
        public JsonResult Bind_District(int Mid)
        {
            var Response =_db.Tbl_Master_District.Where(x=>x.fk_Mandal_id==Mid).ToList(); 
            string obj = JsonConvert.SerializeObject(Response);
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region function to bind category
        protected void BindCategoryWithViewBag()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem
            { Text = "GENERAL", Value = "1" });

            items.Add(new SelectListItem
            { Text = "OBC", Value = "2" });

            items.Add(new SelectListItem
            { Text = "SC/ST", Value = "3" });

            ViewBag.CategoryType = items;

            
        }
        #endregion

        #region bind gender function
        protected void BindGender()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem
            {
                Text = "Select Gender",
                Value = "0",
                Selected = true
            });

            items.Add(new SelectListItem
            { Text = "MALE", Value = "1" });

            items.Add(new SelectListItem
            { Text = "FEMALE", Value = "2" });

            items.Add(new SelectListItem
            { Text = "OTHER", Value = "3" });

            ViewBag.Gender = items;

        }
        #endregion

        #region bind physically disabled 
        protected void BindPhysically_Disabled()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem
            {
                Text = "--Select-- ",
                Value = "0",
                Selected = true
            });

            items.Add(new SelectListItem
            { Text = "NO", Value = "NO" });

            items.Add(new SelectListItem
            { Text = "YES", Value = "YES" });

            ViewBag.Physically_Disabled = items;

        }
        #endregion

        #region bind registration type
        protected void OldNewRegistration()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem
            {
                Text = "--Select-- ",
                Value = "0",
                Selected = true
            });

            items.Add(new SelectListItem
            { Text = "NEW", Value = "NEW" });

            items.Add(new SelectListItem
            { Text = "OLD", Value = "OLD" });

            ViewBag.OldNewRegistration = items;

        }
        #endregion

        #region other
        public ActionResult ErrorPage()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult test()
        {
            

            return View();
        }
        #endregion
    }
}