using DevAssessment.Models;
using Prism.Services.Dialogs;
using System;

namespace DevAssessment.Extensions
{
    public static class DialogExtensions
    {
        public static void DisplayAlert(this IDialogService dialogService, string message)
        {
            var parameters = new DialogParameters();
            parameters.Add(DialogKey.Message, message);
            
            dialogService.ShowDialog("AlertDialogView", parameters, (IDialogResult) => { });
        }

        public static void DisplayError(this IDialogService dialogService, Exception exception, string message = null)
        {
            var parameters = new DialogParameters();

            if (string.IsNullOrWhiteSpace(message))
            {
                parameters.Add(DialogKey.Message, exception.Message);
            }
            else
            {
                parameters.Add(DialogKey.Message, message);
            }
            
            parameters.Add(DialogKey.Exception, exception);

            dialogService.ShowDialog("ErrorDialogView", parameters, (IDialogResult) => { });
        }
    }
}
