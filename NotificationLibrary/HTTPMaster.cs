using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NotificationLibrary
{
    public class HTTPMaster
    {
        private static readonly HttpClient postclient = new HttpClient();
        public Task<HttpResponseMessage> SendPost(JObject jsonObject, string URL)
        {
            var jsoncontent = JsonConvert.SerializeObject(jsonObject);
            var buffer = Encoding.UTF8.GetBytes(jsoncontent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return postclient.PostAsync(URL, byteContent);
        }
        public Task<HttpResponseMessage> SendPost(Dictionary<string,string> keyValuePairs, string URL)
        {
            var content = new FormUrlEncodedContent(keyValuePairs);
            return postclient.PostAsync(URL, content);
        }
    }
}
