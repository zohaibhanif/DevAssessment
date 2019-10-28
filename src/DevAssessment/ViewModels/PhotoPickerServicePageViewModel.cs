using DevAssessment.Services;
using Prism.Commands;
using Prism.Mvvm;
using System.IO;
using Xamarin.Forms;

namespace DevAssessment.ViewModels
{
    public class PhotoPickerServicePageViewModel : BindableBase
    {
        private IPhotoPickerService PhotoPickerService { get; }

        public PhotoPickerServicePageViewModel(IPhotoPickerService photoPickerService)
        {
            PhotoPickerService = photoPickerService;

            PickPhotoCommand = new DelegateCommand(OnPickPhotoCommandExecuted);
        }

        public ImageSource ImageSource
        {
            get => _imageSource;
            set => SetProperty(ref _imageSource, value);
        }

        private ImageSource _imageSource;

        public DelegateCommand PickPhotoCommand { get; }

        private async void OnPickPhotoCommandExecuted()
        {
            Stream stream = await PhotoPickerService.GetImageStreamAsync();

            if (stream != null)
            {
                ImageSource = ImageSource.FromStream(() => stream);
            }
        }
    }
}
