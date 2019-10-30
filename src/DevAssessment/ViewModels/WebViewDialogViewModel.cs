using DevAssessment.Models;
using Prism.Commands;
using Prism.Logging;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;

namespace DevAssessment.ViewModels
{
    public class WebViewDialogViewModel : BindableBase, IDialogAware
    {
        private ILogger Logger { get; }

        public WebViewDialogViewModel(ILogger logger)
        {
            Logger = logger;

            CloseCommand = new DelegateCommand(() => RequestClose(null));
        }

        public string Url
        {
            get => _url;
            set => SetProperty(ref _url, value);
        }

        private string _url;

        public DelegateCommand CloseCommand { get; }

        public event Action<IDialogParameters> RequestClose;

        public bool CanCloseDialog() => true;

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            if (parameters.ContainsKey(DialogKey.Url))
            {
                Url = parameters.GetValue<string>(DialogKey.Url);
            }
        }
    }
}
