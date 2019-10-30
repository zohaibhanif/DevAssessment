using Common.Fonts;
using Common.Helpers;
using DevAssessment.Resources;
using DevAssessment.Views;
using Xamarin.Forms;

[assembly: MenuItem("NewsReaderSourcePageTitle", typeof(AppResources), nameof(NewsReaderSourcePage), SolidIconFont.GlobeEurope, 7)]
namespace DevAssessment.Views
{
    public partial class NewsReaderSourcePage : ContentPage
    {
        public NewsReaderSourcePage()
        {
            InitializeComponent();
        }
    }
}
