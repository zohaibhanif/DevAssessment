using DevAssessment.Resources;
using Prism.Commands;
using Prism.Logging;
using Prism.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Essentials.Interfaces;
using Category = DevAssessment.Models.Category;

namespace DevAssessment.ViewModels
{
    public class NewsReaderPageViewModel : ViewModelBase
    {
        private INavigationService NavigationService { get; }

        private ILogger Logger { get; }

        public NewsReaderPageViewModel(INavigationService navigationService, ILogger logger, IConnectivity connectivity) : base(connectivity)
        {
            Logger = logger;
            NavigationService = navigationService;
            CategoryList = new ObservableCollection<Category>()
            {
                new Category{ DisplayName = AppResources.BusinessText, Name = "Business" },
                new Category{ DisplayName = AppResources.EntertainmentText , Name = "Entertainment" },
                new Category{ DisplayName = AppResources.GeneralText, Name = "General" },
                new Category{ DisplayName = AppResources.HealthText, Name = "Health" },
                new Category{ DisplayName = AppResources.ScienceText, Name = "Science" },
                new Category{ DisplayName = AppResources.SportsText, Name = "Sports" },
                new Category{ DisplayName = AppResources.TechnologyText , Name = "Technology" }
            };

            NavigationCommand = new DelegateCommand<Category>(OnNavigationCommandExecuted);
        }

        public IEnumerable<Category> CategoryList { get; }

        public DelegateCommand<Category> NavigationCommand { get; }

        private async void OnNavigationCommandExecuted(Category category)
        {
            await NavigationService.NavigateAsync("ArticleListPage", ("category", category.Name));
        }
    }
}
