using DevAssessment.Views;
using MenuHelper;
using Xamarin.Forms;

[assembly: MenuItem("Device Orientation", nameof(DeviceOrientationServicePage), 4)]
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
