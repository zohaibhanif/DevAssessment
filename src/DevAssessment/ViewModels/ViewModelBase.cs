using Prism.AppModel;
using Prism.Mvvm;
using Xamarin.Essentials;
using Xamarin.Essentials.Interfaces;

namespace DevAssessment.ViewModels
{
    public class ViewModelBase : BindableBase, IPageLifecycleAware
    {
        public ViewModelBase(IConnectivity connectivity)
        {
            connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
            IsNotConnected = Connectivity.NetworkAccess != NetworkAccess.Internet;
        }

        ~ViewModelBase()
        {
            Connectivity.ConnectivityChanged -= Connectivity_ConnectivityChanged;
        }

        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        private bool _isBusy;

        public bool IsNotConnected
        {
            get => _isNotConnected;
            set => SetProperty(ref _isNotConnected, value);
        }

        private bool _isNotConnected;

        public virtual void OnAppearing()
        {
        }

        public virtual void OnDisappearing()
        {
        }

        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            IsNotConnected = e.NetworkAccess != NetworkAccess.Internet;
        }
    }
}
