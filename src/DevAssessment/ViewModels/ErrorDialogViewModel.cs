using DevAssessment.Models;
using Prism.Commands;
using Prism.Logging;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;

namespace DevAssessment.ViewModels
{
    public class ErrorDialogViewModel : BindableBase, IDialogAware
    {
        private ILogger Logger { get; }

        public ErrorDialogViewModel(ILogger logger)
        {
            Logger = logger;

            CloseCommand = new DelegateCommand(() => RequestClose(null));
        }

        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        private string _message;

        public DelegateCommand CloseCommand { get; }

        public event Action<IDialogParameters> RequestClose;

        public bool CanCloseDialog() => true;

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            if (parameters.ContainsKey(DialogKey.Message))
            {
                Message = parameters.GetValue<string>(DialogKey.Message);
            }

            if (parameters.ContainsKey(DialogKey.Exception))
            {
                var exception = parameters.GetValue<Exception>(DialogKey.Exception);
                Logger.Report(exception);
            }
        }
    }
}
