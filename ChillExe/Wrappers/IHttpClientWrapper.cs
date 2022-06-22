using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ChillExe.Wrappers
{
    public interface IHttpClientWrapper
    {
        public Task<HttpResponseMessage> GetAsync(string uri);
    }
}
