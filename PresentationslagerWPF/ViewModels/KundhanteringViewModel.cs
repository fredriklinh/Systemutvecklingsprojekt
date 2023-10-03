using PresentationslagerWPF.Commands;
using PresentationslagerWPF.Models;
using PresentationslagerWPF.Services;
using PresentationslagerWPF.Stores;
using System.Windows.Input;
namespace PresentationslagerWPF.ViewModels
{
    public class KundhanteringViewModel : ObservableObject
    {

        #region NAVIGATION
        public KundhanteringViewModel(NavigationStore navigationStore)
        {
            NavigateLoggaUtCommand = new NavigateCommand<LoggaInViewModel>(new NavigationService<LoggaInViewModel>(navigationStore, () => new LoggaInViewModel(navigationStore)));

        }
        //**** NAVIGATION *******//
        public ICommand NavigateLoggaUtCommand { get; }

        private ICommand exitCommand = null!;
        public ICommand ExitCommand =>
        exitCommand ??= exitCommand = new RelayCommand(() => App.Current.Shutdown());

        #endregion


        #region PRIVATKUND
        //**** PRIVATKUND *******//

        private string privatFörnamn;
        public string PrivatFörnamn { get => privatFörnamn; set { privatFörnamn = value; OnPropertyChanged(); } }

        private string privatEfternamn;
        public string PrivatEfternamn { get => privatEfternamn; set { privatEfternamn = value; OnPropertyChanged(); } }

        private string privatPersonummer;
        public string PrivatPersonummer { get => privatPersonummer; set { privatPersonummer = value; OnPropertyChanged(); } }

        private int postnummer;
        public int Postnummer { get => postnummer; set { postnummer = value; OnPropertyChanged(); } }

        private string mail;
        public string Mail { get => mail; set { mail = value; OnPropertyChanged(); } }

        private ICommand sparaPrivatCommand = null!;
        public ICommand SparaPrivatCommand => sparaPrivatCommand ??= sparaPrivatCommand = new RelayCommand(() =>
        {
            //SPARA
        });
        private ICommand ändraPrivatCommand = null!;
        public ICommand ÄndraPrivatCommand => ändraPrivatCommand ??= ändraPrivatCommand = new RelayCommand(() =>
        {
            //ÄNDRA

        });
        private ICommand taBortPrivatCommand = null!;
        public ICommand TaBortPrivatCommand => taBortPrivatCommand ??= taBortPrivatCommand = new RelayCommand(() =>
        {
            //TABORT

        });
        #endregion


        #region FÖRETAGSKUND


        //**** FÖRETAGSKUND *******//

        private string orgNummer;
        public string OrgNummer
        {
            get { return orgNummer; }
            set { orgNummer = value; OnPropertyChanged(); }
        }

        private string företagsNamn;
        public string FöretagsNamn
        {
            get { return företagsNamn; }
            set { företagsNamn = value; OnPropertyChanged(); }
        }
        private string rabatstatts;
        public string Rabatstatts
        {
            get { return rabatstatts; }
            set { rabatstatts = value; OnPropertyChanged(); }
        }
        private string maxBeloppKredit;
        public string MaxBeloppKredit
        {
            get { return maxBeloppKredit; }
            set { maxBeloppKredit = value; OnPropertyChanged(); }
        }
        private string företagAdress;
        public string FöretagAdress
        {
            get { return företagAdress; }
            set { företagAdress = value; OnPropertyChanged(); }
        }

        private string företagPostnummer;
        public string FöretagPostnummer
        {
            get { return företagPostnummer; }
            set { företagPostnummer = value; OnPropertyChanged(); }
        }

        private string företagOrt;
        public string FöretagOrt
        {
            get { return företagOrt; }
            set { företagOrt = value; OnPropertyChanged(); }
        }

        private string företagTelefonummer;
        public string FöretagTelefonummer
        {
            get { return företagTelefonummer; }
            set { företagTelefonummer = value; OnPropertyChanged(); }
        }
        private string företagMailadress;
        public string FöretagMailadress
        {
            get { return företagMailadress; }
            set { företagMailadress = value; OnPropertyChanged(); }
        }

        private ICommand sparaFöretagCommand = null!;
        public ICommand SparaFöretagCommand => sparaFöretagCommand ??= sparaFöretagCommand = new RelayCommand(() =>
        {
            //Företagskontroller . SparaFöretag
        });
        private ICommand ändraFöretagCommand = null!;
        public ICommand ÄndraFöretagCommand => ändraFöretagCommand ??= ändraFöretagCommand = new RelayCommand(() =>
        {
            //Företagskontroller . Ändra

        });
        private ICommand taBortFöretagCommand = null!;
        public ICommand TaBortFöretagCommand => taBortFöretagCommand ??= taBortFöretagCommand = new RelayCommand(() =>
        {
            //Företagskontroller . TaBort

        });

        #endregion



    }
}
