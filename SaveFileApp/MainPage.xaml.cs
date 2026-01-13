using System.Windows.Input;
using System.Text;
using CommunityToolkit.Maui.Storage;


namespace SaveFileApp
{
    public partial class MainPage : ContentPage
    {
        public ICommand openSaveFile;
        public ICommand selectFileBtn;

        public MainPage()
        {
            InitializeComponent();
            openSaveFile = new Command(async() => await SaveFile());

            Przycisk.Command = openSaveFile;
            Przycisk2.Command = selectFileBtn;
        }

        public async Task SelectFile()
        {
            var filePicker = await FilePicker.Default.PickAsync(new PickOptions 
            {
                PickerTitle = "Wybierz plik",
                FileTypes = FilePickerFileType.Images
            });
            if (filePicker != null)
                await DisplayAlertAsync("Twój plik", $"Wybrany plik to: {filePicker.FullPath}", "OK");
        }

        public async Task SaveFile()
        {
            var stream = new MemoryStream(Encoding.Default.GetBytes("To jest nasz plik!"));
            using var filePicker = await FileSaver.Default.SaveAsync("text.txt", stream);
            if (filePicker.IsSuccessful)
                await DisplayAlertAsync("Tytuł", "Udało się", "OK");
            else
                await DisplayAlertAsync("Tytuł", "Nie udało się", "OK");
        }
    }
}
