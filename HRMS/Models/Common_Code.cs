using Newtonsoft.Json;
using System;
using System.Web;
using System.Xml.Linq;
using HRMS.Models;

namespace HRMS.Models
{
    public class Common_Code
    {

        #region Encode Decode
        public string DecodeFrom64(string encodedData)
        {
            byte[] encodedDataAsBytes
                = System.Convert.FromBase64String(encodedData);
            string returnValue =
                System.Text.ASCIIEncoding.ASCII.GetString(encodedDataAsBytes);
            return returnValue;
        }
        public string EncodeTo64(string toEncode)
        {
            byte[] toEncodeAsBytes
                    = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);
            string returnValue
                    = System.Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }
        #endregion
        public string JsonToXml(string json)
        {
            string xmlText = string.Empty;
            if (!string.IsNullOrEmpty(json))
            {
                json = @"{'SubRoot':" + json + "}";
                XNode node = JsonConvert.DeserializeXNode(json, "Root");
                xmlText = node.ToString();
            }
            return xmlText;
        }
         
        #region cookies  
        public void Set_Cookies(string Cookies_Dtl)
        {
            string cookies_for = "USER";
            string cookies_name = "Krishi_Nideshalaya" + cookies_for.ToUpper();
            string cookies_key = cookies_for.ToUpper() + "_DTL";

            HttpCookie nameCookie;
            nameCookie = HttpContext.Current.Request.Cookies[cookies_name];

            if (nameCookie != null)
            {
                // remove Cookie
                nameCookie.Expires = DateTime.Now.AddDays(-1); //Set the Expiry date to past date.
                HttpContext.Current.Response.Cookies.Add(nameCookie); //Update the Cookie in Browser.
            }

            // Create Cookie
            nameCookie = new HttpCookie(cookies_name); //Create a Cookie with a suitable Key.
            nameCookie.Values.Add(cookies_key, Cookies_Dtl);
            nameCookie.Expires = DateTime.Now.AddDays(1);    //Set the Expiry date.
            HttpContext.Current.Response.Cookies.Add(nameCookie);  //Add the Cookie to Browser.
        }
        public string Get_Cookies(string Val_For)
        {
            string cookies_for = "USER";
            string cookies_name = "Krishi_Nideshalaya" + cookies_for.ToUpper();
            string cookies_key = cookies_for.ToUpper() + "_DTL";

            string RetVal = "";
            HttpCookie nameCookie;
            nameCookie = HttpContext.Current.Request.Cookies[cookies_name];
            Char delimiter = '#';
            String[] substrings;


            if (nameCookie != null)
            {
                substrings = nameCookie.Values[cookies_key].Split(delimiter);

                switch (Val_For)
                {
                    case "user_id":
                        RetVal = substrings[0].ToString();
                        break;
                    case "user_name":
                        RetVal = substrings[1].ToString();
                        break;
                    case "user_type":
                        RetVal = substrings[2].ToString();
                        break; 
                }
            }
            return RetVal;
        }
        public void Cookies_expire(string cookies_for)
        {
            string cookies_name = "Krishi_Nideshalaya" + cookies_for.ToUpper();
            HttpCookie nameCookie;
            nameCookie = HttpContext.Current.Request.Cookies[cookies_name];

            if (nameCookie != null)
            {
                // remove Cookie
                nameCookie.Expires = DateTime.Now.AddDays(-1); //Set the Expiry date to past date.
                HttpContext.Current.Response.Cookies.Add(nameCookie); //Update the Cookie in Browser.
            }
        }
        #endregion
    }
}