using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ControlCenter.Client.Client
{
    public class ApiClient
    {
        #region Fields

        private const string BaseUrl = "https://localhost:5001/";

        private readonly HttpClient httpClient;

        #endregion Fields

        #region Constructor

        public ApiClient()
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(BaseUrl)
            };
        }

        #endregion Constructor

        #region Methods

        public async Task<RequestResult> SendAsync(HttpMethod method, string endpoint)
        {
            var result = await httpClient.SendAsync(new HttpRequestMessage(method, endpoint));

            if(result.IsSuccessStatusCode)
            {
                return new RequestResult();
            }
            else if(result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                return new RequestResult
                {
                    ErrorMessage = "You are not authorized"
                };
            }
            else
            {
                return new RequestResult
                {
                    ErrorMessage = await result.Content.ReadAsStringAsync()
                };
            }
        }

        public async Task<RequestResult<T>> SendAsync<T>(HttpMethod method, string endpoint)
        {
            var result = await httpClient.SendAsync(new HttpRequestMessage(method, endpoint));

            if (result.IsSuccessStatusCode)
            {
                var requestResult = new RequestResult<T>();

                try
                {
                    requestResult.Result = JsonConvert.DeserializeObject<T>(await result.Content.ReadAsStringAsync());
                }
                catch (Exception)
                {
                    requestResult.ErrorMessage = "Invalid response format";
                }

                return requestResult;
            }
            else if (result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                return new RequestResult<T>
                {
                    ErrorMessage = "You are not authorized"
                };
            }
            else
            {
                return new RequestResult<T>
                {
                    ErrorMessage = await result.Content.ReadAsStringAsync()
                };
            }
        }

        public void AddAuthentication(string token)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public void RemoveAuthentication()
        {
            httpClient.DefaultRequestHeaders.Authorization = null;
        }

        #endregion Methods
    }
}
