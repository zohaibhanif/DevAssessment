using DevAssessment.Resources;
using DevAssessment.Services;
using Prism.Commands;
using Prism.Mvvm;

namespace DevAssessment.ViewModels
{
    public class DeviceOrientationServicePageViewModel : BindableBase
    {
        private IDeviceOrientationService DeviceOrientationService { get; }

        public DeviceOrientationServicePageViewModel(IDeviceOrientationService deviceOrientationService)
        {
            DeviceOrientationService = deviceOrientationService;

            OrientationCommand = new DelegateCommand(OnOrientationCommandExecuted);
        }

        public string Orientation
        {
            get => _orientation;
            set => SetProperty(ref _orientation, value);
        }

        private string _orientation;

        public DelegateCommand OrientationCommand { get; }

        private void OnOrientationCommandExecuted()
        {
            DeviceOrientation orientation = DeviceOrientationService.GetOrientation();

            switch (orientation)
            {
                case DeviceOrientation.Landscape:
                    Orientation = AppResources.LabelLandscape;
                    break;
                case DeviceOrientation.Portrait:
                    Orientation = AppResources.LabelPortait;
                    break;
                case DeviceOrientation.Undefined:
                    Orientation = AppResources.LabelUndefined;
                    break;
            }
        }
    }
}
