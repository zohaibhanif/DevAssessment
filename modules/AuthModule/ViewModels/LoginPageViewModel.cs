using AuthModule.Events;
using AuthModule.Services;
using MockAuthentication.Models;
using Prism.Commands;
using Prism.Events;
using Prism.Logging;
using Prism.Mvvm;
using System.Text.RegularExpressions;

namespace AuthModule.ViewModels
{
    public class LoginPageViewModel : BindableBase
    {
        private IAuthenticationService AuthenticationService { get; }
        private IEventAggregator EventAggregator { get; }
        private ILogger Logger { get; }

        public LoginPageViewModel(IAuthenticationService authenticationService, IEventAggregator eventAggregator, ILogger logger)
        {
            AuthenticationService = authenticationService;
            EventAggregator = eventAggregator;
            Logger = logger;

            LoginCommand = new DelegateCommand(ExecuteLoginCommand, CanExectue).ObservesProperty(() => IsBusy);
        }

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public string _email;

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public string _password;

        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        public bool _isBusy;

        public bool IsNotValid
        {
            get => _isNotValid;
            set => SetProperty(ref _isNotValid, value);
        }

        public bool _isNotValid;

        public string ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }

        public string _errorMessage;

        public DelegateCommand LoginCommand { get; }

        private async void ExecuteLoginCommand()
        {
            SetErrorMessage(string.Empty);

            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                SetErrorMessage("Either Email or Password is not provided");
                return;
            }

            if (!IsValidEmail(Email))
            {
                SetErrorMessage("Email is not valid");
                return;
            }

            IsBusy = true;
            AuthenticationResult result = await AuthenticationService.LoginAsync(Email, Password);
            IsBusy = false;

            if (!result.IsAuthenticated)
            {
                SetErrorMessage(result.ErrorMessage);
                return;
            }

            EventAggregator.GetEvent<UserAuthenticatedEvent>().Publish(result.AccessToken);
        }

        private bool CanExectue()
        {
            return !IsBusy;
        }

        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            return Regex.IsMatch(email, emailPattern);
        }

        private void SetErrorMessage(string message)
        {
            ErrorMessage = message;
            IsNotValid = string.IsNullOrWhiteSpace(message) ? false : true;
        }
    }
}
