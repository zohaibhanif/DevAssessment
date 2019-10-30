using DevAssessment.Helpers;
using DevAssessment.Models;
using Prism.Events;
using Prism.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevAssessment.Services
{
    public class NewsApiService : INewsApiService
    {
        private IApiService ApiService { get; }

        private IEventAggregator EventAggregator { get; }

        private ILogger Logger { get; }

        private IApiOption ApiOption { get; }

        public NewsApiService(IApiService apiService, IEventAggregator eventAggregator, ILogger logger, IApiOption apiOption)
        {
            ApiService = apiService;
            EventAggregator = eventAggregator;
            Logger = logger;
            ApiOption = apiOption;
        }

        public async Task<List<Source>> GetNewsSourceListAsync()
        {
            var uri = new Uri(string.Format("{0}?country=us&language=en", NewsApiEndpoint.Source), UriKind.Relative);
            var response = await ApiService.GetAndRetry<SourceResponse>(uri, ApiOption.RetryCount, OnRetry);
            return response?.Sources;
        }

        public async Task<List<Article>> GetArticleListAsync(string category)
        {
            var uri = new Uri(string.Format("{0}?country=us&language=en&category={1}", NewsApiEndpoint.TopHeadline, category), UriKind.Relative);
            var response = await ApiService.GetAndRetry<ArticleResponse>(uri, ApiOption.RetryCount, OnRetry);
            return response?.Articles;
        }

        Task OnRetry(Exception e, int retryCount)
        {
            return Task.Factory.StartNew(() => {
                Logger.Debug($"Retry - Attempt #{retryCount} to get sources.");
            });
        }
    }
}
