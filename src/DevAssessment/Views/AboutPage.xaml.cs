using Common.Fonts;
using Common.Helpers;
using DevAssessment.Resources;
using DevAssessment.Views;
using Xamarin.Forms;

[assembly: MenuItem("AboutPageTitle", typeof(AppResources), nameof(AboutPage), SolidIconFont.Lightbulb, 2)]
namespace DevAssessment.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }
    }
}
