using AdminModule.Views;
using MenuHelper;
using Xamarin.Forms;

[assembly: MenuItem("Admin Page", nameof(AdminPage), 3)]
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
