﻿using Common.Helpers;
using DevAssessment.Resources;
using DevAssessment.Views;
using Xamarin.Forms;
using Common.Fonts;

[assembly: MenuItem("DashboardPageTitle", typeof(AppResources), nameof(DashboardPage), SolidIconFont.Home, 1)]
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
