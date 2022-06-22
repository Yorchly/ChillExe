using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ChillExe.Wrappers
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private HttpClient httpClient;

        public HttpClientWrapper() =>
            httpClient = new HttpClient();

        public async Task<HttpResponseMessage> GetAsync(string uri) =>
            await httpClient.GetAsync(uri);
    }
}
