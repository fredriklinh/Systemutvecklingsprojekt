using Affärslager;
using Entiteter;
using PresentationslagerWPF.Commands;
using PresentationslagerWPF.Models;
using PresentationslagerWPF.Stores;
using PresentationslagerWPF.Views;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PresentationslagerWPF.ViewModels
{
    public class HomeViewModel : ObservableObject
    {

        BokningsKontroller bokningsKontroller = new BokningsKontroller();

        private Användare inlogg;
        public Användare Inlogg { get => inlogg; set { inlogg = value; OnPropertyChanged(); } }


        private string status = "Ready";
        public string Status { get { return status; } set { status = value; OnPropertyChanged(); } }


        public ICommand NavigateHuvudMenyCommand { get; }

        public HomeViewModel(NavigateHuvudMenyCommand navigationStore)
        {
            NavigateHuvudMenyCommand = new NavigateHuvudMenyCommand(navigationStore);
        }

        //Användarnamn för ANVÄNDARE
        private string användarnamn = null!;
        public string Användarnamn { get => användarnamn; set { användarnamn = value; OnPropertyChanged(); } }

        //Lösenord för ANVÄNDARE
        private string lösenord = null!;
        public string Lösenord { get => lösenord; set { lösenord = value; OnPropertyChanged(); } }


        //Command för att trigga logga in och navigera mellan fönster. 
        private ICommand inloggCommand = null!;
        public ICommand InloggCommand => inloggCommand ??= inloggCommand = new RelayCommand(() =>
        {

            Inlogg = bokningsKontroller.Inloggning(användarnamn, lösenord);
            if (Inlogg == null)
            {
                Status = $"Du har skrivit in fel användarnamn eller lösenord";
            }
            else
            {
                Status = $"Inloggning Lyckades";
            }

        });
        // Stänger ner applikationen
        private ICommand exitCommand = null!;
        public ICommand ExitCommand =>
        exitCommand ??= exitCommand = new RelayCommand(() => App.Current.Shutdown());


        //int id = int.Parse(TextBoxAnstNr.Text);
        //string password = TextBoxLösen.Password;
        //anv = BokningsKontroller.Inloggning(Användarnamn, Lösenord);

        //    if (anv != null)
        //    {
        //        this.Hide();
        //NÄsta sida ska öppnas här
        //HuvudMeny huvudMeny = new HuvudMeny(anv);
        //huvudMeny.Show();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Du har anget fel information");
        //    }


    }
}
