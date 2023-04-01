using EssiviAdmin.Client.Helpers;
using EssiviAdmin.Client.Interfaces;
using EssiviAdmin.Client.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace EssiviAdmin.Client.Services
{
    public class LoginService : ILoginService
    {
        private readonly HttpClient _httpClient;

        // constructor
        public LoginService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> Login(string username, string password)
        {
            //_httpClient.PostAsync($"{Constants.ApiUrl}/login").Result();
            //_httpClient.BaseAddress = new Uri($"{Constants.ApiUrl}auth/");
            string url = $"{Constants.ApiUrl}auth/";

            // Add authorization header
            var byteArray = Encoding.ASCII.GetBytes($"{username}:{password}");
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            //request.Headers.Add("Content-Type", "application/json");
            //request.Headers.Accept.Clear();
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            // Send POST request
            var content = new StringContent("", Encoding.UTF8, "application/json");



            // test

            // send request to $"{Constants.ApiUrl}auth/" with adding to header string token
            url = $"{Constants.ApiUrl}auth/login";
            request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            //Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //request.Headers.Add("Content-Type", "application/json");
            //request.Headers.Add("token", token);

            // test

            using (HttpResponseMessage response = await _httpClient.SendAsync(request))
            {
                // Read response content
                string responseContent = await response.Content.ReadAsStringAsync();
                var dynamicObject = JsonConvert.DeserializeObject<dynamic>(responseContent);
                string token = dynamicObject["token"];


                //url = $"{Constants.ApiUrl}mycat/deliv";
                //request = new HttpRequestMessage(HttpMethod.Get, url);
                //request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                //using (HttpResponseMessage response1 = await _httpClient.SendAsync(request))
                //{
                //    // Read response content
                //    //string responseContent1 = await response.Content.ReadAsStringAsync();
                //    //var dynamicObject1 = JsonConvert.DeserializeObject<dynamic>(responseContent);
                //    string responseContent1 = await response1.Content.ReadAsStringAsync();
                //    var dynamicObject1 = JsonConvert.DeserializeObject<dynamic>(responseContent1);
                //    var deliverers1 = JsonConvert.DeserializeObject<List<Delivrer>>(dynamicObject1["result"].ToString());
                //}
                    return token;
            }


            using (HttpResponseMessage response = await _httpClient.PostAsync("login", content))
            {
                // Read response content
                string responseContent = await response.Content.ReadAsStringAsync();
                var dynamicObject = JsonConvert.DeserializeObject<dynamic>(responseContent);
                string token = dynamicObject["token"];
                
                return token;
            }
        }

        public async Task<bool> IsTokenValid(string token)
        {
            // send request to $"{Constants.ApiUrl}auth/" with adding to header string token
            string url = $"{Constants.ApiUrl}auth/token/valid";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //request.Headers.Add("Content-Type", "application/json");
            request.Headers.Add("token", token);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            
            // send the request with request object
            using (HttpResponseMessage response = await _httpClient.SendAsync(request))
            { 
                // Read response content
                string responseContent = await response.Content.ReadAsStringAsync();
                var dynamicObject = JsonConvert.DeserializeObject<dynamic>(responseContent);
                bool isValid = dynamicObject["isValid"];

                return isValid;
            }



            //_httpClient.PostAsync($"{Constants.ApiUrl}/login").Result();
            _httpClient.BaseAddress = new Uri($"{Constants.ApiUrl}auth/");

            // Add authorization header
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Send POST request
            var content = new StringContent("", Encoding.UTF8, "application/json");


            using (HttpResponseMessage response = await _httpClient.PostAsync("token/valid", content))
            {
                // Read response content
                string responseContent = await response.Content.ReadAsStringAsync();
                var dynamicObject = JsonConvert.DeserializeObject<dynamic>(responseContent);
                
                bool isValid = dynamicObject["isValid"];

                return isValid;
            }
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }

        public bool Register(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
