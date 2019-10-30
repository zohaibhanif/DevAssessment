using Common.Fonts;
using Common.Helpers;
using DevAssessment.Resources;
using DevAssessment.Views;
using Xamarin.Forms;

[assembly: MenuItem("NewsReaderPageTitle", typeof(AppResources), nameof(NewsReaderPage), SolidIconFont.Newspaper, 8)]
namespace DevAssessment.Views
{
    public partial class NewsReaderPage : ContentPage
    {
        public NewsReaderPage()
        {
            InitializeComponent();
        }
    }
}
