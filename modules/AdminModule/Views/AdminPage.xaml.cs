using AdminModule.Resources;
using AdminModule.Views;
using Common.Helpers;
using Xamarin.Forms;

[assembly: MenuItem("AdminPageTitle", typeof(AppResources), nameof(AdminPage), 3)]
namespace AdminModule.Views
{
    public partial class AdminPage : ContentPage
    {
        public AdminPage()
        {
            InitializeComponent();
        }
    }
}
