using System.IO;
using System.Net;
using System.Threading.Tasks;
using Assets.Scripts.Services;
using Bloops.Shared.Responses;

namespace Assets.Scripts.Api
{
    public static class ApiClient
    {
        public static string BaseUrl { get; set; }

        public static string Key { get; set; }

        public static string Token { get; set; }

        private static async Task<RES> CallAsync<RES>(HttpMethod method, string uri)
        {
            HttpWebRequest request = GetRequest(method, uri);
            return await GetResponseAsync<RES>(request);
        }

        private static async Task<RES> CallAsync<REQ, RES>(HttpMethod method, string uri, REQ req)
        {
            HttpWebRequest request = GetRequest(method, uri);
            if (req != null)
            {
                using (StreamWriter writer = new StreamWriter(await request.GetRequestStreamAsync()))
                {
                    await writer.WriteAsync(SerializationService.ToJson(req));
                }
            }
            return await GetResponseAsync<RES>(request);
        }

        private static HttpWebRequest GetRequest(HttpMethod method, string uri)
        {
            HttpWebRequest request = WebRequest.CreateHttp(BaseUrl + uri);
            request.Method = method.ToString();
            request.ContentType = "application/json";
            request.Headers.Add("X-API-Key", $"{Key}");
            if (Token != null)
            {
                request.Headers.Add("Authorization", $"bearer {Token}");
            }
            return request;
        }

        private static async Task<T> GetResponseAsync<T>(HttpWebRequest request)
        {
            HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string body = await reader.ReadToEndAsync();
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApiException(SerializationService.FromJson<ErrorResponse>(body));
                }
                else
                {
                    return SerializationService.FromJson<T>(body);
                }
            }
        }
    }

    public enum HttpMethod
    {
        GET,
        POST,
        PUT,
        DELETE,
        PATCH
    }
}
