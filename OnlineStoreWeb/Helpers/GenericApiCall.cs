using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace OnlineStoreWeb.Helper
{
    public interface IGenericApiCall
    {
        Task<(T Data, int StatusCode, bool IsSuccessStatusCode)> PostAPIAysnc<T>(object param, string URL, string Access_token);
        Task<(T Data, int StatusCode, bool IsSuccessStatusCode)> GetAPIAysnc<T>(object param, string URL, string Access_token);
    }
    public class GenericApiCall : IGenericApiCall
    {
        string BaseUrl = "https://localhost:7046/api/";
        public async Task<(T Data, int StatusCode, bool IsSuccessStatusCode)> PostAPIAysnc<T>(object param, string URL, string Access_token)
        {

            T Result = default(T);
            int StatusCode = 0;
            bool IsSuccessStatusCode = false;
            using (var API = new HttpClient())
            {
                try
                {
                    API.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    API.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Access_token);
                    API.BaseAddress = new Uri(BaseUrl + URL);
                    var postTask = await API.PostAsJsonAsync(new Uri(BaseUrl + URL), param).ConfigureAwait(false);
                    var ResultData = postTask.Content.ReadAsStringAsync().Result;
                    StatusCode = (int)postTask.StatusCode;
                    if (postTask.IsSuccessStatusCode)
                    {
                        IsSuccessStatusCode = true;
                        Result = JsonConvert.DeserializeObject<T>(ResultData);

                    }
                }
                catch (Exception ex)
                {

                }
            }
            return (Result, StatusCode, IsSuccessStatusCode);
        }

        public async Task<(T Data, int StatusCode, bool IsSuccessStatusCode)> GetAPIAysnc<T>(object param, string URL, string Access_token)
        {

            T Result = default(T);
            int StatusCode = 0;
            bool IsSuccessStatusCode = false;
            using (var API = new HttpClient())
            {
                try
                {
                    API.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    API.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Access_token);

                    API.BaseAddress = new Uri(BaseUrl + URL);
                    var postTask = await API.GetAsync(new Uri(BaseUrl + URL)).ConfigureAwait(false);
                    var ResultData = postTask.Content.ReadAsStringAsync().Result;
                    StatusCode = (int)postTask.StatusCode;
                    if (postTask.IsSuccessStatusCode)
                    {
                        IsSuccessStatusCode = true;
                        Result = JsonConvert.DeserializeObject<T>(ResultData);

                    }
                }
                catch (Exception ex)
                {

                }
            }
            return (Result, StatusCode, IsSuccessStatusCode);
        }

    }





}