using DevAssessment.Extensions;
using DevAssessment.Models;
using DevAssessment.Services;
using Prism.Commands;
using Prism.Logging;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Essentials.Interfaces;

namespace DevAssessment.ViewModels
{
    public class NewsReaderSourcePageViewModel : ViewModelBase
    {
        private INewsApiService NewApiService { get; }

        private IDialogService DialogService { get; }

        private ILogger Logger { get; }

        public NewsReaderSourcePageViewModel(IDialogService dialogService, ILogger logger, INewsApiService newApiService, IConnectivity connectivity) : base(connectivity)
        {
            Logger = logger;
            DialogService = dialogService;
            NewApiService = newApiService;
            SourceList = new ObservableCollection<Source>();

            DisableSourceCommand = new DelegateCommand(OnDisableSourceCommandExecuted);
        }

        public IEnumerable<Source> SourceList
        {
            get => _sourceList;
            set => SetProperty(ref _sourceList, value);
        }

        private IEnumerable<Source> _sourceList;

        public bool DisableAllSources
        {
            get => _disableAllSources;
            set => SetProperty(ref _disableAllSources, value);
        }

        private bool _disableAllSources;

        public DelegateCommand DisableSourceCommand { get; }

        public override async void OnAppearing()
        {
            try
            {
                IsBusy = true;
                var sourceList = await NewApiService.GetNewsSourceListAsync();

                if (sourceList != null && sourceList.Count > 0)
                {
                    SourceList = new ObservableCollection<Source>(sourceList);
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

        private void OnDisableSourceCommandExecuted()
        {
            SourceList.ToList().ForEach(x => x.IsEnabled = !DisableAllSources);
        }
    }
}
