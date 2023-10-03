using Affärslager.KundKontroller;
using Entiteter.Personer;
using PresentationslagerWPF.Commands;
using PresentationslagerWPF.Models;
using PresentationslagerWPF.Services;
using PresentationslagerWPF.Stores;
using System.Windows;
using System.Windows.Input;

namespace PresentationslagerWPF.ViewModels
{
    public class KundhanteringViewModel : ObservableObject
    {

        PrivatkundKontroller privatkundKontroller = new PrivatkundKontroller();
        FöretagskundKontroller företagskundKontroller = new FöretagskundKontroller();

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



        private Privatkund privatkund = null!;
        public Privatkund Privatkund { get => privatkund; set { privatkund = value; OnPropertyChanged(); } }

        private string privatFörnamn;
        public string PrivatFörnamn
        {
            get { return privatFörnamn; }
            set { privatFörnamn = value; OnPropertyChanged(); }
        }

        private string privatEfternamn;
        public string PrivatEfternamn
        {
            get { return privatEfternamn; }
            set { privatEfternamn = value; OnPropertyChanged(); }
        }


        private string privatPersonummer;
        public string PrivatPersonummer
        {
            get { return privatPersonummer; }
            set { privatPersonummer = value; OnPropertyChanged(); }
        }

        private string privatAdress;
        public string PrivatAdress
        {
            get { return privatAdress; }
            set { privatAdress = value; OnPropertyChanged(); }
        }

        private string privatPostnummer;
        public string PrivatPostnummer
        {
            get { return privatPostnummer; }
            set { privatPostnummer = value; OnPropertyChanged(); }
        }
        private string privatMail;
        public string PrivatMail
        {
            get { return privatMail; }
            set { privatMail = value; OnPropertyChanged(); }
        }

        private string privatOrt;
        public string PrivatOrt
        {
            get { return privatOrt; }
            set { privatOrt = value; OnPropertyChanged(); }
        }
        private string privatTelefonummer;
        public string PrivatTelefonummer
        {
            get { return privatTelefonummer; }
            set { privatTelefonummer = value; OnPropertyChanged(); }
        }


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

        #region ISENABLEd

        private bool isEnabledFöretag = false!;
        public bool IsEnabledFöretag { get => isEnabledFöretag; set { isEnabledFöretag = value; OnPropertyChanged(); } }


        private ICommand isEnabledFöretagCommand = null!;
        public ICommand IsEnabledFöretagCommand => isEnabledFöretagCommand ??= isEnabledFöretagCommand = new RelayCommand(() =>
        {
            IsEnabledFöretag = true;
        });

        private bool isEnabledPrivat = false!;
        public bool IsEnabledPrivat { get => isEnabledPrivat; set { isEnabledPrivat = value; OnPropertyChanged(); } }


        private ICommand isEnabledPrivatCommand = null!;
        public ICommand IsEnabledPrivatCommand => isEnabledPrivatCommand ??= isEnabledPrivatCommand = new RelayCommand(() =>
        {
            IsEnabledPrivat = true;
        });
        #endregion



        private string kundnummer;
        public string Kundnummer { get => kundnummer; set { kundnummer = value; OnPropertyChanged(); } }

        private ICommand sökKund = null!;
        public ICommand SökKund => sökKund ??= sökKund = new RelayCommand(() =>
        {
            IsEnabledFöretag = false;
            IsEnabledPrivat = false;

            Privatkund = privatkundKontroller.SökPrivatkund(Kundnummer);
            Företagskund = företagskundKontroller.SökFöretagskund(Kundnummer);

            //Privatkund = privatkundKontroller.SökPrivatkund(Kundnummer);
            if (Privatkund != null)
            {
                PrivatPersonummer = Privatkund.Personnummer;
                PrivatAdress = Privatkund.Adress;
                PrivatPostnummer = Privatkund.Postnummer;
                PrivatOrt = Privatkund.Ort;
                PrivatTelefonummer = Privatkund.Telefonnummer;
                PrivatMail = Privatkund.MailAdress;
                PrivatFörnamn = Privatkund.Förnamn;
                PrivatEfternamn = Privatkund.Efternamn;

                NollaFöretagsKundInformation();

            }
            //Företagskund = företagskundKontroller.SökFöretagskund(Kundnummer);
            else if (Företagskund != null)
            {
                FöretagAdress = Företagskund.Adress;
                FöretagPostnummer = Företagskund.Postnummer;
                FöretagOrt = Företagskund.Ort;
                FöretagTelefonummer = Företagskund.Telefonnummer;
                FöretagMailadress = Företagskund.MailAdress;
                OrgNummer = Företagskund.OrgNr;
                FöretagsNamn = Företagskund.FöretagsNamn;
                Rabatstatts = Företagskund.RabattSats;
                MaxBeloppKredit = Företagskund.MaxBeloppsKreditGräns;

                NollaPrivatkundInformation();
            }
            else
            {

                NollaFöretagsKundInformation();
                NollaPrivatkundInformation();
                MessageBox.Show("Kund finns ej i register. Kontrollera Orgnummer/Personummer", "Kund", MessageBoxButton.OK, MessageBoxImage.Information);

            }
        });


        public void NollaFöretagsKundInformation()
        {
            FöretagAdress = null;
            FöretagPostnummer = null;
            FöretagOrt = null;
            FöretagTelefonummer = null;
            FöretagMailadress = null;
            OrgNummer = null;
            FöretagsNamn = null;
            Rabatstatts = 0;
            MaxBeloppKredit = 0;

        }
        public void NollaPrivatkundInformation()
        {

            PrivatPersonummer = null;
            PrivatAdress = null;
            PrivatPostnummer = null;
            PrivatOrt = null;
            PrivatTelefonummer = null;
            PrivatMail = null;
            PrivatFörnamn = null;
            PrivatEfternamn = null;
        }

        #region FÖRETAGSKUND



        //**** FÖRETAGSKUND *******//

        private Företagskund företagskund = null!;
        public Företagskund Företagskund { get => företagskund; set { företagskund = value; OnPropertyChanged(); } }

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
        private double rabatstatts;
        public double Rabatstatts
        {
            get { return rabatstatts; }
            set { rabatstatts = value; OnPropertyChanged(); }
        }
        private double maxBeloppKredit;
        public double MaxBeloppKredit
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
            Företagskund = företagskundKontroller.RegistreraFöretagskund(MaxBeloppKredit, FöretagAdress, FöretagPostnummer, FöretagOrt, FöretagTelefonummer, FöretagMailadress, OrgNummer, FöretagsNamn, Rabatstatts);
            if (Företagskund == null)
            {
                MessageBox.Show($"Sparande Misslyckades", "Företagskund", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                MessageBox.Show($"{Företagskund.FöretagsNamn} har lagts till", "Företagskund", MessageBoxButton.OK, MessageBoxImage.Information);

            }

        });
        //private ICommand ändraFöretagCommand = null!;
        //public ICommand ÄndraFöretagCommand => ändraFöretagCommand ??= ändraFöretagCommand = new RelayCommand(() =>
        //{


        //});
        private ICommand taBortFöretagCommand = null!;
        public ICommand TaBortFöretagCommand => taBortFöretagCommand ??= taBortFöretagCommand = new RelayCommand(() =>
        {


        });

        #endregion



    }
}
