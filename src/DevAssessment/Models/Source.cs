using Prism.Mvvm;

namespace DevAssessment.Models
{
    public class Source : BindableBase
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public string Category { get; set; }

        public string Language { get; set; }

        public string Country { get; set; }

        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        private bool _isEnabled = true;
    }
}
