using PresentationslagerWPF.Commands;
using PresentationslagerWPF.Models;
using System.Windows.Input;

namespace PresentationslagerWPF.ViewModels
{
    public class HomeViewModel : ObservableObject
    {
        public string WelcomeMessage => "Welcome";

        public ICommand NavigateHuvudMenyCommand { get; }

        //Användarnamn för ANVÄNDARE
        private string användarnamn = null!;
        public string Användarnamn { get => användarnamn; set { användarnamn = value; OnPropertyChanged(); } }

        //Lösenord för ANVÄNDARE
        private string lösenord = null!;
        public string Lösenord { get => lösenord; set { lösenord = value; OnPropertyChanged(); } }


        //Command för att trigga logga in och navigera mellan fönster. 
        private ICommand loggaInCommand = null!;
        public ICommand LoggaInCommand => loggaInCommand ??= loggaInCommand = new RelayCommand(() =>
        {
            //OBS. VÅR METOD FÖR ATT LOGGA IN HÄR
            //Expedit e = bokningsKontroller.LoggaIn(Användarnamn, Lösenord);
            //if (e != null)
            //{
            //    HuvudMenyViewModel HuvudMeny = new HuvudMenyViewModel(e);
            //    bool result = windowService.ShowDialog(HuvudMeny);
            //}
            //else
            //{
            //    MessageBox.Show("Misslyckad inloggning");
            //}
        });
        // Stänger ner applikationen
        private ICommand exitCommand = null!;
        public ICommand ExitCommand =>
        exitCommand ??= exitCommand = new RelayCommand(() => App.Current.Shutdown());


    }
}
