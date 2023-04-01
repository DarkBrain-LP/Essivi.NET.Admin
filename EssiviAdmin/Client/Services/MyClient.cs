namespace EssiviAdmin.Client.Services
{
    public class MyClient
    {
        // singleton HttpClient
        private static HttpClient _httpClient;
        public static HttpClient MyHttpClient
        { 
            get
            { 
                if (_httpClient == null)
                { 
                    _httpClient = new HttpClient();
                }
                return _httpClient;
            }
        }
    }
}
