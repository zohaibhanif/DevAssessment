using Common.Helpers;
using DevAssessment.Resources;
using DevAssessment.Views;
using Xamarin.Forms;

[assembly: MenuItem("DashboardPageTitle", typeof(AppResources), nameof(DashboardPage), 1)]
namespace DevAssessment.Views
{
    public partial class DashboardPage : ContentPage
    {
        public DashboardPage()
        {
            InitializeComponent();
        }
    }
}
