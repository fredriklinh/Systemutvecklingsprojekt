using PresentationslagerWPF.Commands;
using PresentationslagerWPF.Models;
using PresentationslagerWPF.Services;
using PresentationslagerWPF.Stores;
using System.Windows.Input;

namespace PresentationslagerWPF.ViewModels
{
    public class LoggaInViewModel : ObservableObject
    {

        //**** NAVIGATION *******//
        public ICommand LoggaInCommand { get; }

        public LoggaInViewModel(NavigationStore navigationStore)
        {
            LoggaInCommand = new LoggaInCommand(this, new NavigationService<HuvudMenyViewModel>(navigationStore, () => new HuvudMenyViewModel(navigationStore)));



        }


        //STATUS
        private string status = "Ready";
        public string Status { get { return status; } set { status = value; OnPropertyChanged(); } }


        //Användarnamn för ANVÄNDARE
        private string användarnamn = null!;
        public string Användarnamn { get => användarnamn; set { användarnamn = value; OnPropertyChanged(); } }

        //Lösenord för ANVÄNDARE
        private string lösenord = null!;
        public string Lösenord { get => lösenord; set { lösenord = value; OnPropertyChanged(); } }






    }
}
