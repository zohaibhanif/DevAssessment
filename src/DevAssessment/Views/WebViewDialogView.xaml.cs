using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DevAssessment.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WebViewDialogView : ContentView
    {
        private bool IsNavigated { get; set; }

        public WebViewDialogView()
        {
            InitializeComponent();
        }

        private void NewsWebView_Navigating(object sender, WebNavigatingEventArgs e)
        {
            if (IsNavigated)
            {
                e.Cancel = true;
            }
            else
            {
                IsNavigated = true;
            }
        }

        private void NewsWebView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            IsNavigated = true;
        }
    }
}