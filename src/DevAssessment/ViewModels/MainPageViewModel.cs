using AuthModule.Events;
using AuthModule.Services;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;

namespace DevAssessment.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private IEventAggregator EventAggregator { get; }

        public MainPageViewModel(IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;

            LogoutCommand = new DelegateCommand(ExecuteLogoutCommand);
        }

        public DelegateCommand LogoutCommand { get; }

        private void ExecuteLogoutCommand()
        {
            EventAggregator.GetEvent<LogoutRequestEvent>().Publish();
        }
    }
}
