using AdminModule.Resources;
using AdminModule.Views;
using Common.Fonts;
using Common.Helpers;
using Xamarin.Forms;

[assembly: MenuItem("AdminPageTitle", typeof(AppResources), nameof(AdminPage), SolidIconFont.User, 3)]
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
