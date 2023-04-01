using EssiviAdmin.Client.Helpers;
using EssiviAdmin.Client.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace EssiviAdmin.Client.Services
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        { 
            _httpClient = httpClient;
        }

        public async Task<List<Product>> GetProducts(string token)
        {
            // send request to $"{Constants.ApiUrl}auth/" with adding to header string token
            string url = $"{Constants.ApiUrl}mycat/product";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            request.Headers.Authorization = new AuthenticationHeaderValue(token, token);
            //Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //request.Headers.Add("Content-Type", "application/json");
            request.Headers.Add("token", token);

            // test

            using (HttpResponseMessage response = await _httpClient.SendAsync(request))
            {
                // Read response content
                string responseContent = await response.Content.ReadAsStringAsync();
                var dynamicObject = JsonConvert.DeserializeObject<dynamic>(responseContent);
                var deliverers = JsonConvert.DeserializeObject<List<Product>>(dynamicObject["result"].ToString());

                return deliverers;
            }


        }


        public async Task<List<Category>> GetCategories(string token)
        {
            // send request to $"{Constants.ApiUrl}auth/" with adding to header string token
            string url = $"{Constants.ApiUrl}mycat/";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            request.Headers.Authorization = new AuthenticationHeaderValue(token, token);
            //Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //request.Headers.Add("Content-Type", "application/json");
            request.Headers.Add("token", token);

            // test

            using (HttpResponseMessage response = await _httpClient.SendAsync(request))
            {
                // Read response content
                string responseContent = await response.Content.ReadAsStringAsync();
                
                var dynamicObject = JsonConvert.DeserializeObject<dynamic>(responseContent);
                var r1 = dynamicObject[0];
                var r2 = dynamicObject[1];
                Console.WriteLine(r1["result"]);
                //Console.WriteLine(r2);
                try
                {
                    //var result = JsonConvert.DeserializeObject<dynamic>(r1.ToString());
                    var cats = JsonConvert.DeserializeObject<List<Category>>(r1["result"].ToString());

                    return cats;
                }
                catch (Exception)
                {

                    return null;
                }
                
                return null;
            }


        }

    }
}
