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

        public MasterBokningViewModel() { }
        #endregion


        private double rabattSats;
        public double RabattSats
        {
            get => rabattSats; set
            {
                rabattSats = value;
                OnPropertyChanged();
            }
        }

        public void StoppaSparaKnappen()
        {
            if ((Privatkund == null || Företagskund == null) &&
                    (ValdLogi != null && ValdLogi.Count >= 1) &&
                    !string.IsNullOrEmpty(InputAdress) &&
                    !string.IsNullOrEmpty(InputPostnummer) &&
                    !string.IsNullOrEmpty(InputOrt) &&
                    !string.IsNullOrEmpty(InputTelefonnummer) &&
                    !string.IsNullOrEmpty(InputMailAdress) &&
                    !string.IsNullOrEmpty(Kundnummer) &&
                    !string.IsNullOrEmpty(InputFörnamn) &&
                    !string.IsNullOrEmpty(InputEfternamn))
            {
                KnappAktiv = true;
            }
            else { KnappAktiv = false; }
        }

        #region Properties Logi, kund (Sprint1)

        private DateTime starttid = DateTime.Now;
        public DateTime Starttid { get => starttid; set 
            { 
                starttid = value; 
                OnPropertyChanged();
                if (Starttid >= DateTime.Now.Date && Sluttid > Starttid)
                {
                    IsEnabledSökDatum = true;
                }
                else if (Starttid < DateTime.Now.Date)
                {
                    IsEnabledSökDatum = false;
                    MessageBox.Show("Datum bakåt i tiden går inte att boka", "Bokning", MessageBoxButton.OK);
                    //Starttid = DateTime.Now;
                }
            } 
        }

        private DateTime sluttid = DateTime.Now;
        public DateTime Sluttid { get => sluttid; set 
            { 
                sluttid = value; 
                OnPropertyChanged();
                if (Sluttid > DateTime.Now.Date)
                {
                    IsEnabledSökDatum = true;
                }
                if (Sluttid < Starttid)
                {
                    IsEnabledSökDatum = false;
                    MessageBox.Show("Utcheckning får inte vara innan ankomst", "Bokning", MessageBoxButton.OK);
                }
                if (Starttid.Date == Sluttid.Date)
                {
                    IsEnabledSökDatum = false;
                    MessageBox.Show("Utcheckning får inte vara på samma dag som ankomst", "Bokning", MessageBoxButton.OK);
                }
                else if (Sluttid < DateTime.Now.Date)
                {
                    IsEnabledSökDatum = false;
                    MessageBox.Show("Datum bakåt i tiden går inte att boka", "Bokning", MessageBoxButton.OK);
                    //Sluttid = DateTime.Now;
                }
            } 
        }

        private bool isEnabledSökDatum = false!;
        public bool IsEnabledSökDatum { get => isEnabledSökDatum; set { isEnabledSökDatum = value; OnPropertyChanged(); } }

        private double? antalSovplatser;
        public double? AntalSovplatser { get => antalSovplatser; set { antalSovplatser = value; OnPropertyChanged(); } }

        private double? totalKostnad;
        public double? TotalKostnad { get => totalKostnad; set { totalKostnad = value; OnPropertyChanged(); } }

        private string inputAdress;
        public string InputAdress
        {
            get { return inputAdress; }
            set
            {
                inputAdress = value; OnPropertyChanged();
                StoppaSparaKnappen();
            }
        }

        private string inputPostnummer;
        public string InputPostnummer
        {
            get { return inputPostnummer; }
            set
            {
                inputPostnummer = value; OnPropertyChanged();
                StoppaSparaKnappen();
            }
        }


        private string inputOrt;
        public string InputOrt
        {
            get { return inputOrt; }
            set
            {
                inputOrt = value; OnPropertyChanged();
                StoppaSparaKnappen();
            }

        }

        private string inputTelefonnummer;
        public string InputTelefonnummer
        {
            get { return inputTelefonnummer; }
            set
            {
                inputTelefonnummer = value; OnPropertyChanged();
                StoppaSparaKnappen();
            }
        }


        private string inputMailAdress;
        public string InputMailAdress
        {
            get { return inputMailAdress; }
            set
            {
                inputMailAdress = value; OnPropertyChanged();
                StoppaSparaKnappen();
            }
        }

        private string inputFörnamn;
        public string InputFörnamn
        {
            get { return inputFörnamn; }
            set
            {
                inputFörnamn = value; OnPropertyChanged();
                StoppaSparaKnappen();
            }
        }


        private string inputEfternamn;
        public string InputEfternamn
        {
            get { return inputEfternamn; }
            set
            {
                inputEfternamn = value; OnPropertyChanged();
                StoppaSparaKnappen();
            }
        }

        private string kundnummer;
        public string Kundnummer
        {
            get => kundnummer; set
            {
                kundnummer = value; OnPropertyChanged();

                StoppaSparaKnappen();

            }
        }

        private Privatkund privatkund = null!;
        public Privatkund Privatkund
        {
            get => privatkund; set
            {
                privatkund = value; OnPropertyChanged();

            }
        }

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
        public Företagskund Företagskund
        {
            get => företagskund; set
            {
                företagskund = value; OnPropertyChanged();


            }
        }

        private double kök;
        public double Kök { get => kök; set { kök = value; OnPropertyChanged(); } }

        private PrislistaLogi prislistaLogi = null!;
        public PrislistaLogi PrislistaLogi { get => prislistaLogi; set { prislistaLogi = value; OnPropertyChanged(); } }

        private double totalPris;
        public double TotalPris { get => totalPris; set { totalPris = value; OnPropertyChanged(); } }

        private double totalPrisRabatt;
        public double TotalPrisRabatt { get => totalPrisRabatt; set { totalPrisRabatt = value; OnPropertyChanged(); } }

        private double totalPrisRabatt2;
        public double TotalPrisRabatt2 { get => totalPrisRabatt2; set { totalPrisRabatt2 = value; OnPropertyChanged(); } }

        private Logi tillgängligLogiSelectedItem = null!;
        public Logi TillgängligLogiSelectedItem
        {
            get => tillgängligLogiSelectedItem;
            set
            {
                tillgängligLogiSelectedItem = value; OnPropertyChanged();
                if (tillgängligLogiSelectedItem != null)
                {
                    TotalPris = prisKontroller.BeräknaPrisLogi(TillgängligLogiSelectedItem.Typen, Starttid, Sluttid);
                }
            }
        }

        private int tillgänligLogiSelectedIndex;
        public int TillgänligLogiSelectedIndex { get => tillgänligLogiSelectedIndex; set { tillgänligLogiSelectedIndex = value; OnPropertyChanged(); } }

        private Logi valdLogiSelectedItem = null!;
        public Logi ValdLogiSelectedItem
        {
            get => valdLogiSelectedItem;
            set
            {
                valdLogiSelectedItem = value; OnPropertyChanged();

            }
        }
        private bool knappAktiv = false!;
        public bool KnappAktiv { get => knappAktiv; set { knappAktiv = value; OnPropertyChanged(); } }

        private int valdLogiSelectedIndex;
        public int ValdLogiSelectedIndex { get => valdLogiSelectedIndex; set { valdLogiSelectedIndex = value; OnPropertyChanged(); } }

        private bool isNotModified = true;
        public bool IsNotModified { get { return isNotModified; } set { isNotModified = value; OnPropertyChanged(); } }

        private bool avbeställningsskydd;

        public bool Avbeställningsskydd
        {
            get { return avbeställningsskydd; }
            set
            {
                if (avbeställningsskydd != value)
                {
                    avbeställningsskydd = value;
                    OnPropertyChanged(nameof(Avbeställningsskydd));
                }
            }
        }

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


        #region Observable collections + Properties - Konferens - Sprint 2
        private ObservableCollection<Konferenslokal> tillgängligaKonferensRum = null!;
        public ObservableCollection<Konferenslokal> TillgängligaKonferensRum { get => tillgängligaKonferensRum; set { tillgängligaKonferensRum = value; OnPropertyChanged(); } }


        private ObservableCollection<Konferenslokal> valdaKonferensRum = null!;
        public ObservableCollection<Konferenslokal> ValdaKonferensRum { get => valdaKonferensRum; set { valdaKonferensRum = value; OnPropertyChanged(); } }



        private int tillgängligKonferensIndex;
        public int TillgängligKonferensIndex { get { return tillgängligKonferensIndex; } set { tillgängligKonferensIndex = value; OnPropertyChanged(); } }

        private int valdKonferensIndex;
        public int ValdKonferensIndex { get { return valdKonferensIndex; } set { valdKonferensIndex = value; OnPropertyChanged(); } }


        private Konferenslokal valdKonferensItem = null!;
        public Konferenslokal ValdKonferensItem
        { get => valdKonferensItem; set { valdKonferensItem = value; OnPropertyChanged(); } }

        private Visibility gömAllt = Visibility.Collapsed;
        public Visibility GömAllt
        {

            get { return gömAllt; }
            set { gömAllt = value; OnPropertyChanged(); }

        }
        private Visibility seKonferens;
        public Visibility SeKonferens
        {

            get { return seKonferens; }
            set { seKonferens = value; OnPropertyChanged(); }

        }



        #endregion

        #region Observable Collections Logi/Kund - Sprint 1

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
                StoppaSparaKnappen();
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


        #region ICommands - Konferens - Sprint 2


        private ICommand läggTillKonferens = null!;
        public ICommand LäggTillKonferens => läggTillKonferens ??= läggTillKonferens = new RelayCommand(() =>
        {
            Konferenslokal kRum = ValdKonferensItem;
            if (ValdKonferensItem != null)
            {

                ValdaKonferensRum.Add(kRum);
                TillgängligaKonferensRum.Remove(kRum);

            }
            if (Privatkund != null && ValdaKonferensRum != null)
            {
                KnappAktiv = true;
            }
            if (Företagskund != null && ValdaKonferensRum != null)
            {
                KnappAktiv = true;
            }
        });

        private ICommand syngörKonferensKommand = null!;
        public ICommand SyngörKonferensKommand => syngörKonferensKommand ??= syngörKonferensKommand = new RelayCommand(() =>
        {
            TillgängligaKonferensRum = new ObservableCollection<Konferenslokal>(konferensKontroller.HämtaTillgängligKonferens(Starttid, Sluttid));
            ValdaKonferensRum = new ObservableCollection<Konferenslokal>();
            SeKonferens = Visibility.Collapsed;
            GömAllt = Visibility.Visible;

        });

        private ICommand gömKommand = null!;
        public ICommand GömKommand => gömKommand ??= gömKommand = new RelayCommand(() =>
        {
            TillgängligaKonferensRum = new ObservableCollection<Konferenslokal>(konferensKontroller.HämtaTillgängligKonferens(Starttid, Sluttid));
            ValdaKonferensRum = new ObservableCollection<Konferenslokal>();
            SeKonferens = Visibility.Visible;
            GömAllt = Visibility.Collapsed;

        });


        private ICommand taBortKonferens = null!;
        public ICommand TaBortKonferens => taBortKonferens ??= taBortKonferens = new RelayCommand(() =>
        {
            Konferenslokal konferensTabort = ValdKonferensItem;
            if (valdaKonferensRum != null)
            {
                ValdaKonferensRum.Remove(konferensTabort);
                TillgängligaKonferensRum.Add(konferensTabort);
            }
        });


        #endregion

        #region Icommands - Skapa bokning - Sprint 1 + Inläsning av nya listor(Tillgängligakonferensrum)
        private ICommand hämtaBokningCommand = null!;
        public ICommand HämtaBokningCommand => hämtaBokningCommand ??= hämtaBokningCommand = new RelayCommand(() =>
        {
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
                    RabattSats = prisKontroller.HämtaRabattSatsPrivat(Privatkund);
                    //TotalPrisRabatt2 = prisKontroller.HämtaRabattFöretagskund(TotalPris, Företagskund);
                }
                if (Företagskund != null)
                {
                    TotalPrisRabatt2 = prisKontroller.HämtaRabattFöretagskund(TotalPris, Företagskund);
                    RabattSats = Företagskund.RabattSats;
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
            if (ValdLogi != null && Privatkund != null)
            {
                KnappAktiv = true;
            }
            if (ValdLogi != null && Företagskund != null)
            {
                KnappAktiv = true;
            }
            if (Privatkund == null && Företagskund == null && ValdLogi != null && InputAdress != string.Empty && InputPostnummer != null && InputOrt != string.Empty && InputTelefonnummer != string.Empty && InputMailAdress != string.Empty && Kundnummer != string.Empty && InputFörnamn != string.Empty && InputEfternamn != string.Empty)
            {
                KnappAktiv = true;
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

            if (Företagskund != null)
            {

                KSynlighet = Visibility.Collapsed;
                FSynlighet = Visibility.Visible;
            }

            if ((Privatkund != null || Företagskund != null) &&
            (ValdLogi != null && ValdLogi.Count >= 1) &&
            !string.IsNullOrEmpty(InputAdress) &&
            !string.IsNullOrEmpty(InputPostnummer) &&
            !string.IsNullOrEmpty(InputOrt) &&
            !string.IsNullOrEmpty(InputTelefonnummer) &&
            !string.IsNullOrEmpty(InputMailAdress) &&
            !string.IsNullOrEmpty(Kundnummer) &&
            !string.IsNullOrEmpty(InputFörnamn) &&
            !string.IsNullOrEmpty(InputEfternamn))
            {
                KnappAktiv = true;
            }

            if ((privatkundKontroller.SökPrivatkund(Kundnummer) == null) && (företagskundKontroller.SökFöretagskund(Kundnummer) == null))
            {
                MessageBox.Show("Kund med organisationsnummer/personummer: " + " '" + Kundnummer + "' " +
                    "finns inte registrerad.", "Bokning");
            }





        });


        private ICommand spara = null!;
        public ICommand Spara => spara ??= spara = new RelayCommand(() =>
        {
            //Lös bättre lösning för IF och nullning
            if (Privatkund != null && ValdLogi != null)
            {
                MasterBokning = bokningsKontroller.SkapaMasterbokningPrivatkund(Avbeställningsskydd, Starttid, Sluttid, ValdLogi, Privatkund, Användare);
                MessageBox.Show("Bokning skapad", "Bokning", MessageBoxButton.OK, MessageBoxImage.Information);

                PDF.CreatePDF.SkapaBokningsbekräftelsePrivat(Privatkund, MasterBokning, TotalKostnad, TotalPrisRabatt, ValdLogi);

            }

            if (Privatkund == null && Företagskund == null && ValdLogi != null && InputAdress != string.Empty && InputPostnummer != null && InputOrt != string.Empty && InputTelefonnummer != string.Empty && InputMailAdress != string.Empty && Kundnummer != string.Empty && InputFörnamn != string.Empty && InputEfternamn != string.Empty)
            {

                Privatkund = privatkundKontroller.RegistreraPrivatKund(Kundnummer, InputPostnummer, InputOrt, InputTelefonnummer, InputMailAdress, InputAdress, InputFörnamn, InputEfternamn);
                MasterBokning = bokningsKontroller.SkapaMasterbokningPrivatkund(Avbeställningsskydd, Starttid, Sluttid, ValdLogi, Privatkund, Användare);
                PDF.CreatePDF.SkapaBokningsbekräftelsePrivat(Privatkund, MasterBokning, TotalKostnad, TotalPrisRabatt, ValdLogi);
                MessageBox.Show("Privatkund registrerad", "Bokning", MessageBoxButton.OK, MessageBoxImage.Information);

            }

            if (ValdLogi == null)
            {
                MessageBox.Show("Bokning måste innehålla logi", "Välj logi", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            if (Företagskund != null && ValdLogi != null)
            {
                MasterBokning = bokningsKontroller.SkapaMasterbokningFöretagskund(Avbeställningsskydd, Starttid, Sluttid, ValdLogi, Företagskund, Användare);
                MessageBox.Show("Bokning skapad", "Bokning", MessageBoxButton.OK, MessageBoxImage.Information);

                PDF.CreatePDF.SkapaBokningsbekräftelseFöretag(Företagskund, MasterBokning, TotalKostnad, TotalPrisRabatt, ValdLogi);
            }

            bokningsKontroller.SparaÄndring(MasterBokning);
            if (ValdLogi != null)
            {
                valdLogi.Clear();
            }
            if (ValdaKonferensRum != null)
            {
                bokningsKontroller.KonferensTillMasterBokning(ValdaKonferensRum, MasterBokning);
            }
            KnappAktiv = false;
        });

        private ICommand taBortCommand = null!;
        public ICommand TaBortCommand => taBortCommand ??= taBortCommand = new RelayCommand(() =>
        {
            if (valdLogiSelectedItem != null)
            {
                Logi tabortLogi = ValdLogiSelectedItem;
                //Ta bort kostnad
                if (tabortLogi != null && Privatkund != null)
                {
                    TotalPris = prisKontroller.BeräknaPrisLogi(tabortLogi.Typen, Starttid, Sluttid);
                    TotalPrisRabatt2 = prisKontroller.HämtaRabatt(TotalPris, Privatkund);
                }
                if (tabortLogi != null && Företagskund != null)
                {
                    TotalPris = prisKontroller.BeräknaPrisLogi(tabortLogi.Typen, Starttid, Sluttid);
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
                if (ValdLogi.Count == 0)
                {
                    KnappAktiv = false;
                    RabattSats = 0;
                    TotalPrisRabatt = 0;
                }

                TotalKostnad = TotalKostnad - TotalPris;
                AntalSovplatser = AntalSovplatser - res;
            }
        });


        #endregion


    }
}
