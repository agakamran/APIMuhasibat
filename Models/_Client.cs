using APIMuhasibat.Models.AccountViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace APIMuhasibat.Models
{
    public class _Client
    {
        public static bool b;
        public string _host()
        {
            string bas = "http://localhost/Avto/api/KamAPI/";
            return bas;
        }
        public string Register(string email, string fio, string vesige, string telefon, bool hal,
            string password, string confirmPassword)
        {
            MyCl mc = new MyClass();
            var registerModel = new
            {
                UserName = email,
                fio = fio,
                vesige = vesige,
                MacAdd = mc.GetMacAddress(),
                telefon = telefon,
                MachineName = Environment.MachineName,
                Hal = hal,
                komuser = SystemInformation.UserName,
                IP = mc.GetLocalIPAddress(),
                Email = email,
                Password = password,
                ConfirmPassword = password,
            };
            using (var client = new HttpClient())
            {
                var ad = _host();
                var response = client.PostAsJsonAsync(_host() + "Register", registerModel).Result;
                if (response.StatusCode.ToString() == "OK") { b = true; }
                else { b = false; }
                return response.StatusCode.ToString();
            }
        }
        public RegisterViewModel Get(string id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = client.GetAsync(_host() + id).Result.Content.ReadAsStringAsync().Result;
                    var Valee = JsonConvert.DeserializeObject<RegisterViewModel>(response);
                    return Valee;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        //public string Login(string email, string password)
        //{
        //    // HttpClient client = new HttpClient();
        //    using (var client = new HttpClient())
        //    {
        //        var pairs = new List<KeyValuePair<string, string>>
        //            {
        //                new KeyValuePair<string, string>( "grant_type", "password" ),
        //                new KeyValuePair<string, string>( "username", email ),
        //                new KeyValuePair<string, string> ( "Password", password )
        //            };
        //        var content = new FormUrlEncodedContent(pairs);
        //        // Attempt to get a token from the token endpoint of the Web Api host:
        //        HttpResponseMessage response = client.PostAsync(_host() + "/Token", content).Result;
        //        var result = response.Content.ReadAsStringAsync().Result;

        //        // De-Serialize into a dictionary and return:
        //        Dictionary<string, string> tokenDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);
        //        GetUserInfo(tokenDictionary["access_token"]);
        //        return tokenDictionary["access_token"];
        //    }

        //}

    }
    //public class ProductClient
    //{
    //    _Client cl = new _Client();
    //    //private string BASE_URL = _c.BASE_URL().ToString() ;
    //    SmtpClient client;
    //    public IEnumerable<Product> FindAll()
    //    {            
    //        try
    //        {
    //            client = new HttpClient();
    //            client.BaseAddress = new Uri(cl._host()+ "product");
    //            client.DefaultRequestHeaders.Accept.Add(
    //                new MediaTypeWithQualityHeaderValue("application/json"));
    //            HttpResponseMessage response = client.GetAsync("product").Result;
    //            if (response.IsSuccessStatusCode)
    //                return response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
    //            return null;
    //        }
    //        catch
    //        {
    //            return null;
    //        }
    //    }
    //    public Product Find(int Id)
    //    {
    //        try
    //        {
    //            client = new HttpClient();
    //            client.BaseAddress = new Uri(cl._host() + "product");
    //            client.DefaultRequestHeaders.Accept.Add(
    //                new MediaTypeWithQualityHeaderValue("application/json"));
    //            HttpResponseMessage response = client.GetAsync("product/" + Id).Result;
    //            if (response.IsSuccessStatusCode)
    //                return response.Content.ReadAsAsync<Product>().Result;
    //            return null;

    //        }
    //        catch
    //        {
    //            return null;
    //        }
    //    }
    //    public bool Create(Product product)
    //    {
    //        try
    //        {
    //            client = new HttpClient();
    //            client.BaseAddress = new Uri(cl._host() + "product");
    //            client.DefaultRequestHeaders.Accept.Add(
    //                new MediaTypeWithQualityHeaderValue("application/json"));
    //            HttpResponseMessage response = client.PostAsJsonAsync("product", product).Result;
    //            return response.IsSuccessStatusCode;
    //        }
    //        catch
    //        {
    //            return false;
    //        }
    //    }
    //    public bool Edit(Product pro)
    //    {
    //        try
    //        {
    //            client = new HttpClient();
    //            client.BaseAddress = new Uri(cl._host() + "product");
    //            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    //            HttpResponseMessage response = client.PutAsJsonAsync("product/" + pro.ProdId, pro).Result;
    //            return response.IsSuccessStatusCode;
    //        }
    //        catch
    //        {
    //            return false;
    //        }
    //    }
    //    public bool Delete(int id)
    //    {
    //        try
    //        {
    //            client = new HttpClient();
    //            client.BaseAddress = new Uri(cl._host() + "product");
    //            client.DefaultRequestHeaders.Accept.Add(
    //                new MediaTypeWithQualityHeaderValue("application/json"));
    //            HttpResponseMessage response = client.DeleteAsync("product/" + id).Result;
    //            return response.IsSuccessStatusCode;
    //        }
    //        catch
    //        {
    //            return false;
    //        }
    //    }
    //}
}
