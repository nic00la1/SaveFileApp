using System.Windows.Input;
using System.Text;
using CommunityToolkit.Maui;


namespace SaveFileApp
{
    public partial class MainPage : ContentPage
    {
        public ICommand openSaveFile;
        public MainPage()
        {
            InitializeComponent();
            openSaveFile = new Command<Task>(SaveFile);
        }

        public async Task SaveFile()
        {
            var stream = new MemoryStream(UTF8Encoding.UTF8.GetBytes("To jest nasz plik!"));
            using var filePicker = await FileSaver.Default.SaveAsync("text.txt", stream);
            if (filePicker.IsSuccessful)
                await DisplayAlertAsync("Tytuł", "Udało się", "OK");
            else
                await DisplayAlertAsync("Tytuł", "Nie udało się", "OK");

        }
    }
}
