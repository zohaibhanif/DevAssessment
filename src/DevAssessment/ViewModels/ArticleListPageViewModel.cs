using DevAssessment.Extensions;
using DevAssessment.Models;
using DevAssessment.Services;
using Prism.AppModel;
using Prism.Commands;
using Prism.Logging;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Essentials.Interfaces;

namespace DevAssessment.ViewModels
{
    public class ArticleListPageViewModel : ViewModelBase, IAutoInitialize
    {
        private INewsApiService NewApiService { get; }

        private IDialogService DialogService { get; }

        private ILogger Logger { get; }

        public ArticleListPageViewModel(IDialogService dialogService, ILogger logger, INewsApiService newApiService, IConnectivity connectivity) : base(connectivity)
        {
            Logger = logger;
            DialogService = dialogService;
            NewApiService = newApiService;
            ArticleList = new ObservableCollection<Article>();

            SelectArticleCommand = new DelegateCommand<Article>(OnSelectArticleCommandExecuted);
        }

        [AutoInitialize("category", true)]
        public string Category
        {
            get => _category;
            set => SetProperty(ref _category, value);
        }

        private string _category;

        public IEnumerable<Article> ArticleList
        {
            get => _articleList;
            set => SetProperty(ref _articleList, value);
        }

        private IEnumerable<Article> _articleList;

        public DelegateCommand<Article> SelectArticleCommand { get; }

        public override async void OnAppearing()
        {
            try
            {
                IsBusy = true;
                var articleList = await NewApiService.GetArticleListAsync(Category);

                if (articleList != null && articleList.Count > 0)
                {
                    ArticleList = new ObservableCollection<Article>(articleList);
                }
            }
            catch (Exception ex)
            {
                DialogService.DisplayError(ex, "Error occurred while fetching data from server.");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private void OnSelectArticleCommandExecuted(Article article)
        {
            var parameters = new DialogParameters();
            parameters.Add(DialogKey.Url, article.Url);

            DialogService.ShowDialog("WebViewDialogView", parameters, (IDialogResult) => { });
        }
    }
}
