using DevAssessment.Helpers;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace DevAssessment.Services
{
    public class RestClient : IRestClient
    {
        private HttpClient Client { get; }

        private IApiOption ApiOption { get; }

        public RestClient(IApiOption apiOption)
        {
            ApiOption = apiOption;
            Client = new HttpClient
            {
                BaseAddress = new Uri(apiOption.Host)
            };
        }

        public async Task<HttpResponseMessage> GetAsync(Uri uri)
        {
            var builder = new UriBuilder(string.Format("{0}{1}", ApiOption.Host, uri.ToString()));
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["apiKey"] = ApiOption.ApiKey;
            builder.Query = query.ToString();
            string url = builder.ToString();

            return await Client.GetAsync(new Uri(url));
        }
    }
}
