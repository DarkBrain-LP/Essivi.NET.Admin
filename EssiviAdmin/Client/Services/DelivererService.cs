using EssiviAdmin.Client.Helpers;
using EssiviAdmin.Client.Models;
using Newtonsoft.Json;
using Radzen.Blazor.Rendering;
using System;
using System.Net.Http.Headers;
using System.Text;

namespace EssiviAdmin.Client.Services
{
    public class DelivererService
    {
        private readonly HttpClient _httpClient;

        // constructor
        public DelivererService(HttpClient httpClient)
        { 
            _httpClient = httpClient;
            //_httpClient.BaseAddress = new Uri($"{Constants.ApiUrl}");
        }

        public async Task<List<Delivrer>> GetDeliverers(string token)
        {
            //_httpClient.PostAsync($"{Constants.ApiUrl}/login").Result();
            //_httpClient.BaseAddress = new Uri($"{Constants.ApiUrl}auth/");
            string url = $"{Constants.ApiUrl}mycat/deliv";

            // Add authorization header
            //var byteArray = Encoding.ASCII.GetBytes($"{username}:{password}");
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            //request.Headers.Add("Content-Type", "application/json");
            ////request.Headers.Accept.Clear();
            //request.Headers.Add("token", token);
            //request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            ////_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            //// Send POST request
            //var content = new StringContent("", Encoding.UTF8, "application/json");



            // test

            // send request to $"{Constants.ApiUrl}auth/" with adding to header string token
            url = $"{Constants.ApiUrl}mycat/deliv";
            request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            //Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //request.Headers.Add("Content-Type", "application/json");
            request.Headers.Add("token", token);

            // test

            using (HttpResponseMessage response = await _httpClient.SendAsync(request))
            {
                // Read response content
                string responseContent = await response.Content.ReadAsStringAsync();
                var dynamicObject = JsonConvert.DeserializeObject<dynamic>(responseContent);
                var deliverers = JsonConvert.DeserializeObject<List<Delivrer>>(dynamicObject["result"].ToString());

                return deliverers;
            }


        }
        //{
        //    string url = $"{Constants.ApiUrl}mycat/deliv/";
        //    var request = new HttpRequestMessage(HttpMethod.Post, url);
        //    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    //Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    //request.Headers.Add("Content-Type", "application/json");
        //    request.Headers.Add("token", token);
        //    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        //    using (HttpResponseMessage response = await _httpClient.SendAsync(request))
        //    {
        //        string responseContent = await response.Content.ReadAsStringAsync();
        //        var dynamicObject = JsonConvert.DeserializeObject<dynamic>(responseContent);
        //        var deliverers = JsonConvert.DeserializeObject<List<Delivrer>>(dynamicObject["result"].ToString());

        //        return deliverers;
        //    }
        //    using (HttpResponseMessage response = await _httpClient.GetAsync($"{Constants.ApiUrl}deliver/"))
        //    { 
        //        // Read response content
        //        string responseContent = await response.Content.ReadAsStringAsync();
        //        var dynamicObject = JsonConvert.DeserializeObject<dynamic>(responseContent);
        //        var deliverers = JsonConvert.DeserializeObject<List<Delivrer>>(dynamicObject["deliverers"].ToString());

        //        return deliverers;
        //    }
        //}

        public async Task<Delivrer> GetDeliverer(int id)
        { 
            using (HttpResponseMessage response = await _httpClient.GetAsync($"deliverer/{id}"))
            { 
                // Read response content
                string responseContent = await response.Content.ReadAsStringAsync();
                var dynamicObject = JsonConvert.DeserializeObject<dynamic>(responseContent);
                var deliverer = JsonConvert.DeserializeObject<Delivrer>(dynamicObject["deliverer"].ToString());

                return deliverer;
            }
        }

        public async Task<bool> CreateDeliverer(Delivrer deliverer, string token)
        {
            string url = $"{Constants.ApiUrl}mycat/deliv";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //request.Headers.Authorization = new AuthenticationHeaderValue("", token);
            request.Headers.Add("token", token);
            var content = new StringContent(JsonConvert.SerializeObject(deliverer), Encoding.UTF8, "application/json");
            request.Content = content;

            // send request
            using (HttpResponseMessage response = await _httpClient.SendAsync(request))
            { 
                // Read response content
                string responseContent = await response.Content.ReadAsStringAsync();
                if(responseContent == null)
                    return false;
                var dynamicObject = JsonConvert.DeserializeObject<dynamic>(responseContent);
                
                
                //var createdDeliverer = JsonConvert.DeserializeObject<Delivrer>(dynamicObject["resu*/lt.ToString());
                if (dynamicObject != null)
                {
                    bool isCreated = dynamicObject["result"];
                    return isCreated;
                }
                    //bool isCreated = dynamicObject["result"];
                return false;
                
            }


            using (HttpResponseMessage response = await _httpClient.PostAsync("/mycat/deliv", content))
            { 
                // Read response content
                string responseContent = await response.Content.ReadAsStringAsync();
                var dynamicObject = JsonConvert.DeserializeObject<dynamic>(responseContent);
                //var createdDeliverer = JsonConvert.DeserializeObject<Delivrer>(dynamicObject["result"].ToString());
                bool isCreated= JsonConvert.DeserializeObject<bool>(dynamicObject["success"].ToString());

                return isCreated;
            }
        }

        public async Task<Delivrer> UpdateDeliverer(Delivrer deliverer)
        { 
            var content = new StringContent(JsonConvert.SerializeObject(deliverer), Encoding.UTF8, "application/json");


            using (HttpResponseMessage response = await _httpClient.PutAsync("deliverer", content))
            { 
                // Read response content
                string responseContent = await response.Content.ReadAsStringAsync();
                var dynamicObject = JsonConvert.DeserializeObject<dynamic>(responseContent);
                var updatedDeliverer = JsonConvert.DeserializeObject<Delivrer>(dynamicObject["deliverer"].ToString());

                return updatedDeliverer;
            }
        }

        public async Task DeleteDeliverer(int id)
        { 
            //using (HttpResponseMessage response = await _httpClient.DeleteAsync($"deliverer/{id}")) 
                
        }
    }
}
