using HRMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRMS.Controllers
{
    public class UploadDocController : Controller
    {
        DB_HRMSEntities db = new DB_HRMSEntities();
        //DB_HRMSEntities2 db = new DB_HRMSEntities2();
        //DB_HRMSEntities3 db = new DB_HRMSEntities3();

        #region uploadfile view getmethod
        public ActionResult UploadFiles(int pk_id)
        {
            Session["pk_id"] = 0;
            Session["pk_id"] = pk_id;
            return View();
        }
        #endregion

        #region deleting and uploading documnets
        [HttpPost]
        public ActionResult UploadFiles(HttpPostedFileBase[] files)
        { 
            if (ModelState.IsValid)
            {   
                int i=1,n = 0;
                int pkid = Convert.ToInt32(Session["pk_id"]);
                List<tbl_Employee_Docs> PathList = db.tbl_Employee_Docs.Where(x => x.fk_Emp_Id == pkid).ToList();
               
                //CHECK IF THE DATA ALREADY EXIST IN THE DATABASE THEN FIRST DELETE IT
                if (PathList.Count > 0)
                {                    
                    foreach (var a in PathList)
                    {
                        if ((System.IO.File.Exists(Server.MapPath(a.Doc_Path))))
                        {
                            System.IO.File.Delete(Server.MapPath(a.Doc_Path));
                        }
                    }
                    db.tbl_Employee_Docs.RemoveRange(db.tbl_Employee_Docs.Where(c => c.fk_Emp_Id == pkid));
                    db.SaveChanges();
                }

                //UPLOAD THE FILE AGAIN
                var Emp_Code_temp = db.tbl_Employee_Registration.Where(x => x.pk_Emp_id == pkid).FirstOrDefault();
                foreach (HttpPostedFileBase file in files)
                  {
                    tbl_Employee_Docs doc = new tbl_Employee_Docs();
                    doc.Doc_Name = DocName(i);
                    doc.fk_Emp_Id = pkid;
                    doc.Doc_Sr_No = i.ToString();
                    doc.Created_Date = DateTime.Now;
                    string empCd = Emp_Code_temp.Emp_Code.ToString();
                    doc.Emp_Code = Emp_Code_temp.Emp_Code.ToString();
                    //Checking file is available to save.  
                    if (file != null)
                    {                         
                        var InputFileName = Path.GetFileName(file.FileName);
                        string DocumentPath = empCd.ToString() + "_"+DocName(i) +"_"+ file.FileName;
                        file.SaveAs(Server.MapPath("/UploadDocument/" + DocumentPath));
                        BinaryReader reader = new BinaryReader(file.InputStream);
                        string myFilePath = file.FileName;
                        doc.Doc_Type = Path.GetExtension(myFilePath);
                        doc.Doc_Path = "/UploadDocument/" + DocumentPath;
                        n++;
                        //db.tbl_Employee_Docs.Add(doc);
                    //i++;                
                   }
                    db.tbl_Employee_Docs.Add(doc);
                    db.SaveChanges();
                    i++;
                }
                ViewBag.UploadStatus = n.ToString() + " files uploaded successfully.";
                return RedirectToAction("Download_slip",new  { pk_id= pkid });
            }
            
            return View();
        }
        #endregion

        #region uploadsuccess method
        public ActionResult UploadSuccess()
        {
            return View();
        }
        #endregion

        #region dowload slip actionmethod
        public ActionResult Download_slip(int pk_id)
        {
            int temp = pk_id;
            var Response = db.tbl_Employee_Docs.Where(x => x.fk_Emp_Id == temp).ToList().Count();
            if (Response >9 )
            {
                var result = db.Proc_DownloadSlip(temp).FirstOrDefault();
                return View(result);
            }
            ViewBag.alert = "Alert";
            return RedirectToAction("UploadFiles", new { pk_id= temp });
        }
        #endregion

        #region 
        //public string DocName(int a)
        //{
        //    string result = "";
        //    if (a == 1)
        //    {
        //        result = "CV";
        //    }
        //    else if (a == 2)
        //    {
        //        result = "QualCertificate";
        //    }

        //    else if (a == 3)
        //    {
        //        result = "ExpCertificates";
        //    }

        //    else if (a == 4)
        //    {
        //        result = "CharCertificate";
        //    }

        //    else if (a == 5)
        //    {
        //        result = "WorkSatisfactoryCertificate";
        //    }

        //    else if (a == 6)
        //    {
        //        result = "CastCertificate";
        //    }

        //    else if (a == 7)
        //    {
        //        result = "AadharCard";
        //    }


        //    else if (a == 8)
        //    {
        //        result = "PANCard";
        //    }


        //    else if (a == 9)
        //    {
        //        result = "BankAccountpassbook";

        //    }

        //    else if (a == 10)
        //    {
        //        result = "ComputerDiplomaCertificate";
        //    }

        //    else if (a == 11)
        //    {
        //        result = "EmpExchangeRegCertificate";
        //    }


        //    else if (a == 12)
        //    {
        //        result = "NotarizedAffidavit";
        //    }

        //    else if (a == 13)
        //    {
        //        result = "OldAppointmentLetter";
        //    }
        //    return result;
        //}
        #endregion

        #region document name
        //FUNCTION TO SPECIFY DOCUMENT NAME
        public string DocName(int a)
        {
            string result = "";
            switch (a)
            { 
                case 1:
                    result = "CV";
                 break;

                case 2:
                    result = "QualCertificate";
                 break;

                case 3:
                result = "ExpCertificates";
                    break;

                case 4:
                result = "CharCertificate";
                    break;

                case 5:
                result = "WorkSatisfactoryCertificate";
                    break;

                case 6:
                result = "CastCertificate";
                    break;

                case 7:
                result = "AadharCard";
                    break;

                case 8:
                result = "PANCard";
                    break;

                case 9:
                result = "BankAccountpassbook";
                    break;

                case 10:
                result = "ComputerDiplomaCertificate";
                    break;

                case 11:
                result = "EmpExchangeRegCertificate";
                    break;

                case 12:
                result = "NotarizedAffidavit";
                    break;

                case 13:
                result = "OldAppointmentLetter";
                    break;

                default:
                    result = "OTHER DOCUMENT";
                    break;
            }
            return result;
        }
    }
}
#endregion