using Affärslager;
using Affärslager.KundKontroller;
using Entiteter.Personer;
using Entiteter.Tjänster;
using Microsoft.IdentityModel.Tokens;
using PresentationslagerWPF.Commands;
using PresentationslagerWPF.Models;
using PresentationslagerWPF.Services;
using PresentationslagerWPF.Stores;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace PresentationslagerWPF.ViewModels
{
    public class KundhanteringViewModel : ObservableObject
    {

        PrivatkundKontroller privatkundKontroller = new PrivatkundKontroller();
        FöretagskundKontroller företagskundKontroller = new FöretagskundKontroller();
        BokningsKontroller bokningsKontroller = new BokningsKontroller();

        #region NAVIGATION
        public KundhanteringViewModel(NavigationStore navigationStore, Användare användare)
        {

            NavigateLoggaUtCommand = new NavigateCommand<LoggaInViewModel>(new NavigationService<LoggaInViewModel>(navigationStore, () => new LoggaInViewModel(navigationStore)));
            TillbakaCommand = new NavigateCommand<HuvudMenyViewModel>(new NavigationService<HuvudMenyViewModel>(navigationStore, () => new HuvudMenyViewModel(navigationStore, användare)));
            UppddateraCommand = new NavigateCommand<KundhanteringViewModel>(new NavigationService<KundhanteringViewModel>(navigationStore, () => new KundhanteringViewModel(navigationStore, användare)));

        }
        //**** NAVIGATION *******//
        public ICommand UppddateraCommand { get; }

        public ICommand NavigateLoggaUtCommand { get; }

        private ICommand exitCommand = null!;
        public ICommand ExitCommand =>
        exitCommand ??= exitCommand = new RelayCommand(() => App.Current.Shutdown());

        public ICommand TillbakaCommand { get; }

        #endregion

        #region ISENABLEd

        private bool isEnabledFöretag = false!;
        public bool IsEnabledFöretag { get => isEnabledFöretag; set { isEnabledFöretag = value; OnPropertyChanged(); } }


        private ICommand isEnabledFöretagCommand = null!;
        public ICommand IsEnabledFöretagCommand => isEnabledFöretagCommand ??= isEnabledFöretagCommand = new RelayCommand(() =>
        {
            IsEnabledFöretag = true;
            IsEnabledPrivat = false;
        });

        private bool isEnabledPrivat = false!;
        public bool IsEnabledPrivat { get => isEnabledPrivat; set { isEnabledPrivat = value; OnPropertyChanged(); } }


        private ICommand isEnabledPrivatCommand = null!;
        public ICommand IsEnabledPrivatCommand => isEnabledPrivatCommand ??= isEnabledPrivatCommand = new RelayCommand(() =>
        {
            IsEnabledPrivat = true;
            IsEnabledFöretag = false;
        });

        private bool isEnabledBokning = false;
        public bool IsEnabledBokning { get => isEnabledBokning; set { isEnabledBokning = value; OnPropertyChanged(); } }


        private ICommand isEnabledBokningCommand = null!;
        public ICommand IsEnabledBokningCommand => isEnabledBokningCommand ??= isEnabledBokningCommand = new RelayCommand(() =>
        {
            if (valdBokningSelectedItem.Avbeställningsskydd.Equals(true))
            {
                isEnabledBokning = false;
            }
            else
            {
                isEnabledBokning = true;
            }

        });
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


        //private ICommand sparaPrivatCommand = null!;
        //public ICommand SparaPrivatCommand => sparaPrivatCommand ??= sparaPrivatCommand = new RelayCommand(() =>
        //{

        //});
        //private ICommand ändraPrivatCommand = null!;
        //public ICommand ÄndraPrivatCommand => ändraPrivatCommand ??= ändraPrivatCommand = new RelayCommand(() =>
        //{
        //    //ÄNDRA

        //});
        //private ICommand taBortPrivatCommand = null!;
        //public ICommand TaBortPrivatCommand => taBortPrivatCommand ??= taBortPrivatCommand = new RelayCommand(() =>
        //{
        //    //TABORT

        //});

        #endregion

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

        public bool enBool;
        private ICommand sparaFöretagCommand = null!;
        public ICommand SparaFöretagCommand => sparaFöretagCommand ??= sparaFöretagCommand = new RelayCommand(() =>
        {
            IsEnabledFöretag = false;

            företagskundKontroller.KontrollFKund(OrgNummer, enBool);
            if (!OrgNummer.IsNullOrEmpty() && !FöretagTelefonummer.IsNullOrEmpty() && !FöretagAdress.IsNullOrEmpty() && !FöretagPostnummer.IsNullOrEmpty() && !FöretagMailadress.IsNullOrEmpty() && !FöretagsNamn.IsNullOrEmpty() && Rabatstatts != null && enBool == false)
            {
                Företagskund = företagskundKontroller.RegistreraFöretagskund(MaxBeloppKredit, FöretagAdress, FöretagPostnummer, FöretagOrt, FöretagTelefonummer, FöretagMailadress, OrgNummer, FöretagsNamn, Rabatstatts);
                MessageBox.Show($"{Företagskund.FöretagsNamn} har lagts till", "Företagskund", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            if (OrgNummer.IsNullOrEmpty() || FöretagTelefonummer.IsNullOrEmpty() || FöretagAdress.IsNullOrEmpty() || FöretagPostnummer.IsNullOrEmpty() || FöretagMailadress.IsNullOrEmpty() || FöretagsNamn.IsNullOrEmpty() || Rabatstatts == 0 || MaxBeloppKredit == 0)
            {
                MessageBox.Show($"Information saknas, fyll i och försök igen!", "Företagskund", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            if (enBool == true)
            {
                MessageBox.Show($"Företagskund med {OrgNummer} finns redan registrerad", "Företagskund", MessageBoxButton.OK, MessageBoxImage.Information);
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

        #region BOKNING

        private ObservableCollection<MasterBokning> masterbokningar = null!;
        public ObservableCollection<MasterBokning> Masterbokningar { get => masterbokningar; set { masterbokningar = value; OnPropertyChanged(); } }

        private MasterBokning valdBokningSelectedItem = null!;
        public MasterBokning ValdBokningSelectedItem
        {
            get => valdBokningSelectedItem;
            set
            {
                valdBokningSelectedItem = value; OnPropertyChanged();
            }
        }
        private int valdBokningSelectedIndex;
        public int ValdBokningSelectedIndex { get => valdBokningSelectedIndex; set { valdBokningSelectedIndex = value; OnPropertyChanged(); } }

        private Logi valdLogiSelectedItem = null!;
        public Logi ValdLogiSelectedItem
        {
            get => valdLogiSelectedItem;
            set
            {
                valdLogiSelectedItem = value; OnPropertyChanged();

            }
        }

        private int valdLogiSelectedIndex;
        public int ValdLogiSelectedIndex { get => valdLogiSelectedIndex; set { valdLogiSelectedIndex = value; OnPropertyChanged(); } }

        private ICommand sparaBokningCommand = null!;
        public ICommand SparaBokningCommand => sparaBokningCommand ??= sparaBokningCommand = new RelayCommand(() =>
        {

            bokningsKontroller.SparaÄndring(ValdBokningSelectedItem);
            MessageBox.Show($"Avbeställningsskyddet är tillagt", "Bokning", MessageBoxButton.OK, MessageBoxImage.Exclamation);

        });
        private ICommand taBortBokningCommand = null!;
        public ICommand TaBortBokningCommand => taBortBokningCommand ??= taBortBokningCommand = new RelayCommand(() =>
        {
            if (ValdBokningSelectedItem != null && valdLogiSelectedItem == null)
            {
                bokningsKontroller.TaBortMasterBokning(ValdBokningSelectedItem);
                MessageBox.Show($"Bokning med bokningsNr: {valdBokningSelectedItem.BokningsNr} är borttagen", "Bokning", MessageBoxButton.OK, MessageBoxImage.Information);
                //möjlig fullösning
                Masterbokningar = new ObservableCollection<MasterBokning>(bokningsKontroller.HämtaKundsMasterbokningar(Kundnummer));


            }
            else if (ValdBokningSelectedItem != null && ValdLogiSelectedItem != null)
            {

                bokningsKontroller.TaBortLogiFrånBokning(ValdBokningSelectedItem, ValdLogiSelectedItem);
                MessageBox.Show($"Logi: {valdLogiSelectedItem.LogiTyp} är borttagen", "Bokning", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show($"Selectera bokning eller logi för att kunna ta bort", "Bokning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }




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

            Masterbokningar = new ObservableCollection<MasterBokning>(bokningsKontroller.HämtaKundsMasterbokningar(Kundnummer));
            if (Masterbokningar != null && Privatkund == null && Företagskund == null)
            {
                Masterbokningar = Masterbokningar;
            }

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
            else if (Företagskund == null && Masterbokningar == null && Privatkund == null)
            {

                NollaFöretagsKundInformation();
                NollaPrivatkundInformation();
                NollaBokningInformation();
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
        public void NollaBokningInformation()
        {
            Masterbokningar = null;
        }





    }
}
