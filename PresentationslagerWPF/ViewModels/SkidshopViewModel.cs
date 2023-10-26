using Affärslager;
using Affärslager.KundKontroller;
using Entiteter.Personer;
using Entiteter.Tjänster;
using Microsoft.VisualBasic;
using PDF;
using PresentationslagerWPF.Commands;
using PresentationslagerWPF.DataDisplay;
using PresentationslagerWPF.Models;
using PresentationslagerWPF.Services;
using PresentationslagerWPF.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;


namespace PresentationslagerWPF.ViewModels
{

    public class SkidshopViewModel : ObservableObject
    {

        UtrustningsKontroller utrustningsKontroller = new UtrustningsKontroller();
        LektionsKontroller lektionsKontroller = new LektionsKontroller();
        PrisKontroller priskontroller = new PrisKontroller();
        PrivatkundKontroller privatkundKontroller = new PrivatkundKontroller();
        FöretagskundKontroller företagskundKontroller = new FöretagskundKontroller();
        BokningsKontroller bokningsKontroller = new BokningsKontroller();

        #region Observable Collection utrustning


        private ObservableCollection<DisplayUtrustning> totalDisplayUtrustning = null!;
        public ObservableCollection<DisplayUtrustning> TotalDisplayUtrustning
        {
            get => totalDisplayUtrustning; set
            {
                totalDisplayUtrustning = value; OnPropertyChanged();

            }
        }

        private ObservableCollection<Utrustning> allaUtrustningar = null!;
        public ObservableCollection<Utrustning> AllaUtrustningar
        {
            get => allaUtrustningar; set
            {
                allaUtrustningar = value; OnPropertyChanged();
            }
        }

        private ObservableCollection<Utrustning> valdUtrustningTillBokning = null!;
        public ObservableCollection<Utrustning> ValdUtrustningTillBokning
        {
            get => valdUtrustningTillBokning; set
            {
                valdUtrustningTillBokning = value; OnPropertyChanged();
            }
        }
        private ObservableCollection<Utrustning> typAlpin = null!;
        public ObservableCollection<Utrustning> TypAlpin
        {
            get => typAlpin; set
            {
                typAlpin = value; OnPropertyChanged();
            }
        }

        private ObservableCollection<Utrustning> typSnowboard = null!;
        public ObservableCollection<Utrustning> TypSnowboard
        {
            get => typSnowboard; set
            {
                typSnowboard = value; OnPropertyChanged();

            }
        }
        private ObservableCollection<Utrustning> typLängd = null!;
        public ObservableCollection<Utrustning> TypLängd
        {
            get => typLängd; set
            {
                typLängd = value; OnPropertyChanged();

            }
        }
        private ObservableCollection<Utrustning> typSkoter = null!;
        public ObservableCollection<Utrustning> TypSkoter
        {
            get => typSkoter; set
            {
                typSkoter = value; OnPropertyChanged();

            }
        }
        private ObservableCollection<Utrustning> typHjälm = null!;
        public ObservableCollection<Utrustning> TypHjälm
        {
            get => typHjälm; set
            {
                typHjälm = value; OnPropertyChanged();
            }
        }
        private ObservableCollection<Utrustning> typPaket = null!;
        public ObservableCollection<Utrustning> TypPaket
        {
            get => typPaket; set
            {
                typPaket = value; OnPropertyChanged();
            }
        }

        private ObservableCollection<MasterBokning> masterbokningar = null!;
        public ObservableCollection<MasterBokning> Masterbokningar
        {
            get => masterbokningar;
            set
            {
                masterbokningar = value; OnPropertyChanged();
            }
        }




        #endregion



        #region IsEnabled - Utrustning

        private bool isEnabledUtrustning = false!;
        public bool IsEnabledUtrustning { get => isEnabledUtrustning; set { isEnabledUtrustning = value; OnPropertyChanged(); } }

        private bool isEnabledAntalAlpin = true!;
        public bool IsEnabledAntalAlpin { get => isEnabledAntalAlpin; set { isEnabledAntalAlpin = value; OnPropertyChanged(); } }

        private bool isEnabledAntalSnowboard = true!;
        public bool IsEnabledAntalSnowboard { get => isEnabledAntalSnowboard; set { isEnabledAntalSnowboard = value; OnPropertyChanged(); } }

        private bool isEnabledAntalLängd = true!;
        public bool IsEnabledAntalLängd { get => isEnabledAntalLängd; set { isEnabledAntalLängd = value; OnPropertyChanged(); } }

        private bool isEnabledAntalHjälm = true!;
        public bool IsEnabledAntalHjälm { get => isEnabledAntalHjälm; set { isEnabledAntalHjälm = value; OnPropertyChanged(); } }

        private bool isEnabledAntalSkoter = true!;
        public bool IsEnabledAntalSkoter { get => isEnabledAntalSkoter; set { isEnabledAntalSkoter = value; OnPropertyChanged(); } }

        private bool isEnabledAntalPaket = true!;
        public bool IsEnabledAntalPaket { get => isEnabledAntalPaket; set { isEnabledAntalPaket = value; OnPropertyChanged(); } }
        #endregion

        #region IsEnabledButton

        private bool isEnabledBtnAlpin = false!;
        public bool IsEnabledBtnAlpin
        {
            get => isEnabledBtnAlpin; set
            {
                isEnabledBtnAlpin = value; OnPropertyChanged();
            }
        }

        private bool isEnabledBtnSnowboard = false!;
        public bool IsEnabledBtnSnowboard { get => isEnabledBtnSnowboard; set { isEnabledBtnSnowboard = value; OnPropertyChanged(); } }


        private bool isEnabledBtnLängd = false!;
        public bool IsEnabledBtnLängd { get => isEnabledBtnLängd; set { isEnabledBtnLängd = value; OnPropertyChanged(); } }

        private bool isEnabledBtnHjälm = false!;
        public bool IsEnabledBtnHjälm { get => isEnabledBtnHjälm; set { isEnabledBtnHjälm = value; OnPropertyChanged(); } }

        private bool isEnabledBtnSkoter = false!;
        public bool IsEnabledBtnSkoter { get => isEnabledBtnSkoter; set { isEnabledBtnSkoter = value; OnPropertyChanged(); } }

        private bool knappAktiv = false!;
        public bool KnappAktiv { get => knappAktiv; set { knappAktiv = value; OnPropertyChanged(); } }

        #endregion


        private bool kreditIsChecked;

        public bool KreditIsChecked
        {
            get { return kreditIsChecked; }
            set
            {
                if (kreditIsChecked != value)
                {
                    kreditIsChecked = value;
                    OnPropertyChanged(nameof(KreditIsChecked));
                    StoppaKreditUtrustning();
                    }

                }
            }



        #region NAVIGATION
        //**** NAVIGATION *******//

        public SkidshopViewModel(NavigationStore navigationStore, Användare användare)
        {
            NavigateLoggaUtCommand = new NavigateCommand<LoggaInViewModel>(new NavigationService<LoggaInViewModel>(navigationStore, () => new LoggaInViewModel(navigationStore)));
            TillbakaCommand = new NavigateCommand<HuvudMenyViewModel>(new NavigationService<HuvudMenyViewModel>(navigationStore, () => new HuvudMenyViewModel(navigationStore, användare)));
            Användare = användare;
            //Benämning ObservableCollection
            TypAlpin = new ObservableCollection<Utrustning>(utrustningsKontroller.SökBenämning("Alpint"));
            TypSnowboard = new ObservableCollection<Utrustning>(utrustningsKontroller.SökBenämning("Snowboard"));
            TypLängd = new ObservableCollection<Utrustning>(utrustningsKontroller.SökBenämning("Längd"));
            TypSkoter = new ObservableCollection<Utrustning>(utrustningsKontroller.SökBenämning("Snöskoter"));
            TypHjälm = new ObservableCollection<Utrustning>(utrustningsKontroller.SökBenämning("Hjälm"));
            TypPaket = new ObservableCollection<Utrustning>(utrustningsKontroller.SökPaket("Paket"));
            //OBS - Lägga till Extremsporter här

            TotalDisplayUtrustning = new ObservableCollection<DisplayUtrustning>();
            ValdUtrustningTillBokning = new ObservableCollection<Utrustning>();
            UppdateraCommandSkidshop = new NavigateCommand<SkidshopViewModel>(new NavigationService<SkidshopViewModel>(navigationStore, () => new SkidshopViewModel(navigationStore, användare)));
        }

        public ICommand TillbakaCommand { get; }
        public ICommand UppdateraCommandSkidshop { get; }

        public ICommand NavigateLoggaUtCommand { get; }

        private ICommand exitCommand = null!;
        public ICommand ExitCommand =>
        exitCommand ??= exitCommand = new RelayCommand(() => App.Current.Shutdown());

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


        #region Properties Utrustning + Datum

        private Användare användare = null!;
        public Användare Användare
        {
            get => användare;
            set
            {
                användare = value; OnPropertyChanged();

            }
        }

        //private string inputBokningsNr;
        //public string InputBokningsNr
        //{
        //    get => inputBokningsNr; set
        //    {

        //    }
        //}
        private string inputBokningsNr;
        public string InputBokningsNr { get => inputBokningsNr; set { inputBokningsNr = value; OnPropertyChanged(); } }


        private DateTime inlämning = DateTime.Now;
        public DateTime Inlämning
        {
            get => inlämning; set
            {
                inlämning = value; OnPropertyChanged();
                TotalDisplayUtrustning.Clear();
                if (Inlämning >= DateTime.Now.Date)
                {
                    IsEnabledUtrustning = true;
                    GruppLektioner = new ObservableCollection<GruppLektion>(lektionsKontroller.AktuellaGruppLektioner(Inlämning));
                    PrivatLektioner = new ObservableCollection<PrivatLektion>(lektionsKontroller.AktuellaPrivatLektioner(inlämning));
                    AllaLektioner = new ObservableCollection<object>(lektionsKontroller.HämtaAktuellaLektioner(PrivatLektioner, GruppLektioner));

                }
                else
                {
                    MessageBox.Show("Datum är inkorrekt", "Bokning", MessageBoxButton.OK);
                    IsEnabledUtrustning = false;
                }

            }
        }
        private Visibility ksynlighet;
        public Visibility KSynlighet
        {

            get { return ksynlighet; }
            set { ksynlighet = value; OnPropertyChanged(); }

        }
        private Visibility gömKvittoKnapp = Visibility.Collapsed;
        public Visibility GömKvittoKnapp
        {

            get { return gömKvittoKnapp; }
            set { gömKvittoKnapp = value; OnPropertyChanged(); }

        }
        private Visibility gömÅterlämnaKnapp = Visibility.Collapsed;
        public Visibility GömÅterlämnaKnapp
        {

            get { return gömÅterlämnaKnapp; }
            set { gömÅterlämnaKnapp = value; OnPropertyChanged(); }

        }
        private Visibility gömTaBortKnapp = Visibility.Visible;
        public Visibility GömTaBortKnapp
        {

            get { return gömTaBortKnapp; }
            set { gömTaBortKnapp = value; OnPropertyChanged(); }

        }
        private Visibility gömLämnaUtKnapp = Visibility.Visible;
        public Visibility GömLämnaUtKnapp
        {

            get { return gömLämnaUtKnapp; }
            set { gömLämnaUtKnapp = value; OnPropertyChanged(); }

        }

        #endregion


        #region Command - Spara Utrustning

        private ICommand sparaCommand = null!;
        public ICommand SparaCommand => sparaCommand ??= sparaCommand = new RelayCommand(() =>
        {

            //Fyller lista som ska hämtas från bokning
            List<Utrustning> hämtadUtrustning = new List<Utrustning>();
            foreach (var item in TotalDisplayUtrustning)
            {

                if (item.Benämning == "Paket")
                {
                    IList<Utrustning> paket = new List<Utrustning>();
                    paket = utrustningsKontroller.HittaPaket(item.Value, item.Typ, item.Benämning, Inlämning, hämtadUtrustning);
                    foreach (var paketUtrustning in paket)
                    {
                        hämtadUtrustning.Add(paketUtrustning);
                    }
                }
                else
                {
                    IList<Utrustning> utrustningar = new List<Utrustning>();
                    utrustningar = utrustningsKontroller.HittaUtrustning(item.Value, item.Typ, item.Benämning, Inlämning, hämtadUtrustning);
                    foreach (var itemUtrustning in utrustningar)
                    {
                        hämtadUtrustning.Add(itemUtrustning);
                    }
                }
                //if (item.Benämning == "Paket") hämtadUtrustning.Concat(utrustningsKontroller.HittaPaket(item.Value, item.Typ, item.Benämning, Inlämning));
            }
            if (Privatkund != null)
            {
                foreach (var item in hämtadUtrustning)
                {
                    item.Status = item.StatusBokad();
                }
                Privatkund = privatkundKontroller.SökPrivatkund(Kundnummer);
                MasterBokning privatexisterarEj = utrustningsKontroller.SkapaUtrustningsBokningPrivat(hämtadUtrustning, Inlämning, Privatkund, Användare, SummaTotal, KreditIsChecked);
                if (privatexisterarEj == null) MessageBox.Show("Bokning existerar ej", "Bokning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                else
                {
                    if (privatexisterarEj.NyttjadKreditsumma > Privatkund.MaxBeloppsKreditGräns && KreditIsChecked == true)
                    {
                        MessageBox.Show("Max kredit har nåtts");

                    }
                    if (privatexisterarEj.UtrustningsBokningar.Count != 0)
                    {
                        MessageBox.Show("Bokning skapad", "Bokning", MessageBoxButton.OK, MessageBoxImage.Information);
                        PDF.CreatePDF.SkapaKvittoUthyrningPrivat(Privatkund, hämtadUtrustning, Inlämning);
                    }
                }

            }
            else if (Företagskund != null)
            {
                foreach (var item in hämtadUtrustning)
                {
                    item.Status = item.StatusBokad();
                }
                Företagskund = företagskundKontroller.SökFöretagskund(Kundnummer);
                MasterBokning företagexisterarEj = utrustningsKontroller.SkapaUtrustningsBokningFöretag(hämtadUtrustning, Inlämning, Företagskund, Användare, SummaTotal, KreditIsChecked);
                if (företagexisterarEj == null) MessageBox.Show("Bokning existerar ej", "Bokning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                else
                {
                    if (företagexisterarEj.NyttjadKreditsumma > Företagskund.MaxBeloppsKreditGräns && KreditIsChecked == true)
                    {
                        MessageBox.Show("Max kredit har nåtts");
                    }
                    if (företagexisterarEj.UtrustningsBokningar.Count != 0)
                    {

                        MessageBox.Show("Bokning skapad", "Bokning", MessageBoxButton.OK, MessageBoxImage.Information);
                        PDF.CreatePDF.SkapaKvittoUthyrningFöretag(Företagskund, hämtadUtrustning, Inlämning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Ange en Kund", "Bokning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            hämtadUtrustning.Clear();
        });
        #endregion

        #region Properties Logi, Privatkund (Sprint1)



        private DateTime starttid = DateTime.Now;
        public DateTime Starttid { get => starttid; set { starttid = value; OnPropertyChanged(); } }

        private DateTime sluttid = DateTime.Now;
        public DateTime Sluttid { get => sluttid; set { sluttid = value; OnPropertyChanged(); } }

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
        public string Kundnummer
        {
            get => kundnummer; set
            {
                kundnummer = value; OnPropertyChanged();

                MasterBokning = lektionsKontroller.HämtaKundsMasterBokning(Kundnummer);
            }
        }
        private Företagskund företagskund = null!;
        public Företagskund Företagskund
        {
            get => företagskund; set
            {
                företagskund = value; OnPropertyChanged();
                if (Företagskund != null)
                {
                    MasterBokning = bokningsKontroller.HämtaAktivFöretagskundMasterbokning(Företagskund, LektionsDatum);
                }
            }
        }

        private Privatkund privatkund = null!;
        public Privatkund Privatkund { get => privatkund; set { privatkund = value; OnPropertyChanged();
                if (Privatkund != null)
                {
                    MasterBokning = bokningsKontroller.HämtaAktivPrivatkundMasterbokning(Privatkund,LektionsDatum);
                }
            } }

        private MasterBokning masterbokning = null!;
        public MasterBokning MasterBokning { get => masterbokning; set { masterbokning = value; OnPropertyChanged(); } }

        private Visibility fsynlighet = Visibility.Collapsed;
        public Visibility FSynlighet
        {

            get { return fsynlighet; }
            set { fsynlighet = value; OnPropertyChanged(); }

        }
        #endregion

        private ICommand skrivUtKvittoCommand = null!;
        public ICommand SkrivUtKvittoCommand => skrivUtKvittoCommand ??= skrivUtKvittoCommand = new RelayCommand(() =>
        {
            if (Företagskund != null)
            {
                IList<Utrustning> utrFöretag = utrustningsKontroller.HämtaUtrustningsbokningFöretagskund(Företagskund);
                if (utrFöretag == null)
                {
                    MessageBox.Show("Utrustningsbokning saknas");
                }
                else
                {
                    PDF.CreatePDF.SkapaKvittoUthyrningFöretag(Företagskund, utrFöretag, Inlämning);
                    MessageBox.Show($"Kvitto utskrivet för bokning", "Kvitto", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }

            }
            else if (Privatkund != null)
            {

                IList<Utrustning> utrPrivat = utrustningsKontroller.HämtaUtrustningsbokningPrivatkund(Privatkund);
                if (utrPrivat == null)
                {
                    MessageBox.Show("Utrustningsbokning saknas");
                }
                else
                {
                    PDF.CreatePDF.SkapaKvittoUthyrningPrivat(Privatkund, utrPrivat, Inlämning);
                    MessageBox.Show($"Kvitto utskrivet för bokning", "Kvitto", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }

            }
            else
            {
                MessageBox.Show($"Utrustningsbokning saknas! Skriv in ett kundnummer med aktiv utrustningsbokning.", "Kvitto", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            GömKvittoKnapp = Visibility.Collapsed;
            GömLämnaUtKnapp = Visibility.Visible;
            GömTaBortKnapp = Visibility.Visible;
            TotalDisplayUtrustning.Clear();
        });

        private ICommand taBortCommand = null!;
        public ICommand TaBortCommand => taBortCommand ??= taBortCommand = new RelayCommand(() =>
        {
            TotalDisplayUtrustning.Remove(SelectedItemDisplayUtrustning);
            BeräknaSummaTotal();
        });

        private ICommand accepteraÅterlämningCommand = null!;
        public ICommand AccepteraÅterlämningCommand => accepteraÅterlämningCommand ??= accepteraÅterlämningCommand = new RelayCommand(() =>
        {
            utrustningsKontroller.FullbordaÅterlämning(InputBokningsNr.ToString());
            MessageBox.Show($"Utrustning återlämnad!", "Återlämning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            GömÅterlämnaKnapp = Visibility.Collapsed;
            GömLämnaUtKnapp = Visibility.Visible;
            GömTaBortKnapp = Visibility.Visible;
        });


        private ICommand återlämnaUtrustningCommand = null!;
        public ICommand ÅterlämnaUtrustningCommand => återlämnaUtrustningCommand ??= återlämnaUtrustningCommand = new RelayCommand(() =>
        {
            GömÅterlämnaKnapp = Visibility.Visible;
            GömLämnaUtKnapp = Visibility.Collapsed;
            GömTaBortKnapp = Visibility.Collapsed;
            GömKvittoKnapp = Visibility.Collapsed;
            string input = Interaction.InputBox("Ange Bokningsnummer", "Återlämmning", "Default", 50, 50);
            MasterBokning bokningNrExiterar = utrustningsKontroller.BokningExisterar(input);
            if (bokningNrExiterar == null) MessageBox.Show("Bokning Existerar Ej", "Bokning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            else
            {
                InputBokningsNr = input;
                int antalUtrustningar = 0;
                List<Utrustning> bokningsUtrustning = new List<Utrustning>();
                foreach (var item in bokningNrExiterar.UtrustningsBokningar)
                {
                    foreach (Utrustning utrustning in item.Utrustningar.Where(a => a.Status == false))
                    {
                        bokningsUtrustning.Add(utrustning);
                    }
                }
                var groupedUtrFöretag = bokningsUtrustning
                    .GroupBy(i => i.Benämning)
                    .Select(group => new { Benämning = group.Key, Count = group.Count(), Utrustning = group.First() })
                    .ToList();
                TotalDisplayUtrustning.Clear();
                if (bokningsUtrustning != null)
                {
                    foreach (var item in groupedUtrFöretag)
                    {
                        TotalDisplayUtrustning.Add(new DisplayUtrustning(item.Count, item.Utrustning, item.Utrustning.Typ, item.Benämning, item.Utrustning.Status));
                    }
                }
                else
                {
                    TotalDisplayUtrustning.Clear();
                }

            }
        });

        private ICommand visaUtrustningCommand = null!;
        public ICommand VisaUtrustningCommand => visaUtrustningCommand ??= visaUtrustningCommand = new RelayCommand(() =>
        {
            GömKvittoKnapp = Visibility.Visible;
            GömLämnaUtKnapp = Visibility.Collapsed;
            GömTaBortKnapp = Visibility.Collapsed;
            GömÅterlämnaKnapp = Visibility.Collapsed;
            //MasterBokning bokningNrExiterar = utrustningsKontroller.BokningExisterar(Kundnummer);
            //if (bokningNrExiterar == null) MessageBox.Show("Bokning Existerar Ej", "Bokning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            //else
            //{
            if (Företagskund != null)
            {
                IList<Utrustning> utrFöretag = utrustningsKontroller.HämtaUtrustningsbokningFöretagskund(Företagskund);
                if (utrFöretag != null)
                {
                    var groupedUtrFöretag = utrFöretag
                    .GroupBy(i => i.Benämning)
                    .Select(group => new { Benämning = group.Key, Count = group.Count(), Utrustning = group.First() })
                    .ToList();
                    TotalDisplayUtrustning.Clear();
                    foreach (var item in groupedUtrFöretag)
                    {
                        TotalDisplayUtrustning.Add(new DisplayUtrustning(item.Count, item.Utrustning, item.Utrustning.Typ, item.Benämning, item.Utrustning.Status));
                    }
                }
                else MessageBox.Show("Utrustningsbokning saknas");

            }
            else if (Privatkund != null)
            {
                IList<Utrustning> utrPrivat = utrustningsKontroller.HämtaUtrustningsbokningPrivatkund(Privatkund);
                if (utrPrivat != null)
                {
                    var groupedUtrFöretag = utrPrivat
                    .GroupBy(i => i.Benämning)
                    .Select(group => new { Benämning = group.Key, Count = group.Count(), Utrustning = group.First() })
                    .ToList();
                    TotalDisplayUtrustning.Clear();
                    foreach (var item in groupedUtrFöretag)
                    {
                        TotalDisplayUtrustning.Add(new DisplayUtrustning(item.Count, item.Utrustning, item.Utrustning.Typ, item.Benämning, item.Utrustning.Status));
                    }
                }
                else MessageBox.Show("Utrustningsbokning saknas");

            }


        });

        private ICommand sökKund = null!;
        public ICommand SökKund => sökKund ??= sökKund = new RelayCommand(() =>
        {
            GömKvittoKnapp = Visibility.Collapsed;
            TotalDisplayUtrustning.Clear();
            GömLämnaUtKnapp = Visibility.Visible;
            GömTaBortKnapp = Visibility.Visible;
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
                //Tillkommmit
                Företagskund = null;
            }
            Företagskund = företagskundKontroller.SökFöretagskund(Kundnummer);
            if (företagskund != null)
            {
                KSynlighet = Visibility.Collapsed;
                FSynlighet = Visibility.Visible;
                Kundnummer = Företagskund.OrgNr;
                //Tillkommmit
                Privatkund = null;
            }
            lektionsKontroller.HämtaKundsMasterBokning(Kundnummer);
        });
        #region Lägg till Commands - Utrustning
        private ICommand läggTillAlpinCommand = null!;
        public ICommand LäggTillAlpinCommand => läggTillAlpinCommand ??= läggTillAlpinCommand = new RelayCommand(() =>
        {
            if (AntalAlpin.Count == 0) ;
            else
            {
                TotalDisplayUtrustning.Add(new DisplayUtrustning(SelectedItemAntalAlpin, SelectedItemAlpin, SelectedItemAlpin.UtrustningsTyp.Typ, SelectedItemAlpin.Benämning, SummaAlpin));
                AntalAlpin.Clear();
                SummaAlpin = 0;
                BeräknaSummaTotal();
                LaddaOmSelectedInfo();
                StoppaKreditUtrustning();
            }


        });

        private ICommand läggTillSnowboardCommand = null!;
        public ICommand LäggTillSnowboardCommand => läggTillSnowboardCommand ??= läggTillSnowboardCommand = new RelayCommand(() =>
        {
            if (AntalSnowboard.Count == 0) ;
            else
            {
                TotalDisplayUtrustning.Add(new DisplayUtrustning(SelectedItemAntalSnowboard, SelectedItemSnowboard, SelectedItemSnowboard.UtrustningsTyp.Typ, SelectedItemSnowboard.Benämning, SummaSnowboard));
                AntalSnowboard.Clear();
                SummaSnowboard = 0;
                BeräknaSummaTotal();
                LaddaOmSelectedInfo();
                StoppaKreditUtrustning();
            }

        });
        private ICommand läggTillLängdCommand = null!;
        public ICommand LäggTillLängdCommand => läggTillLängdCommand ??= läggTillLängdCommand = new RelayCommand(() =>
        {
            if (AntalLängd.Count == 0) ;
            else
            {
                TotalDisplayUtrustning.Add(new DisplayUtrustning(SelectedItemAntalLängd, SelectedItemLängd, SelectedItemLängd.UtrustningsTyp.Typ, SelectedItemLängd.Benämning, SummaLängd));
                AntalLängd.Clear();
                SummaLängd = 0;
                BeräknaSummaTotal();
                LaddaOmSelectedInfo();
                StoppaKreditUtrustning();
            }

        });
        private ICommand läggTillHjälmCommand = null!;
        public ICommand LäggTillHjälmCommand => läggTillHjälmCommand ??= läggTillHjälmCommand = new RelayCommand(() =>
        {
            if (AntalHjälm.Count == 0) ;
            else
            {
                TotalDisplayUtrustning.Add(new DisplayUtrustning(SelectedItemAntalHjälm, SelectedItemHjälm, SelectedItemHjälm.UtrustningsTyp.Typ, SelectedItemHjälm.Benämning, SummaHjälm));
                AntalHjälm.Clear();
                SummaHjälm = 0;
                BeräknaSummaTotal();
                LaddaOmSelectedInfo();
                StoppaKreditUtrustning();
            }

        });
        private ICommand läggTillSkoterCommand = null!;
        public ICommand LäggTillSkoterCommand => läggTillSkoterCommand ??= läggTillSkoterCommand = new RelayCommand(() =>
        {
            if (AntalSkoter.Count == 0) ;
            else
            {
                TotalDisplayUtrustning.Add(new DisplayUtrustning(SelectedItemAntalSkoter, SelectedItemSkoter, SelectedItemSkoter.UtrustningsTyp.Typ, SelectedItemSkoter.Benämning, SummaHjälm));
                AntalSkoter.Clear();
                SummaSkoter = 0;
                BeräknaSummaTotal();
                LaddaOmSelectedInfo();
                StoppaKreditUtrustning();

            }

        });

        #endregion

        #region SUMMA - Utrustning
        private int summaTotal;
        public int SummaTotal
        {
            get { return summaTotal; }
            set
            {
                summaTotal = value; OnPropertyChanged();
                StoppaKreditUtrustning();
            }
        }


        private int summaAlpin;
        public int SummaAlpin
        {
            get { return summaAlpin; }
            set { summaAlpin = value; OnPropertyChanged(); }


        }
        private int summaSnowboard;
        public int SummaSnowboard
        {
            get { return summaSnowboard; }
            set { summaSnowboard = value; OnPropertyChanged(); }


        }
        private int summaLängd;
        public int SummaLängd
        {
            get { return summaLängd; }
            set { summaLängd = value; OnPropertyChanged(); }


        }
        private int summaHjälm;
        public int SummaHjälm
        {
            get { return summaHjälm; }
            set { summaHjälm = value; OnPropertyChanged(); }
        }

        private int summaSkoter;
        public int SummaSkoter
        {
            get { return summaSkoter; }
            set { summaSkoter = value; OnPropertyChanged(); }
        }
        private int summaPaket;
        public int SummaPaket
        {
            get { return summaPaket; }
            set { summaPaket = value; OnPropertyChanged(); }
        }
        #endregion


        #region AntalInt - Utrustning

        private ObservableCollection<int> antalAlpin;
        public ObservableCollection<int> AntalAlpin
        {
            get { return antalAlpin; }
            set { antalAlpin = value; OnPropertyChanged(); }


        }

        private ObservableCollection<int> antalSnowboard;
        public ObservableCollection<int> AntalSnowboard
        {
            get { return antalSnowboard; }
            set { antalSnowboard = value; OnPropertyChanged(); }
        }

        private ObservableCollection<int> antalLängd;
        public ObservableCollection<int> AntalLängd
        {
            get { return antalLängd; }
            set { antalLängd = value; OnPropertyChanged(); }
        }

        private ObservableCollection<int> antalHjälm;
        public ObservableCollection<int> AntalHjälm
        {
            get { return antalHjälm; }
            set { antalHjälm = value; OnPropertyChanged(); }
        }

        private ObservableCollection<int> antalSkoter;
        public ObservableCollection<int> AntalSkoter
        {
            get { return antalSkoter; }
            set { antalSkoter = value; OnPropertyChanged(); }
        }
        private ObservableCollection<int> antalPaket;
        public ObservableCollection<int> AntalPaket
        {
            get { return antalPaket; }
            set { antalPaket = value; OnPropertyChanged(); }
        }
        #endregion


        #region SELECTEDITEM - Utrustning

        private DisplayUtrustning selectedItemDisplayUtrustning = null!;
        public DisplayUtrustning SelectedItemDisplayUtrustning
        {
            get => selectedItemDisplayUtrustning; set
            {
                selectedItemDisplayUtrustning = value; OnPropertyChanged();

            }
        }

        private Utrustning selectedItemAlpin = null!;
        public Utrustning SelectedItemAlpin
        {
            get => selectedItemAlpin; set
            {
                selectedItemAlpin = value; OnPropertyChanged();
                IsEnabledAntalAlpin = true;
                IsEnabledAntalAlpin = ÄrRedanIBokning(SelectedItemAlpin);
                if (SelectedItemAlpin != null)
                    if (IsEnabledAntalAlpin)
                    {
                        if (SelectedItemAlpin.Benämning == "Paket") AntalAlpin = utrustningsKontroller.SökPaketTyp(SelectedItemAlpin.Benämning, SelectedItemAlpin.Typ, Inlämning);
                        else AntalAlpin = utrustningsKontroller.SökBenämningTyp(SelectedItemAlpin.Benämning, SelectedItemAlpin.Typ, Inlämning);
                    }
            }
        }

        private Utrustning selectedItemSnowboard = null!;
        public Utrustning SelectedItemSnowboard
        {
            get => selectedItemSnowboard; set
            {
                selectedItemSnowboard = value; OnPropertyChanged();
                IsEnabledAntalSnowboard = true;
                IsEnabledAntalSnowboard = ÄrRedanIBokning(SelectedItemSnowboard);
                if (SelectedItemSnowboard != null)
                    if (IsEnabledAntalSnowboard)
                    {
                        if (SelectedItemSnowboard.Benämning == "Paket") AntalSnowboard = utrustningsKontroller.SökPaketTyp(SelectedItemSnowboard.Benämning, SelectedItemSnowboard.Typ, Inlämning);
                        else AntalSnowboard = utrustningsKontroller.SökBenämningTyp(SelectedItemSnowboard.Benämning, SelectedItemSnowboard.Typ, Inlämning);
                    }



            }
        }
        private Utrustning selectedItemLängd = null!;
        public Utrustning SelectedItemLängd
        {
            get => selectedItemLängd; set
            {
                selectedItemLängd = value; OnPropertyChanged();
                IsEnabledAntalLängd = true;

                IsEnabledAntalLängd = ÄrRedanIBokning(SelectedItemLängd);
                if (SelectedItemLängd != null)
                    if (IsEnabledAntalLängd)
                    {
                        if (SelectedItemLängd.Benämning == "Paket") AntalLängd = utrustningsKontroller.SökPaketTyp(SelectedItemLängd.Benämning, SelectedItemLängd.Typ, Inlämning);
                        else AntalLängd = AntalLängd = utrustningsKontroller.SökBenämningTyp(SelectedItemLängd.Benämning, SelectedItemLängd.Typ, Inlämning);
                    }
            }
        }
        private Utrustning selectedItemHjälm = null!;
        public Utrustning SelectedItemHjälm
        {
            get => selectedItemHjälm; set
            {
                selectedItemHjälm = value; OnPropertyChanged();

                IsEnabledAntalHjälm = true;
                IsEnabledAntalHjälm = ÄrRedanIBokning(SelectedItemHjälm);
                if (SelectedItemHjälm != null)
                    if (IsEnabledAntalHjälm) AntalHjälm = utrustningsKontroller.SökBenämningTyp(SelectedItemHjälm.Benämning, SelectedItemHjälm.Typ, Inlämning);
            }
        }
        private Utrustning selectedItemSkoter = null!;
        public Utrustning SelectedItemSkoter
        {
            get => selectedItemSkoter; set
            {
                selectedItemSkoter = value; OnPropertyChanged();

                IsEnabledAntalSkoter = true;
                IsEnabledAntalSkoter = ÄrRedanIBokning(SelectedItemSkoter);
                if (SelectedItemSkoter != null)
                    if (IsEnabledAntalSkoter) AntalSkoter = utrustningsKontroller.SökBenämningTyp(SelectedItemSkoter.Benämning, SelectedItemSkoter.Typ, Inlämning);
            }
        }
        private Utrustning selectedItemPaket = null!;
        public Utrustning SelectedItemPaket
        {
            get => selectedItemPaket; set
            {
                selectedItemPaket = value; OnPropertyChanged();

                IsEnabledAntalPaket = true;
                IsEnabledAntalPaket = ÄrRedanIBokning(SelectedItemPaket);
                if (SelectedItemSkoter != null)
                    if (IsEnabledAntalPaket) AntalPaket = utrustningsKontroller.SökPaketTyp(SelectedItemPaket.Benämning, SelectedItemPaket.Typ, Inlämning);
            }
        }




        #endregion


        #region Metoder - Utrustning

        public bool ÄrRedanIBokning(Utrustning selectedItem)
        {
            if (TotalDisplayUtrustning.Count == 0) return true;
            else
            {
                foreach (var item in TotalDisplayUtrustning)
                {
                    if (item.PropUtrustning.Equals(selectedItem))
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public void LaddaOmSelectedInfo()
        {
            SelectedItemAlpin = null;
            SelectedItemSnowboard = null;
            SelectedItemLängd = null;
            SelectedItemHjälm = null;
            SelectedItemSkoter = null;
        }
        public void LaddaOmSida()
        {
            TotalDisplayUtrustning.Clear();
            IsEnabledAntalAlpin = true;
            TypAlpin.Clear();
            AntalAlpin.Clear();
        }


        public void BoolExisterarBokning(MasterBokning existerar)
        {
            if (existerar == null) MessageBox.Show("Bokning existerar ej", "Bokning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            else MessageBox.Show("Bokning skapad", "Bokning", MessageBoxButton.OK, MessageBoxImage.Information);
        }



        public void BeräknaSummaTotal()
        {
            int total = 0;
            foreach (var item in TotalDisplayUtrustning)
            {
                total += item.Summa;
            }
            SummaTotal = total;
        }

        public void StoppaKreditUtrustning()
        {
            if (KreditIsChecked == true && Privatkund != null)
            {
                if (KreditIsChecked == true)
                {
                    MasterBokning mbe = lektionsKontroller.HämtaKundsMasterBokning(Kundnummer);
                    bool bVariabel = lektionsKontroller.TillåtEjKredit(Privatkund.MaxBeloppsKreditGräns, SummaTotal, mbe);
                    if (bVariabel == false)
                    {
                        KreditIsChecked = false;
                        MessageBox.Show("Kunden har nått maxkredit!");
                    }
                }
                if (KreditIsChecked == true && Företagskund != null)
                {
                    MasterBokning mbe = lektionsKontroller.HämtaKundsMasterBokning(Kundnummer);
                    bool bVariabel = lektionsKontroller.TillåtEjKredit(Företagskund.MaxBeloppsKreditGräns, SummaTotal, mbe);
                    if (bVariabel == false)
                    {
                        KreditIsChecked = false;
                        MessageBox.Show("Kunden har nått maxkredit!");
                    }
                }
            }
        }


        #endregion


        #region SELECTED INT - Utrustning

        private int selectedItemAntalAlpin;
        public int SelectedItemAntalAlpin
        {
            get => selectedItemAntalAlpin; set
            {
                selectedItemAntalAlpin = value; OnPropertyChanged();
                SummaAlpin = priskontroller.BeräknaPrisUtrustning(SelectedItemAntalAlpin, SelectedItemAlpin.Typ, SelectedItemAlpin.Benämning, Inlämning);
                if (AntalAlpin != null && SelectedItemAlpin != null) IsEnabledBtnAlpin = true;
                else IsEnabledBtnAlpin = false;
            }
        }

        private int selectedItemAntalSnowboard;
        public int SelectedItemAntalSnowboard
        {
            get => selectedItemAntalSnowboard; set
            {
                selectedItemAntalSnowboard = value; OnPropertyChanged();

                SummaSnowboard = priskontroller.BeräknaPrisUtrustning(SelectedItemAntalSnowboard, SelectedItemSnowboard.Typ, SelectedItemSnowboard.Benämning, Inlämning);
                if (AntalSnowboard != null && SelectedItemSnowboard != null) IsEnabledBtnSnowboard = true;
                else IsEnabledBtnSnowboard = false;
            }
        }
        private int selectedItemAntalLängd;
        public int SelectedItemAntalLängd
        {
            get => selectedItemAntalLängd; set
            {
                selectedItemAntalLängd = value; OnPropertyChanged();

                SummaLängd = priskontroller.BeräknaPrisUtrustning(SelectedItemAntalLängd, SelectedItemLängd.Typ, SelectedItemLängd.Benämning, Inlämning);

                if (AntalLängd != null && SelectedItemLängd != null) IsEnabledBtnLängd = true;
                else IsEnabledBtnLängd = false;
            }
        }


        private int selectedItemAntalHjälm;
        public int SelectedItemAntalHjälm
        {
            get => selectedItemAntalHjälm; set
            {
                selectedItemAntalHjälm = value; OnPropertyChanged();

                SummaHjälm = priskontroller.BeräknaPrisUtrustning(SelectedItemAntalHjälm, SelectedItemHjälm.Typ, SelectedItemHjälm.Benämning, Inlämning);
                if (AntalHjälm != null && SelectedItemHjälm != null) IsEnabledBtnHjälm = true;
                else IsEnabledBtnHjälm = false;
            }
        }
        private int selectedItemAntalSkoter;
        public int SelectedItemAntalSkoter
        {
            get => selectedItemAntalSkoter; set
            {
                selectedItemAntalSkoter = value; OnPropertyChanged();

                SummaSkoter = priskontroller.BeräknaPrisUtrustning(SelectedItemAntalSkoter, SelectedItemSkoter.Typ, SelectedItemSkoter.Benämning, Inlämning);
                if (AntalSkoter != null && SelectedItemSkoter != null) IsEnabledBtnSkoter = true;
                else isEnabledBtnSkoter = false;
            }
        }




        #endregion


        #region Observable Properties & Collections - Skidlektion ............


        private bool kreditCheckLektion;
        public bool KreditCheckLektion
        {
            get { return kreditCheckLektion; }
            set
            {
                if (kreditCheckLektion != value)
                {
                    kreditCheckLektion = value;
                    OnPropertyChanged(nameof(KreditCheckLektion));
                }
            }
        }



        
        private DateTime lektionsDatum = DateTime.Now;
        public DateTime LektionsDatum
        {
            get => lektionsDatum; set
            {
                lektionsDatum = value; OnPropertyChanged();
                if (Privatkund != null)
                {
                    MasterBokning = bokningsKontroller.HämtaAktivPrivatkundMasterbokning(Privatkund, LektionsDatum);
                }
                if (Företagskund != null)
                {
                    MasterBokning = bokningsKontroller.HämtaAktivFöretagskundMasterbokning(Företagskund, LektionsDatum);
                }
                if (LektionsDatum >= DateTime.Now.Date)
                {
                    if (MasterBokning != null)
                    {
                        GruppLektioner = new ObservableCollection<GruppLektion>(lektionsKontroller.AktuellaGruppLektioner(LektionsDatum));
                        PrivatLektioner = new ObservableCollection<PrivatLektion>(lektionsKontroller.AktuellaPrivatLektioner(LektionsDatum));
                        AllaLektioner = new ObservableCollection<object>(lektionsKontroller.HämtaAktuellaLektioner(PrivatLektioner, GruppLektioner));
                        KnappAktiv = true;
                    }
                    else if (GruppLektioner != null || PrivatLektioner != null || AllaLektioner != null)
                    {
                            GruppLektioner.Clear();
                            PrivatLektioner.Clear();
                            AllaLektioner.Clear();
                            KnappAktiv = false;
                    }
                }
                else
                {
                    MessageBox.Show("Datum är inkorrekt", "Bokning", MessageBoxButton.OK);
                }

            }
        }


        private ObservableCollection<GruppLektion> gruppLektioner = null!;
        public ObservableCollection<GruppLektion> GruppLektioner
        {
            get => gruppLektioner;
            set
            {
                gruppLektioner = value; OnPropertyChanged();
            }
        }

        private ObservableCollection<PrivatLektion> privatLektioner = null!;
        public ObservableCollection<PrivatLektion> PrivatLektioner
        {
            get => privatLektioner;
            set
            {
                privatLektioner = value; OnPropertyChanged();
            }
        }
        private ObservableCollection<Elev> eleverna = null!;
        public ObservableCollection<Elev> Eleverna
        {
            get => eleverna;
            set
            {
                eleverna = value; OnPropertyChanged();
            }
        }

        private ObservableCollection<Object> allaLektioner = null!;
        public ObservableCollection<Object> AllaLektioner
        {
            get => allaLektioner;
            set
            {
                allaLektioner = value; OnPropertyChanged();
            }
        }
        private Elev elevTillLektion = null!;
        public Elev ElevTillLektion { get => elevTillLektion; set { elevTillLektion = value; OnPropertyChanged(); } }


        private int selectedPrivatIndex;
        public int SelectedPrivatIndex { get { return selectedPrivatIndex; } set { selectedPrivatIndex = value; OnPropertyChanged(); } }

        private int selectedGruppIndex;
        public int SelectedGruppIndex { get { return selectedGruppIndex; } set { selectedGruppIndex = value; OnPropertyChanged(); } }

        private GruppLektion selectedGruppItem = null!;
        public GruppLektion SelectedGruppItem
        {
            get => selectedGruppItem; set
            {
                selectedGruppItem = value; OnPropertyChanged();

                if (SelectedGruppItem != null)
                {
                    Eleverna = new ObservableCollection<Elev>(lektionsKontroller.HämtaDeltagareFrånLektionG(SelectedGruppItem));
                }
                if (SelectedGruppItem != null)
                {
                    SelectedPrivatItem = null;
                }

            }
        }

        private PrivatLektion selectedPrivatItem = null!;
        public PrivatLektion SelectedPrivatItem
        {
            get => selectedPrivatItem; set
            {
                selectedPrivatItem = value; OnPropertyChanged();

                if (SelectedPrivatItem != null)
                {
                    Eleverna = new ObservableCollection<Elev>(lektionsKontroller.HämtaDeltagareFrånLektionP(SelectedPrivatItem));
                }
                if (SelectedPrivatItem != null)
                {
                    selectedGruppItem = null;
                }
            }
        }

        private int antalDeltagare;
        public int AntalDeltagare
        {
            get => antalDeltagare; set
            {
                antalDeltagare = value; OnPropertyChanged();

            }
        }

        private string inFörnamn;
        public string InFörnamn
        {
            get { return inFörnamn; }
            set { inFörnamn = value; OnPropertyChanged(); }
        }
        private string inEfternamn;
        public string InEfternamn
        {
            get { return inEfternamn; }
            set { inEfternamn = value; OnPropertyChanged(); }
        }


        private Elev elevAttTaBortItem = null!;
        public Elev ElevAttTaBortItem { get => elevAttTaBortItem; set { elevAttTaBortItem = value; OnPropertyChanged(); } }


        private Elev elevAttTaBortIndex = null!;
        public Elev ElevAttTaBortIndex { get => elevAttTaBortIndex; set { elevAttTaBortIndex = value; OnPropertyChanged(); } }
        #endregion


        #region SUMMA & Metoder - Lektion
        private double lektionsTotalSumma;
        public double LektionsTotalSumma
        {
            get { return lektionsTotalSumma; }
            set
            {
                lektionsTotalSumma = value; OnPropertyChanged();
                StoppaKreditLektion();
            }
        }

        public void StoppaKreditLektion()
        {
            if (KreditCheckLektion == true && Privatkund != null)
            {
                if (KreditCheckLektion == true)
                {
                    MasterBokning mbe = lektionsKontroller.HämtaKundsMasterBokning(Kundnummer);
                    bool bVariabel = lektionsKontroller.TillåtEjKredit(Privatkund.MaxBeloppsKreditGräns, LektionsTotalSumma, mbe);
                    if (bVariabel == false)
                    {
                        KreditCheckLektion = false;
                        MessageBox.Show("Kunden har nått maxkredit!");
                    }
                }
                if (KreditCheckLektion == true && Företagskund != null)
                {
                    MasterBokning mbe = lektionsKontroller.HämtaKundsMasterBokning(Kundnummer);
                    bool bVariabel = lektionsKontroller.TillåtEjKredit(Företagskund.MaxBeloppsKreditGräns, LektionsTotalSumma, mbe);
                    if (bVariabel == false)
                    {
                        KreditCheckLektion = false;
                        MessageBox.Show("Kunden har nått maxkredit!");
                    }
                }
            }
        }

        public void BeräknaLektionsTotalSumma()
        {
            double total = 0;
            if(SelectedGruppItem!= null) 
            { 
            foreach (var item in Eleverna)
            {
                total += SelectedGruppItem.Pris;
            }

            }
            if(SelectedPrivatItem!= null) 
            {
                foreach (var item in Eleverna)
                {
                    total += SelectedPrivatItem.Pris;
                }
            }
            LektionsTotalSumma = total;
        }


        #endregion


        #region SKIDLEKTION Commands................


        private ICommand läggTillElevCommand = null!;
        public ICommand LäggTillElevCommand => läggTillElevCommand ??= läggTillElevCommand = new RelayCommand(() =>
        {
            if (SelectedPrivatItem != null && !string.IsNullOrEmpty(InputFörnamn) && !string.IsNullOrEmpty(InputEfternamn) && MasterBokning !=null)
            {
                ElevTillLektion = lektionsKontroller.RegistreraElev(InFörnamn, InEfternamn);
                lektionsKontroller.BokaPrivatLektion(ElevTillLektion, SelectedPrivatItem, MasterBokning);
                Eleverna = new ObservableCollection<Elev>(lektionsKontroller.HämtaDeltagareFrånLektionP(SelectedPrivatItem));
                double x = Eleverna.Count;
                double prisXElever = SelectedPrivatItem.Pris * x;
                lektionsKontroller.FixaPrisLektion(prisXElever, KreditCheckLektion, MasterBokning);
            }
            if (SelectedGruppItem != null && !string.IsNullOrEmpty(InputFörnamn) && !string.IsNullOrEmpty(InputEfternamn) && MasterBokning != null)
            {

                ElevTillLektion = lektionsKontroller.RegistreraElev(InFörnamn, InEfternamn);
                lektionsKontroller.BokaGruppLektion(ElevTillLektion, SelectedGruppItem, MasterBokning);
                Eleverna = new ObservableCollection<Elev>(lektionsKontroller.HämtaDeltagareFrånLektionG(SelectedGruppItem));
                lektionsKontroller.FixaPrisLektion(SelectedGruppItem.Pris, KreditCheckLektion, MasterBokning);


            }
            CreatePDF.SkapaKvittoLektionAlla(MasterBokning, Inlämning);
            BeräknaLektionsTotalSumma();
            StoppaKreditLektion();
        });

        private ICommand avbokaElevCommand = null!;
        public ICommand AvbokaElevCommand => avbokaElevCommand ??= avbokaElevCommand = new RelayCommand(() =>
        {

            if (ElevAttTaBortItem != null && SelectedGruppItem != null)
            {

                lektionsKontroller.AvBokaGruppLektion(ElevAttTaBortItem, SelectedGruppItem, MasterBokning);
            }


            if (ElevAttTaBortItem != null && SelectedPrivatItem != null)
            {

                lektionsKontroller.AvBokaPrivatLektion(ElevAttTaBortItem, SelectedPrivatItem, MasterBokning);
            }
            Eleverna.Clear();
            BeräknaLektionsTotalSumma();
        });


        #endregion







    }
}