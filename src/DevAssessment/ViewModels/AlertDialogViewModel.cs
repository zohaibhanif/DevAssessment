using DevAssessment.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;

namespace DevAssessment.ViewModels
{
    public class AlertDialogViewModel : BindableBase, IDialogAware
    {
        public AlertDialogViewModel()
        {
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
        }
    }
}
