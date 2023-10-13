using Affärslager;
using Entiteter.Personer;
using Entiteter.Tjänster;
using PresentationslagerWPF.Commands;
using PresentationslagerWPF.DataDisplay;
using PresentationslagerWPF.Models;
using PresentationslagerWPF.Services;
using PresentationslagerWPF.Stores;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PresentationslagerWPF.ViewModels
{

    public class SkidshopViewModel : ObservableObject
    {


        UtrustningsKontroller utrustningsKontroller = new UtrustningsKontroller();
        LektionsKontroller lektionsKontroller = new LektionsKontroller();


        #region Observable Collection 

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
        #endregion

        private ObservableCollection<MasterBokning> masterbokningar = null!;
        public ObservableCollection<MasterBokning> Masterbokningar
        {
            get => masterbokningar;
            set
            {
                masterbokningar = value; OnPropertyChanged();
            }
        }


        private List<int> antal;
        public List<int> Antal
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
        private ObservableCollection<Utrustning> typHjälm= null!;
        public ObservableCollection<Utrustning>  TypHjälm
        {
            get => typHjälm; set
            {
                typHjälm = value; OnPropertyChanged();
            }
        }

        #endregion



        #region NAVIGATION
        //**** NAVIGATION *******//

        public SkidshopViewModel(NavigationStore navigationStore, Användare användare)
        {
            TillbakaCommand = new NavigateCommand<HuvudMenyViewModel>(new NavigationService<HuvudMenyViewModel>(navigationStore, () => new HuvudMenyViewModel(navigationStore, användare)));
            
            //Benämning ObservableCollection
            TypAlpin = new ObservableCollection<Utrustning>(utrustningsKontroller.SökBenämning("Alpint"));
            TypSnowboard = new ObservableCollection<Utrustning>(utrustningsKontroller.SökBenämning("Snowboard"));
            TypLängd = new ObservableCollection<Utrustning>(utrustningsKontroller.SökBenämning("Längd"));
            TypSkoter = new ObservableCollection<Utrustning>(utrustningsKontroller.SökBenämning("Skoter"));
            TypHjälm = new ObservableCollection<Utrustning>(utrustningsKontroller.SökBenämning("Hjälm"));


            ValdUtrustningTillBokning = new ObservableCollection<Utrustning>();
            AntalTestList = new ObservableCollection<DisplayUtrustning>();
            //UnikBenämning = AllaUtrustningar
            //                    .GroupBy(i => i.Typ)
            //                    .Select(group => group.First())
            //                    .ToList();
        }
        public ICommand TillbakaCommand { get; }

        #endregion


        //private DisplayUtrustning = null

        #region AntalInt

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
        private ObservableCollection<int> antalSkoter;
        public ObservableCollection<int> AntalSkoter
        {
            get { return antalSkoter; }
            set { antalSkoter = value; OnPropertyChanged(); }
        }

        #endregion

        #region SELECTED ITEM


        private Utrustning selectedItemAlpin = null!;
        public Utrustning SelectedItemAlpin
        {
            get => selectedItemAlpin; set
            {
                selectedItemAlpin = value; OnPropertyChanged();
                AntalAlpin = utrustningsKontroller.SökBenämningTyp(SelectedItemAlpin.Benämning, SelectedItemAlpin.Typ);


            }
        }
        private Utrustning selectedItemSnowboard = null!;
        public Utrustning SelectedItemSnowboard
        {
            get => selectedItemSnowboard; set
            {
                selectedItemSnowboard = value; OnPropertyChanged();
                AntalAlpin = utrustningsKontroller.SökBenämningTyp(SelectedItemSnowboard.Benämning, SelectedItemSnowboard.Typ);



            }
        }
        private Utrustning selectedItemLängd = null!;
        public Utrustning SelectedItemLängd
        {
            get => selectedItemLängd; set
            {
                selectedItemLängd = value; OnPropertyChanged();
                AntalAlpin = utrustningsKontroller.SökBenämningTyp(SelectedItemLängd.Benämning, SelectedItemLängd.Typ);

            }
        }
        private Utrustning selectedItemHjälm = null!;
        public Utrustning SelectedItemHjälm
        {
            get => selectedItemHjälm; set
            {
                selectedItemHjälm = value; OnPropertyChanged();

                //IList<Utrustning> ListaTyp = utrustningsKontroller.SökTyp(SelectedItemUtrustning);
            }
        }

        #endregion


        #region SELECTED INT



        #endregion




        #region SKIDLEKTION ........................................................
        private ObservableCollection<Elev> elev = null!;
        public ObservableCollection<Elev> Elev { get => elev; set { elev = value; OnPropertyChanged(); } }

        private ObservableCollection<GruppLektion> gruppLektioner = null!;
        public ObservableCollection<GruppLektion> GruppLektioner
        {
            get => gruppLektioner;
            set
            {
                gruppLektioner = value; OnPropertyChanged();
            }
        }
        #region DisplayUtrustning

        private ObservableCollection<PrivatLektion> privatLektioner = null!;
        public ObservableCollection<PrivatLektion> PrivatLektioner
        {
            get => privatLektioner;
            set
            {
                privatLektioner = value; OnPropertyChanged();
            }
        }
        private Elev elevTillLektion = null!;
        public Elev ElevTillLektion { get => elevTillLektion; set { elevTillLektion = value; OnPropertyChanged(); } }

        private GruppLektion selectedGrupp = null!;
        public GruppLektion SelectedGrupp { get => selectedGrupp; set { selectedGrupp = value; OnPropertyChanged(); } }

        private PrivatLektion selectedPrivat = null!;
        public PrivatLektion SelectedPrivat { get => selectedPrivat; set { selectedPrivat = value; OnPropertyChanged(); } }

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

        private ICommand läggTillElevCommand = null!;
        public ICommand LäggTillElevCommand => läggTillElevCommand ??= läggTillElevCommand = new RelayCommand(() =>
        {
            if (InFörnamn != string.Empty && InEfternamn != string.Empty)
            {
                ElevTillLektion = lektionsKontroller.RegistreraElev(InFörnamn, InEfternamn);
            }
            if (SelectedPrivat != null && InFörnamn != string.Empty && InEfternamn != string.Empty)
            {

                lektionsKontroller.BokaPrivatLektion(ElevTillLektion, SelectedPrivat);
            }
            if (SelectedGrupp != null && InFörnamn != string.Empty && InEfternamn != string.Empty)
            {
                lektionsKontroller.BokaGruppLektion(ElevTillLektion, SelectedGrupp);
            }
        });
        #endregion


        private DisplayUtrustning antalTest = null!;
        //public DisplayUtrustning AntalTest
        //{
        //    get => antalTest;
        //    set
        //    {
        //        antalTest = value; OnPropertyChanged();

        //    }
        //}
        private ObservableCollection<DisplayUtrustning> antalTestList = null!;
        public ObservableCollection<DisplayUtrustning> AntalTestList
        {
            get => antalTestList; set
            {
                antalTestList = value; OnPropertyChanged();
            }
        }

        #endregion

        #region Metoder




        public void TilldelaTypUtrustning(Utrustning selectedItemUtrustning)
        {

        }
        
        private string inPutKundSök;
        public string InputKundSök { get => inPutKundSök; set { inPutKundSök = value; OnPropertyChanged(); } }


            #endregion




        
    }
}


