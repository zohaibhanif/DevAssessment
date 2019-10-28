using DevAssessment.Extensions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;

namespace DevAssessment.ViewModels
{
    public class DashboardPageViewModel : BindableBase
    {
        private IDialogService DialogService { get; }

        public DashboardPageViewModel(IDialogService dialogService)
        {
            DialogService = dialogService;

            DisplayAlertCommand = new DelegateCommand(OnDisplayAlertCommandExecuted);
            DisplayErrorCommand = new DelegateCommand(OnDisplayErrorCommandExecuted);
        }

        public DelegateCommand DisplayAlertCommand { get; }

        public DelegateCommand DisplayErrorCommand { get; }

        private void OnDisplayAlertCommandExecuted()
        {
            DialogService.DisplayAlert("This is sample alert.");
        }

        private void OnDisplayErrorCommandExecuted()
        {
            try
            {
                throw new NullReferenceException();
            }
            catch (Exception ex)
            {
                DialogService.DisplayError(ex);
            }
        }
    }
}
