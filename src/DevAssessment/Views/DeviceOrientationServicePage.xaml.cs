using Common.Helpers;
using DevAssessment.Resources;
using DevAssessment.Views;
using Xamarin.Forms;

[assembly: MenuItem("DeviceOrientationPageTitle", typeof(AppResources), nameof(DeviceOrientationServicePage), 4)]
namespace DevAssessment.Views
{
    public partial class DeviceOrientationServicePage : ContentPage
    {
        public DeviceOrientationServicePage()
        {
            InitializeComponent();
        }
    }
}
