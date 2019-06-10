using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Sweetie.Utilities
{
    //public class Categories
    //{
    //    public static 
    //}
    public class TokenObject
    {
        public string UserName { get; set; }
        public string Token { get; set; }
    }
    public class Category
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }
    public sealed class Database
    {

        public enum LoginStatus
        {
            Account = 0,
            Connection = 1,
            Success = 2
        }
        
        public static HttpStatusCode Login(string user, string password)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://shopping-server-13706.herokuapp.com/users/signin");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"username\":\"" + user + "\"," +
                                "\"password\":\"" + password + "\"}";
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            //HttpStatusCode status = httpWebRequest.GetResponse()
            try {
                var httpRespond = (HttpWebResponse)httpWebRequest.GetResponse();
                HttpStatusCode status = httpRespond.StatusCode;
                using (var streamReader = new StreamReader(httpRespond.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    TokenObject tokenobj = JsonConvert.DeserializeObject<TokenObject>(result);
                    if (httpRespond.StatusCode == HttpStatusCode.OK)
                    {
                        AccountDetails.Instance.Token = tokenobj.Token;
                        return HttpStatusCode.OK;
                    }
                }
            }
            catch (WebException e)
            {
                HttpStatusCode status = ((HttpWebResponse)e.Response).StatusCode;
                return status;
            }
            
            
            return HttpStatusCode.InternalServerError;
        }
        public static List<Category> GetAllCategories()
        {
            string token = AccountDetails.Instance.Token;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://shopping-server-13706.herokuapp.com/categories");
            httpWebRequest.PreAuthenticate = true;
            httpWebRequest.Headers.Add("Authorization", "Bearer " + token);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";
            var httpRespond = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpRespond.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(result);
                return categories;
            }
        }
    }
}
