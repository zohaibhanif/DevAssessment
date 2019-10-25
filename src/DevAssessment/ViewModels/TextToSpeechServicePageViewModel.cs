using DevAssessment.Services;
using Prism.Commands;
using Prism.Mvvm;

namespace DevAssessment.ViewModels
{
    public class TextToSpeechServicePageViewModel : BindableBase
    {
        private ITextToSpeechService TextToSpeechService { get; }

        public TextToSpeechServicePageViewModel(ITextToSpeechService textToSpeechService)
        {
            TextToSpeechService = textToSpeechService;

            SpeakCommand = new DelegateCommand(OnSpeakCommandExecuted);
        }

        public DelegateCommand SpeakCommand { get; }

        private async void OnSpeakCommandExecuted()
        {
            await TextToSpeechService.SpeakAsync("Hello world");
        }
    }
}
