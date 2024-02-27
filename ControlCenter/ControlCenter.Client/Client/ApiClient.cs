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

        private const string BaseUrl = "http://localhost:55528/";

        private readonly HttpClient httpClient;

        #endregion Fields

        #region Constructor

        public ApiClient()
        {
            var handler = new HttpClientHandler();
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.ServerCertificateCustomValidationCallback =
                (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                };

            httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(BaseUrl)
            };
        }

        #endregion Constructor

        #region Methods

        public async Task<RequestResult> SendAsync(HttpMethod method, string endpoint, object data = null)
        {
            var requestMessage = new HttpRequestMessage(method, endpoint);

            if (data != null)
                requestMessage.Content = new StringContent(JsonConvert.SerializeObject(data));

            var result = await httpClient.SendAsync(requestMessage);

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

        public async Task<RequestResult<T>> SendAsync<T>(HttpMethod method, string endpoint, object data = null)
        {
            var requestMessage = new HttpRequestMessage(method, endpoint);

            if (data != null)
                requestMessage.Content = new StringContent(JsonConvert.SerializeObject(data));

            var result = await httpClient.SendAsync(requestMessage);

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

        public void ClearAuthentication()
        {
            httpClient.DefaultRequestHeaders.Authorization = null;
        }

        #endregion Methods
    }
}
