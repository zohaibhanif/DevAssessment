using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace DevAssessment.Services
{
    public class ApiService : IApiService
    {
        private IRestClient Client { get; }

        private INetworkService NetworkService { get; }

        public ApiService(IRestClient client, INetworkService networkService)
        {
            Client = client;
            NetworkService = networkService;
        }

        public async Task<T> GetAsync<T>(Uri uri) where T : class
        {
            return await ProcessGetRequest<T>(uri);
        }

        #region With Retries

        public async Task<T> GetAndRetry<T>(Uri uri, int retryCount, Func<Exception, int, Task> onRetry = null) where T : class
        {
            var func = new Func<Task<T>>(() => ProcessGetRequest<T>(uri));
            return await NetworkService.Retry<T>(func, retryCount, onRetry);
        }

        public async Task<T> GetAndRetry<T>(Uri uri, Func<int, TimeSpan> sleepDurationProvider, int retryCount, Func<Exception, TimeSpan, Task> onWaitAndRetry = null) where T : class
        {
            var func = new Func<Task<T>>(() => ProcessGetRequest<T>(uri));
            return await NetworkService.WaitAndRetry<T>(func, sleepDurationProvider, retryCount, onWaitAndRetry);
        }

        #endregion

        #region Inner Methods

        private async Task<T> ProcessGetRequest<T>(Uri uri)
        {
            var response = await Client.GetAsync(uri);
            var rawResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(rawResponse);
        }

        #endregion
    }
}
