using System.Windows.Input;

namespace SaveFileApp
{
    public partial class MainPage : ContentPage
    {
        public ICommand openSaveFile;
        public MainPage()
        {
            InitializeComponent();
        }

        public async Task SaveFile(CancellationToken cancellationToken)
        {
            var fileSaveDialog = new 
        }
    }
}
