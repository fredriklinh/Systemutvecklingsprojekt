using Affärslager;
using Entiteter.Personer;
using Entiteter.Tjänster;
using PresentationslagerWPF.Commands;
using PresentationslagerWPF.Models;
using PresentationslagerWPF.Services;
using PresentationslagerWPF.Stores;
using System.Collections.ObjectModel;
using System.Security;
using System.Windows.Input;

namespace PresentationslagerWPF.ViewModels
{
    public class LoggaInViewModel : ObservableObject
    {
        AnvändarKontroller användarKontroller = new AnvändarKontroller();

        //**** NAVIGATION *******//
        public ICommand LoggaInCommand { get; }

        public LoggaInViewModel(NavigationStore navigationStore)
        {
            LoggaInCommand = new LoggaInCommand(this, new NavigationService<HuvudMenyViewModel>(navigationStore, () => new HuvudMenyViewModel(navigationStore, Användare = användarKontroller.Inloggning(Användarnamn, Password))));

        }

        //STATUS
        private string status = "Ready";
        public string Status { get { return status; } set { status = value; OnPropertyChanged(); } }


        //Användarnamn för ANVÄNDARE
        private string användarnamn = null!;
        public string Användarnamn
        {
            get => användarnamn; set
            {
                användarnamn = value; OnPropertyChanged();
            }
        }

        //Lösenord för ANVÄNDARE
        //private string lösenord = null!;
        //public string Lösenord { 
        //    get => lösenord; 
        //    set { lösenord = value; OnPropertyChanged();
        //    } }

        //Observable object användare


        private Användare användare = null!;
        public Användare Användare { get => användare; set { användare = value; OnPropertyChanged(); } }

        //OBS DENNA SKA VARA PRIVAT FÖR ATT VARA 100% KORREKT MVVM
        public string Password { get; set; }
        public SecureString SecurePassword { get; set; }

        //AVBRYT
        private ICommand exitCommand = null!;
        public ICommand ExitCommand =>
        exitCommand ??= exitCommand = new RelayCommand(() => App.Current.Shutdown());


    }
}
