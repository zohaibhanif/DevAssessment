using Common.Fonts;
using Common.Helpers;
using DevAssessment.Resources;
using DevAssessment.Views;
using Xamarin.Forms;

[assembly: MenuItem("TextToSpeechPagetTitle", typeof(AppResources), nameof(TextToSpeechServicePage), SolidIconFont.FileInvoice, 6)]
namespace DevAssessment.Views
{
    public partial class TextToSpeechServicePage : ContentPage
    {
        public TextToSpeechServicePage()
        {
            InitializeComponent();
        }
    }
}
