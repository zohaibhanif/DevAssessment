using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DevAssessment.Services
{
    public interface IRestClient
    {
        Task<HttpResponseMessage> GetAsync(Uri uri);
    }
}
