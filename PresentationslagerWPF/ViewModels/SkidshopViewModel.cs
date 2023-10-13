using Affärslager;
using Affärslager.KundKontroller;
using Entiteter.Personer;
using Entiteter.Tjänster;
using Microsoft.Identity.Client;
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


        #region Observable Collection 



        private ObservableCollection<Utrustning> allaUtrustningar = null!;
        public ObservableCollection<Utrustning> AllaUtrustningar
        {
            get => allaUtrustningar; set
            {
                allaUtrustningar = value; OnPropertyChanged();
                //List<Utrustning> hej123 = utrustningsKontroller.SökBenämningTyp();
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
        {
            get { return antal; }
            set { antal = value; OnPropertyChanged(); }
        }


        #region NAVIGATION
        //**** NAVIGATION *******//

        public SkidshopViewModel(NavigationStore navigationStore, Användare användare)
        {
            TillbakaCommand = new NavigateCommand<HuvudMenyViewModel>(new NavigationService<HuvudMenyViewModel>(navigationStore, () => new HuvudMenyViewModel(navigationStore, användare)));
            
            AllaUtrustningar = new ObservableCollection<Utrustning>(utrustningsKontroller.HämtaTillgängligUtrustning());

            //Benämning ObservableCollection
            BenämningAlpin = new ObservableCollection<Utrustning>(utrustningsKontroller.SökBenämning("Alpint"));


            ValdUtrustningTillBokning = new ObservableCollection<Utrustning>();
            AntalTestList = new ObservableCollection<DisplayUtrustning>();
            //UnikBenämning = AllaUtrustningar
            //                    .GroupBy(i => i.Typ)
            //                    .Select(group => group.First())
            //                    .ToList();
        }
        public ICommand TillbakaCommand { get; }

        #endregion



        #region AntalInt

        private ObservableCollection<int> antalAlpin;
        public ObservableCollection<int> AntalAlping
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

        private Utrustning selectedItemUtrustning = null!;
        public Utrustning SelectedItemUtrustning
        {
            get => selectedItemUtrustning; set
            {
                selectedItemUtrustning = value; OnPropertyChanged();
       
                IList<Utrustning> ListaTyp = utrustningsKontroller.SökTyp(SelectedItemUtrustning);
            }
        }

        #endregion

        private ObservableCollection<Utrustning> benämningAlpin = null!;
        public ObservableCollection<Utrustning> BenämningAlpin
        {
            get => benämningAlpin; set
            {
                benämningAlpin = value; OnPropertyChanged();
                //BenämningAlpin = utrustningsKontroller.SökBenämning("Alpin");

            }
        }

        private List<Utrustning> unikBenämning = null!;
        public List<Utrustning> UnikBenämning
        {
            get => unikBenämning; set
            {
                unikBenämning = value; OnPropertyChanged();
            }
        }



        //**** SKIDLEKTION *******//
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
        public DisplayUtrustning AntalTest
        {
            get => antalTest;
            set
            {
                antalTest = value; OnPropertyChanged();

            }
        }
        private ObservableCollection<DisplayUtrustning> antalTestList = null!;
        public ObservableCollection<DisplayUtrustning> AntalTestList
        {
            get => antalTestList; set
            {
                antalTestList = value; OnPropertyChanged();
            }
        }

        #region Metoder

        public List<int> RäknaAntal(ObservableCollection<Utrustning> utrustnings)
        {
            List<int> antal = new List<int>();
            int steg = 0;
            foreach (Utrustning item in utrustnings)
            {
                if (steg == 50)
                {
                    return antal;
                }
                steg = steg + 1;
                antal.Add(steg);
            }
            return antal;
        }


        public void TilldelaTypUtrustning(Utrustning selectedItemUtrustning)
        {


        private string inPutKundSök;
        public string InputKundSök { get => inPutKundSök; set { inPutKundSök = value; OnPropertyChanged(); } }
        
        
        private ICommand sökKund = null!;
        public ICommand SökKund => sökKund ??= sökKund = new RelayCommand(() =>
        {


        });

        private Antal antalTest = null!;
        public Antal AntalTest
        {
            get => antalTest;
            set
            {
                antalTest = value; OnPropertyChanged();


            //UnikTyp = UtrustningTyp
            //.GroupBy(i => i.Benämning)
            //.Select(group => group.First())
            //.ToList();

        }


        #endregion




    }
}


