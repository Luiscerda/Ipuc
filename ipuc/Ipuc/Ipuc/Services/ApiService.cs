namespace Ipuc.Services
{
    using Models;
    using Newtonsoft.Json;
    using Plugin.Connectivity;
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    public class ApiService
    {
        public async Task<Response> CheckConnection()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Please turn on your internet settings.",
                };
            }
            var isReachable =  CrossConnectivity.Current.IsConnected;

            if (!isReachable)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Check you internet connection",
                };
            }

            return new Response
            {
                IsSuccess = true,
                Message = "Ok",
            };
        }

        public async Task<TokenResponse> GetToken(string urlBase,string userName, string password)
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(urlBase);
                var response = await client.PostAsync("Token", 
                    new StringContent(string.Format("grant_type=password&username={0}&password={1}", 
                    userName, password),
                    Encoding.UTF8, "application/x-www-form-urlencoded"));
                var resultJson = await response.Content.ReadAsStringAsync();
                var result =  JsonConvert.DeserializeObject<TokenResponse>(resultJson);
                return result;
            }
            catch
            {
                return null;
            }
        }
    }
}
