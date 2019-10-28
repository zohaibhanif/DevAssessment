using Common.Helpers;
using DevAssessment.Resources;
using DevAssessment.Views;
using Xamarin.Forms;

[assembly: MenuItem("PhotoPickerPageTitle", typeof(AppResources), nameof(PhotoPickerServicePage), 5)]
namespace DevAssessment.Views
{
    public partial class PhotoPickerServicePage : ContentPage
    {
        public PhotoPickerServicePage()
        {
            InitializeComponent();
        }
    }
}
