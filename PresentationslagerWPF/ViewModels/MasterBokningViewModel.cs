using Affärslager;
using Affärslager.KundKontroller;
using Entiteter.Personer;
using Entiteter.Prislistor;
using Entiteter.Tjänster;
using PresentationslagerWPF.Commands;
using PresentationslagerWPF.Models;
using PresentationslagerWPF.Services;
using PresentationslagerWPF.Stores;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace PresentationslagerWPF.ViewModels
{
    public class MasterBokningViewModel : ObservableObject
    {
        #region Kontrollers
        BokningsKontroller bokningsKontroller = new BokningsKontroller();
        PrisKontroller prisKontroller = new PrisKontroller();
        PrivatkundKontroller privatkundKontroller = new PrivatkundKontroller();
        FöretagskundKontroller företagskundKontroller = new FöretagskundKontroller();
        KonferensKontroller konferensKontroller = new KonferensKontroller();
        #endregion



        #region On property change

        private DateTime starttid = DateTime.Now;
        public DateTime Starttid { get => starttid; set { starttid = value; OnPropertyChanged(); } }

        private DateTime sluttid = DateTime.Now;
        public DateTime Sluttid { get => sluttid; set { sluttid = value; OnPropertyChanged(); } }

        private double? antalSovplatser;
        public double? AntalSovplatser { get => antalSovplatser; set { antalSovplatser = value; OnPropertyChanged(); } }

        private double? totalKostnad;
        public double? TotalKostnad { get => totalKostnad; set { totalKostnad = value; OnPropertyChanged(); } }

        private string inputAdress;
        public string InputAdress
        {
            get { return inputAdress; }
            set { inputAdress = value; OnPropertyChanged(); }
        }

        private string inputPostnummer;
        public string InputPostnummer
        {
            get { return inputPostnummer; }
            set { inputPostnummer = value; OnPropertyChanged(); }
        }


        private string inputOrt = "HallåEller";
        public string InputOrt
        {
            get { return inputOrt; }
            set { inputOrt = value; OnPropertyChanged(); }

        }

        private string inputTelefonnummer;
        public string InputTelefonnummer
        {
            get { return inputTelefonnummer; }
            set { inputTelefonnummer = value; OnPropertyChanged(); }
        }


        private string inputMailAdress;
        public string InputMailAdress
        {
            get { return inputMailAdress; }
            set { inputMailAdress = value; OnPropertyChanged(); }
        }

        private string inputFörnamn;
        public string InputFörnamn
        {
            get { return inputFörnamn; }
            set { inputFörnamn = value; OnPropertyChanged(); }
        }


        private string inputEfternamn;
        public string InputEfternamn
        {
            get { return inputEfternamn; }
            set { inputEfternamn = value; OnPropertyChanged(); }
        }

        private string kundnummer;
        public string Kundnummer { get => kundnummer; set { kundnummer = value; OnPropertyChanged(); } }

        private Privatkund privatkund = null!;
        public Privatkund Privatkund { get => privatkund; set { privatkund = value; OnPropertyChanged(); } }

        private MasterBokning masterbokning = null!;
        public MasterBokning MasterBokning { get => masterbokning; set { masterbokning = value; OnPropertyChanged(); } }

        private Visibility fsynlighet = Visibility.Collapsed;
        public Visibility FSynlighet
        {

            get { return fsynlighet; }
            set { fsynlighet = value; OnPropertyChanged(); }

        }
        private Visibility ksynlighet;
        public Visibility KSynlighet
        {

            get { return ksynlighet; }
            set { ksynlighet = value; OnPropertyChanged(); }

        }



        //private bool synligBool = false;
        //public bool SynligBool
        //{
        //    get { return synligBool; }
        //    set
        //    {
        //        if (value != synligBool)
        //        {
        //            synligBool = value;
        //            OnPropertyChanged("SynligBool");
        //        }
        //    }
        //}
        // Tillhörande i Xaml Visibility="{Bool}", Converter={StaticResource BooleanToVisibilityConverter}}" 


        private Företagskund företagskund = null!;
        public Företagskund Företagskund { get => företagskund; set { företagskund = value; OnPropertyChanged(); } }

        private PrislistaLogi prislistaLogi = null!;
        public PrislistaLogi PrislistaLogi { get => prislistaLogi; set { prislistaLogi = value; OnPropertyChanged(); } }

        private double totalPris;
        public double TotalPris { get => totalPris; set { totalPris = value; OnPropertyChanged(); } }

        private double totalPrisRabatt;
        public double TotalPrisRabatt { get => totalPrisRabatt; set { totalPrisRabatt = value; OnPropertyChanged(); } }

        private double totalPrisRabatt2;
        public double TotalPrisRabatt2 { get => totalPrisRabatt2; set { totalPrisRabatt2 = value; OnPropertyChanged(); } }


        private Konferenslokal valdKonferensItem = null!;
        public Konferenslokal ValdKonferensItem
        {  get => valdKonferensItem;
            set 
            { valdKonferensItem = value;
                OnPropertyChanged();
            }
        }


        private int tillgängligLogiSelectedIndex;
        public int TillgängligLogiSelectedIndex { get => tillgängligLogiSelectedIndex; set { tillgängligLogiSelectedIndex = value; OnPropertyChanged(); } }

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

        private bool isNotModified = true;
        public bool IsNotModified { get { return isNotModified; } set { isNotModified = value; OnPropertyChanged(); } }

        private bool avbeställningsskydd = true;
        public bool Avbeställningsskydd { get { return avbeställningsskydd; } set { avbeställningsskydd = value; OnPropertyChanged(); } }
        #endregion


        #region FöretagsKund + DisplayKundPanel

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
        #endregion


        #region Observable Collections 

        private ObservableCollection<Konferenslokal> tillgängligaKonferensRum = null!;
        public ObservableCollection<Konferenslokal> TillgängligaKonferensRum { get => tillgängligaKonferensRum; set { tillgängligaKonferensRum = value; OnPropertyChanged(); } }

        private ObservableCollection<Logi> tillgängligLogi = null!;
        public ObservableCollection<Logi> TillgängligLogi { get => tillgängligLogi; set { tillgängligLogi = value; OnPropertyChanged(); } }

        private ObservableCollection<Kund> kund = null!;
        public ObservableCollection<Kund> Kund { get => kund; set { kund = value; OnPropertyChanged(); } }

        private ObservableCollection<Logi> valdLogi = null!;
        public ObservableCollection<Logi> ValdLogi
        {
            get => valdLogi;
            set
            {
                valdLogi = value; OnPropertyChanged();

            }
        }


        //Användarnamn för ANVÄNDARE
        private Användare användare = null!;
        public Användare Användare
        {
            get => användare;
            set
            {
                användare = value; OnPropertyChanged();

            }
        }
        #endregion


        public MasterBokningViewModel() { }


        #region Navigation
        //**** NAVIGATION *******//
        public MasterBokningViewModel(NavigationStore navigationStore, Användare användare)
        {
            NavigateLoggaUtCommand = new NavigateCommand<LoggaInViewModel>(new NavigationService<LoggaInViewModel>(navigationStore, () => new LoggaInViewModel(navigationStore)));
            TillbakaCommand = new NavigateCommand<HuvudMenyViewModel>(new NavigationService<HuvudMenyViewModel>(navigationStore, () => new HuvudMenyViewModel(navigationStore, användare)));
            UppdateraCommand = new NavigateCommand<MasterBokningViewModel>(new NavigationService<MasterBokningViewModel>(navigationStore, () => new MasterBokningViewModel(navigationStore, användare)));
            Användare = användare;
        }

        private ICommand exitCommand = null!;
        public ICommand ExitCommand =>
        exitCommand ??= exitCommand = new RelayCommand(() => App.Current.Shutdown());

        public ICommand NavigateLoggaUtCommand { get; }
        public ICommand TillbakaCommand { get; }
        public ICommand UppdateraCommand { get; }

        #endregion



        #region Icommands


        private ICommand läggTillKonferens = null!;
        public ICommand LäggTillKonferens => läggTillKonferens ??= läggTillKonferens = new RelayCommand(() =>
        {
            

        });

        private ICommand hämtaBokningCommand = null!;
        public ICommand HämtaBokningCommand => hämtaBokningCommand ??= hämtaBokningCommand = new RelayCommand(() =>
        {
            TillgängligaKonferensRum = new ObservableCollection<Konferenslokal>(konferensKontroller.HämtaTillgängligKonferens(Starttid, Sluttid));
            TillgängligLogi = new ObservableCollection<Logi>(bokningsKontroller.HämtaTillgängligLogi(Starttid, Sluttid));
            ValdLogi = new ObservableCollection<Logi>();
        });

        private ICommand läggTillCommand = null!;
        public ICommand LäggTillCommand => läggTillCommand ??= läggTillCommand = new RelayCommand(() =>
        {
            if (TillgängligLogiSelectedItem != null)
            {
                double resKostnad = 0;
                Logi logi = TillgängligLogiSelectedItem;
                if (Privatkund != null)
                {
                    TotalPrisRabatt2 = prisKontroller.HämtaRabatt(TotalPris, Privatkund);
                    //TotalPrisRabatt2 = prisKontroller.HämtaRabattFöretagskund(TotalPris, Företagskund);
                }

                if (TotalPrisRabatt == 0)
                {
                    TotalPrisRabatt = resKostnad + TotalPrisRabatt2;
                }
                else
                {
                    TotalPrisRabatt = TotalPrisRabatt + TotalPrisRabatt2;
                }
                ValdLogi.Add(logi);
                TillgängligLogi.Remove(logi);
                //Bäddar totalt
                int resBädd = 0;
                if (ValdLogi != null)
                {
                    for (var i = 0; i < ValdLogi.Count; i++)
                    {
                        resBädd += ValdLogi[i].Bäddar;
                    }
                }

                //Kostnad totalt
                if (TotalKostnad == null)
                {
                    TotalKostnad = resKostnad + TotalPris;
                }
                else
                {
                    TotalKostnad = TotalKostnad + TotalPris;
                }

                AntalSovplatser = resBädd;
            }
        });

        private ICommand sökKund = null!;
        public ICommand SökKund => sökKund ??= sökKund = new RelayCommand(() =>
        {
            
            Privatkund = privatkundKontroller.SökPrivatkund(Kundnummer);
            if (Privatkund != null)
            {
                FSynlighet = Visibility.Collapsed;
                KSynlighet = Visibility.Visible;
                InputAdress = Privatkund.Adress;
                InputPostnummer = Privatkund.Postnummer;
                InputOrt = Privatkund.Ort;
                InputTelefonnummer = Privatkund.Telefonnummer;
                InputMailAdress = Privatkund.MailAdress;
                Kundnummer = Privatkund.Personnummer;
                InputFörnamn = Privatkund.Förnamn;
                InputEfternamn = Privatkund.Efternamn;
            }

            Företagskund = företagskundKontroller.SökFöretagskund(Kundnummer);
            if (företagskund != null)
            {
                KSynlighet = Visibility.Collapsed;
                FSynlighet = Visibility.Visible;
            }



        });


        private ICommand spara = null!;
        public ICommand Spara => spara ??= spara = new RelayCommand(() =>
        {
            //Lös bättre lösning för IF och nullning

            if (Privatkund == null && Företagskund == null && ValdLogi != null)
            {
                Privatkund = privatkundKontroller.RegistreraPrivatKund(InputAdress, InputPostnummer, InputOrt, InputTelefonnummer, InputMailAdress, Kundnummer, InputFörnamn, InputEfternamn);
                MasterBokning = bokningsKontroller.SkapaMasterbokningPrivatkund(Avbeställningsskydd, Starttid, Sluttid, ValdLogi, Privatkund, Användare);
                PDF.CreatePDF.RunP(Privatkund, MasterBokning, TotalKostnad, TotalPrisRabatt, ValdLogi);
                MessageBox.Show("Privatkund registrerad", "Bokning", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            if (Privatkund != null && ValdLogi != null)
            {
                MasterBokning = bokningsKontroller.SkapaMasterbokningPrivatkund(Avbeställningsskydd, Starttid, Sluttid, ValdLogi, Privatkund, Användare);
                MessageBox.Show("Bokning skapad", "Bokning", MessageBoxButton.OK, MessageBoxImage.Information);

                PDF.CreatePDF.RunP(Privatkund, MasterBokning, TotalKostnad, TotalPrisRabatt, ValdLogi);
            }
            if (ValdLogi == null)
            {
                MessageBox.Show("Bokning måste innehålla logi", "Välj logi", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            if (Företagskund != null)
            {
                MasterBokning = bokningsKontroller.SkapaMasterbokningFöretagskund(Avbeställningsskydd, Starttid, Sluttid, ValdLogi, Företagskund, Användare);
                MessageBox.Show("Bokning skapad", "Bokning", MessageBoxButton.OK, MessageBoxImage.Information);

                PDF.CreatePDF.RunF(Företagskund, MasterBokning, TotalKostnad, TotalPrisRabatt, ValdLogi);
            }


            bokningsKontroller.SparaÄndring(MasterBokning);
            if (ValdLogi != null)
            {
                valdLogi.Clear();
            }

            //InputAdress = null;
            //InputPostnummer = null;
            //InputOrt = null;
            //InputTelefonnummer = null;
            //InputMailAdress = null;
            //Kundnummer = null;
            //InputFörnamn = null;
            //InputEfternamn = null;
            //AntalSovplatser = null;
            //TotalKostnad = null;
            //ValdLogi = null;
            //TotalPris = 0;
            //Privatkund = null;
            //TillgängligLogi = null;
            //Starttid = DateTime.Now;
            //Sluttid = DateTime.Now;
            //TotalPrisRabatt = 0;

        });

        private ICommand taBortCommand = null!;
        public ICommand TaBortCommand => taBortCommand ??= taBortCommand = new RelayCommand(() =>
        {
            if (valdLogiSelectedItem != null)
            {
                Logi tabortLogi = ValdLogiSelectedItem;
                //Ta bort kostnad
                if (tabortLogi != null)
                {
                    TotalPris = prisKontroller.BeräknaPrisLogi(tabortLogi.Typen, Starttid, Sluttid);
                    TotalPrisRabatt2 = prisKontroller.HämtaRabatt(TotalPris, Privatkund);
                    TotalPrisRabatt2 = prisKontroller.HämtaRabattFöretagskund(TotalPris, Företagskund);
                }
                TillgängligLogi.Add(tabortLogi);
                ValdLogi.Remove(tabortLogi);
                //Ta bort bäddar totalt
                int res = 0;
                if (ValdLogi != null)
                {
                    //for (var i = 0; i < ValdLogi.Count; i++)
                    //{
                    //    res = ValdLogi[i].Bäddar;
                    //}
                    res = tabortLogi.Bäddar;
                }
                if (TotalPrisRabatt != 0)
                {
                    TotalPrisRabatt = TotalPrisRabatt - TotalPrisRabatt2;
                }

                TotalKostnad = TotalKostnad - TotalPris;
                AntalSovplatser = AntalSovplatser - res;
            }
        });


        #endregion


    }
}
