﻿using Affärslager;
using Entiteter.Personer;
using Entiteter.Tjänster;
using PresentationslagerWPF.Commands;
using PresentationslagerWPF.Models;
using PresentationslagerWPF.Services;
using PresentationslagerWPF.Stores;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace PresentationslagerWPF.ViewModels
{

    public class SkidshopViewModel : ObservableObject
    {


        UtrustningsKontroller utrustningsKontroller = new UtrustningsKontroller();
        LektionsKontroller lektionsKontroller = new LektionsKontroller();




        #region ObservableColletion Utrustning
        //TABORT
        private ObservableCollection<Utrustning> alpint = null!;
        public ObservableCollection<Utrustning> Alpint
        {
            get => alpint; set
            {
                alpint = value; OnPropertyChanged();
            }
        }

        private ObservableCollection<Utrustning> hjälm = null!;
        public ObservableCollection<Utrustning> Hjälm
        {
            get => hjälm; set
            {

                hjälm = value; OnPropertyChanged();
                Antal = RäknaAntal(Hjälm);
            }
        }
        private ObservableCollection<Utrustning> längd = null!;
        public ObservableCollection<Utrustning> Längd
        {
            get => längd; set
            {
                längd = value; OnPropertyChanged();
            }
        }
        private ObservableCollection<Utrustning> snöskoter = null!;
        public ObservableCollection<Utrustning> Snöskoter
        {
            get => snöskoter; set
            {
                snöskoter = value; OnPropertyChanged();
            }
        }

        private ObservableCollection<Utrustning> snowboard = null!;
        public ObservableCollection<Utrustning> Snowboard
        {
            get => snowboard; set
            {
                snowboard = value; OnPropertyChanged();
                SnowboardBoard = new ObservableCollection<Utrustning>(snowboard.Where(i => i.Benämning == "Snowboard"));
            }
        }
        private ObservableCollection<Utrustning> snowboardBoard = null!;
        public ObservableCollection<Utrustning> SnowboardBoard
        {
            get => snowboardBoard; set
            {
                snowboardBoard = value; OnPropertyChanged();


                int nummer = Antal.Count;

                int iteration = 0;
                foreach (Utrustning item in Snowboard)
                {
                    iteration++;
                    if (iteration >= nummer)
                    {
                        break;
                    }
                    //ValdUtrustningTillBokning.Add(item);
                };
            }
        }

        #endregion

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

        private List<int> antal;
        public List<int> Antal
        {
            get { return antal; }
            set { antal = value; OnPropertyChanged(); }
        }

        private List<string> stringTyp;
        public List<string> StringTyp
        {


            get { return stringTyp; }
            set
            {
                stringTyp = value; OnPropertyChanged();




            }
        }






        #region NAVIGATION

        //**** NAVIGATION *******//

        public SkidshopViewModel(NavigationStore navigationStore, Användare användare)
        {
            TillbakaCommand = new NavigateCommand<HuvudMenyViewModel>(new NavigationService<HuvudMenyViewModel>(navigationStore, () => new HuvudMenyViewModel(navigationStore, användare)));


            AllaUtrustningar = new ObservableCollection<Utrustning>(utrustningsKontroller.HämtaTillgängligUtrustning());
            //Alpint = new ObservableCollection<Utrustning>(allaUtrustningar.Where(i => i.UtrustningsTyp.Typ == "Alpint")); //Pjäxor, Stavar, Skidor
            //Snowboard = new ObservableCollection<Utrustning>(allaUtrustningar.Where(i => i.UtrustningsTyp.Typ == "Snowboard")); //Snowboard, Snowboardboots
            //Längd = new ObservableCollection<Utrustning>(allaUtrustningar.Where(i => i.UtrustningsTyp.Typ == "Längd")); //Pjäxor, Stavar, Skidor
            //Snöskoter = new ObservableCollection<Utrustning>(allaUtrustningar.Where(i => i.UtrustningsTyp.Typ == "Snöskoter")); //Skoter 1, Skoter 2, Pulka
            Hjälm = new ObservableCollection<Utrustning>(allaUtrustningar.Where(i => i.UtrustningsTyp.Typ == "Hjälm")); // Hjälm

            //HÄR
            ValdUtrustningTillBokning = new ObservableCollection<Utrustning>();
            AntalTestList = new ObservableCollection<Antal>();
            UnikBenämning = AllaUtrustningar
                                .GroupBy(i => i.Typ)
                                .Select(group => group.First())
                                .ToList();

        }
        private Utrustning selectedItemUtrustning = null!;
        public Utrustning SelectedItemUtrustning
        {
            get => selectedItemUtrustning; set
            {
                selectedItemUtrustning = value; OnPropertyChanged();

                //UnikTyp = AllaUtrustningar
                //.Where(i => i.Typ == SelectedItemUtrustning.Typ).Distinct().Select(group => group.First())
                //.ToList();

                var test123 = AllaUtrustningar
                    .Where(i => i.Typ == SelectedItemUtrustning.Typ)
                    .Distinct()
                    .ToList();

                UnikTyp = test123
                    .GroupBy(i => i.Benämning)
                    .Select(group => group.First())
                    .ToList();
            }
        }
        private List<Utrustning> unikTyp = null!;
        public List<Utrustning> UnikTyp
        {
            get => unikTyp; set
            {
                unikTyp = value; OnPropertyChanged();
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

        public ICommand TillbakaCommand { get; }

        //**** SKIDLEKTION *******//
        private ObservableCollection<Elev> elev = null!;
        public ObservableCollection<Elev> Elev { get => elev; set { elev = value; OnPropertyChanged(); } }

        private ObservableCollection<GruppLektion> gruppLektion = null!;
        public ObservableCollection<GruppLektion> GruppLektion { get => gruppLektion; set { gruppLektion = value; OnPropertyChanged(); } }

        private ObservableCollection<PrivatLektion> privatLektion = null!;
        public ObservableCollection<PrivatLektion> PrivatLektion { get => privatLektion; set { privatLektion = value; OnPropertyChanged(); } }

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
                lektionsKontroller.RegistreraElev(InFörnamn, InEfternamn);
            }
            if (PrivatLektion != null && InFörnamn != string.Empty && InEfternamn != string.Empty)
            {
                lektionsKontroller.RegistreraElev(InFörnamn, InEfternamn);
                lektionsKontroller.BokaPrivatLektion(SelectedPrivat);
            }
            if (GruppLektion != null && InFörnamn != string.Empty && InEfternamn != string.Empty)
            {

            }
        });
        #endregion


        private int testAntalSelected;
        public int TestAntalSelected
        {
            get { return testAntalSelected; }
            set { testAntalSelected = value; OnPropertyChanged(); }
        }

        private ICommand utrustningCommand = null!;
        public ICommand UtrustningCommandSkidor => utrustningCommand ??= utrustningCommand = new RelayCommand(() =>
        {

            int värde = TestAntalSelected;
            int iteration = 0;
            Utrustning TestHjälm = new Utrustning();
            foreach (var item in Hjälm)
            {
                TestHjälm = item;
            }
            Antal antal = new Antal(värde, TestHjälm, TestHjälm.Benämning, TestHjälm.Typ);
            if (Antal != null)
            {
                AntalTestList.Add(antal);
                //ValdUtrustningTillBokning.Add(utrustning);

            }

        });

        private int antalTestint;
        public int AntalTestint
        {
            get { return antalTestint; }
            set
            {
                antalTestint = value; OnPropertyChanged();



            }
        }

        private ICommand utrustningCommandSnowboard = null!;
        public ICommand UtrustningCommandSnowboard => utrustningCommandSnowboard ??= utrustningCommandSnowboard = new RelayCommand(() =>
        {

            int värde = TestAntalSelected;

            Utrustning TestSnowboard = new Utrustning();
            foreach (var item in Hjälm)
            {
                TestSnowboard = item;
            }
            Antal antal = new Antal(värde, TestSnowboard, TestSnowboard.Benämning, TestSnowboard.Typ);
            if (Antal != null)
            {
                AntalTestList.Add(antal);
                //ValdUtrustningTillBokning.Add(utrustning);
            }
        });

        private Antal antalTest = null!;
        public Antal AntalTest
        {
            get => antalTest;
            set
            {
                antalTest = value; OnPropertyChanged();

            }
        }
        private ObservableCollection<Antal> antalTestList = null!;
        public ObservableCollection<Antal> AntalTestList
        {
            get => antalTestList; set
            {
                antalTestList = value; OnPropertyChanged();
            }
        }


    }

    public class Antal
    {
        public Antal(int antal, Utrustning propUtrustning, string typ, string benämning)
        {
            Value = antal;
            PropUtrustning = propUtrustning;
            Typ = typ;
            Benämning = benämning;
        }

        public int Value { get; set; }

        public Utrustning PropUtrustning { get; set; }

        public string Typ { get; set; }

        public string Benämning { get; set; }

    }
}


