using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
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


        public override bool Equals(object obj)
        {
            if (obj is Category)
            {
                return ((Category)obj).id == id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return 1877310944 + EqualityComparer<string>.Default.GetHashCode(id);
        }
    }
    public class Product
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        public Category category { get; set; }
        public Decimal price { get; set; }
        public int remaining { get; set; }
        public bool enable { get; set; }

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
                List<Category> categories  = JsonConvert.DeserializeObject<List<Category>>(result);
                return categories;
            }
        }
        public static HttpStatusCode CreateNewCategory(string name, string description)
        {
            string token = AccountDetails.Instance.Token;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://shopping-server-13706.herokuapp.com/categories");
            httpWebRequest.PreAuthenticate = true;
            httpWebRequest.Headers.Add("Authorization", "Bearer " + token);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"name\":\"" + name + "\"," +
                                "\"description\":\"" + description + "\"}";
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            try
            {
                var httpRespond = (HttpWebResponse)httpWebRequest.GetResponse();
                HttpStatusCode status = httpRespond.StatusCode;
                using (var streamReader = new StreamReader(httpRespond.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    if (httpRespond.StatusCode == HttpStatusCode.OK)
                    {
                        return HttpStatusCode.OK;
                    }
                }
            }
            catch (WebException e)
            {
                HttpStatusCode status = ((HttpWebResponse)e.Response).StatusCode;
                
                return status;
            }
            return HttpStatusCode.OK;
        }
        public static HttpStatusCode UpdateCategory(int id, string name, string description)
        {
            string token = AccountDetails.Instance.Token;
            string link = "http://shopping-server-13706.herokuapp.com/categories/" + id.ToString();
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(link);
            httpWebRequest.PreAuthenticate = true;
            httpWebRequest.Headers.Add("Authorization", "Bearer " + token);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PUT";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"id\":\"" + id + "\"," +
                                "\"name\":\"" + name + "\"," +
                                "\"description\":\"" + description + "\"}";
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            try
            {
                var httpRespond = (HttpWebResponse)httpWebRequest.GetResponse();
                HttpStatusCode status = httpRespond.StatusCode;
                using (var streamReader = new StreamReader(httpRespond.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    if (httpRespond.StatusCode == HttpStatusCode.OK)
                    {
                        return HttpStatusCode.OK;
                    }
                }
            }
            catch (WebException e)
            {
                HttpStatusCode status = ((HttpWebResponse)e.Response).StatusCode;

                return status;
            }
            return HttpStatusCode.OK;
        }
        public static List<Product> GetAllProduct()
        {
            string token = AccountDetails.Instance.Token;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://shopping-server-13706.herokuapp.com/products");
            httpWebRequest.PreAuthenticate = true;
            httpWebRequest.Headers.Add("Authorization", "Bearer " + token);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";
            var httpRespond = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpRespond.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                List<Product> products = JsonConvert.DeserializeObject<List<Product>>(result);
                foreach (Product p in products)
                {
                    Console.WriteLine(p.name);
                }
                return products;
            }
        }
        public static HttpStatusCode CreateNewProduct(string name, string description, int categoryID, float price, int remaining)
        {
            string token = AccountDetails.Instance.Token;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://shopping-server-13706.herokuapp.com/products");
            httpWebRequest.PreAuthenticate = true;
            httpWebRequest.Headers.Add("Authorization", "Bearer " + token);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                //string json = "{\"name\":\"" + name + "\"," +
                //                "\"description\":\"" + description + "\","+
                //                 "\"categoryId\":\"" + categoryID + "\","+
                //                 "\"price\":\"" + price + "\","+
                //                 "\"remaining\":\"" + remaining + "\"}";
                dynamic productObj = new ExpandoObject(); ;
                productObj.name = name;
                productObj.description = description;
                productObj.price = price;
                productObj.categoryId = categoryID;
                productObj.remainingProduct = remaining;
                //productObj.enable = true;
                streamWriter.Write(JsonConvert.SerializeObject(productObj));
                streamWriter.Flush();
                streamWriter.Close();
            }
            try
            {
                var httpRespond = (HttpWebResponse)httpWebRequest.GetResponse();
                HttpStatusCode status = httpRespond.StatusCode;
                using (var streamReader = new StreamReader(httpRespond.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    if (httpRespond.StatusCode == HttpStatusCode.OK)
                    {
                        return HttpStatusCode.OK;
                    }
                }
            }
            catch (WebException e)
            {
                HttpStatusCode status = ((HttpWebResponse)e.Response).StatusCode;

                return status;
            }
            return HttpStatusCode.OK;
        }
        public static HttpStatusCode UpdateProduct(string id,string name, string description, int categoryID, float price, int remaining)
        {
            string token = AccountDetails.Instance.Token;
            string link = "http://shopping-server-13706.herokuapp.com/products/" + id.ToString();
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(link);
            httpWebRequest.PreAuthenticate = true;
            httpWebRequest.Headers.Add("Authorization", "Bearer " + token);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PUT";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                //string json = "{\"name\":\"" + name + "\"," +
                //                "\"description\":\"" + description + "\","+
                //                 "\"categoryId\":\"" + categoryID + "\","+
                //                 "\"price\":\"" + price + "\","+
                //                 "\"remaining\":\"" + remaining + "\"}";
                dynamic productObj = new ExpandoObject();
                productObj.name = name;
                productObj.description = description;
                productObj.price = price;
                productObj.categoryId = categoryID;
                productObj.remainingProduct = remaining;
                //productObj.enable = true;
                streamWriter.Write(JsonConvert.SerializeObject(productObj));
                streamWriter.Flush();
                streamWriter.Close();
            }
            try
            {
                var httpRespond = (HttpWebResponse)httpWebRequest.GetResponse();
                HttpStatusCode status = httpRespond.StatusCode;
                using (var streamReader = new StreamReader(httpRespond.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    if (httpRespond.StatusCode == HttpStatusCode.OK)
                    {
                        return HttpStatusCode.OK;
                    }
                }
            }
            catch (WebException e)
            {
                HttpStatusCode status = ((HttpWebResponse)e.Response).StatusCode;

                return status;
            }
            return HttpStatusCode.OK;
        }
        public static HttpStatusCode AddToCard(int productID, int quantity)
        {
            string token = AccountDetails.Instance.Token;
            string link = "http://shopping-server-13706.herokuapp.com/users/addToCart";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(link);
            httpWebRequest.PreAuthenticate = true;
            httpWebRequest.Headers.Add("Authorization", "Bearer " + token);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PUT";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                //string json = "{\"name\":\"" + name + "\"," +
                //                "\"description\":\"" + description + "\","+
                //                 "\"categoryId\":\"" + categoryID + "\","+
                //                 "\"price\":\"" + price + "\","+
                //                 "\"remaining\":\"" + remaining + "\"}";
                dynamic productObj = new ExpandoObject();
                productObj.productID = productID;
                productObj.quantity = quantity;
                streamWriter.Write(JsonConvert.SerializeObject(productObj));
                streamWriter.Flush();
                streamWriter.Close();
            }
            try
            {
                var httpRespond = (HttpWebResponse)httpWebRequest.GetResponse();
                HttpStatusCode status = httpRespond.StatusCode;
                using (var streamReader = new StreamReader(httpRespond.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    if (httpRespond.StatusCode == HttpStatusCode.OK)
                    {
                        return HttpStatusCode.OK;
                    }
                }
            }
            catch (WebException e)
            {
                HttpStatusCode status = ((HttpWebResponse)e.Response).StatusCode;

                return status;
            }
            return HttpStatusCode.OK;
        }
     }
}
