﻿using Affärslager;
using Entiteter.Personer;
using Entiteter.Tjänster;
using Microsoft.VisualBasic;
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

        #region Observable Collection 


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

        #region NAVIGATION
        //**** NAVIGATION *******//

        public SkidshopViewModel(NavigationStore navigationStore, Användare användare)
        {
            TillbakaCommand = new NavigateCommand<HuvudMenyViewModel>(new NavigationService<HuvudMenyViewModel>(navigationStore, () => new HuvudMenyViewModel(navigationStore, användare)));

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
        }

        public ICommand TillbakaCommand { get; }

        #endregion

        #region Properties Utrustning + Datum

        private string inputBokningsNr;
        public string InputBokningsNr
        {
            get => inputBokningsNr; set
            {

            }
        }


        private DateTime inlämning = DateTime.Now;
        public DateTime Inlämning
        {
            get => inlämning; set
            {
                inlämning = value; OnPropertyChanged();
                TotalDisplayUtrustning.Clear();
                if (Inlämning < DateTime.Now)
                {
                    MessageBox.Show("Datum är inkorrekt", "Bokning", MessageBoxButton.OK);
                    IsEnabledUtrustning = false;
                }
                else
                {
                    IsEnabledUtrustning = true;
                    GruppLektioner = new ObservableCollection<GruppLektion>(lektionsKontroller.AllaGruppLektion());
                    PrivatLektioner = new ObservableCollection<PrivatLektion>(lektionsKontroller.AllaPrivatLektion());
                }

            }
        }



        #endregion

        #region Commands

        private ICommand sparaCommand = null!;
        public ICommand SparaCommand => sparaCommand ??= sparaCommand = new RelayCommand(() =>
        {
            List<Utrustning> hämtadUtrustning = new List<Utrustning>();
            foreach (var item in TotalDisplayUtrustning)
            {

                hämtadUtrustning.Concat(utrustningsKontroller.HittaUtrustning(item.Value, item.Typ, item.Benämning, Inlämning));

            }
            //utrustningsKontroller.SkapaUtrustningsBokningPrivat(hämtadUtrustning, DateTime.Now, Inlämning, Privatkund, användare, //Summa );
        });
        private ICommand taBortCommand = null!;
        public ICommand TaBortCommand => taBortCommand ??= taBortCommand = new RelayCommand(() =>
        {
            TotalDisplayUtrustning.Remove(SelectedItemDisplayUtrustning);
        });

        private ICommand accepteraÅterlämningCommand = null!;
        public ICommand AccepteraÅterlämningCommand => accepteraÅterlämningCommand ??= accepteraÅterlämningCommand = new RelayCommand(() =>
        {
            utrustningsKontroller.FullbordaÅterlämning(InputBokningsNr.ToString());
        });


        private ICommand återlämnaUtrustningCommand = null!;
        public ICommand ÅterlämnaUtrustningCommand => återlämnaUtrustningCommand ??= återlämnaUtrustningCommand = new RelayCommand(() =>
        {
            string input = Interaction.InputBox("Ange Bokningsnummer", "Återlämmning", "Default", 50, 50);
            MasterBokning bokningNrExiterar = utrustningsKontroller.BokningExisterar(input);
            if (bokningNrExiterar == null) MessageBox.Show("Bokning Existerar Ej", "Bokning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            else
            {
                InputBokningsNr = input;
                int antalUtrustningar = bokningNrExiterar.UtrustningsBokningar.Count();
                List<Utrustning> bokningsUtrustning = new List<Utrustning>();
                foreach (var item in bokningNrExiterar.UtrustningsBokningar)
                {
                    foreach (Utrustning utrustning in item.Utrustningar)
                    {
                        bokningsUtrustning.Add(utrustning);

                    }
                }
                List<Utrustning> query = bokningsUtrustning
               .GroupBy(i => i.Benämning)
               .Select(group => group.First())
               .ToList();
                foreach (Utrustning item in query)
                {
                    TotalDisplayUtrustning.Add(new DisplayUtrustning(antalUtrustningar, item, item.Typ, item.Benämning, 0));
                }
            }
        });

        private ICommand läggTillAlpinCommand = null!;
        public ICommand LäggTillAlpinCommand => läggTillAlpinCommand ??= läggTillAlpinCommand = new RelayCommand(() =>
        {
            if (AntalAlpin.Count == 0) ;
            else
            {
                TotalDisplayUtrustning.Add(new DisplayUtrustning(SelectedItemAntalAlpin, SelectedItemAlpin, SelectedItemAlpin.UtrustningsTyp.Typ, SelectedItemAlpin.Benämning, SummaAlpin));
                AntalAlpin.Clear();
                SummaAlpin = 0;

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
            }
        });

        private ICommand läggTillPaketCommand = null!;
        public ICommand LäggTillPaketCommand => läggTillPaketCommand ??= läggTillPaketCommand = new RelayCommand(() =>
        {

            TotalDisplayUtrustning.Add(new DisplayUtrustning(SelectedItemAntalPaket, SelectedItemPaket, SelectedItemPaket.UtrustningsTyp.Typ, SelectedItemPaket.Benämning, SummaPaket));
            AntalPaket.Clear();
            SummaPaket = 0;

        });

        #endregion

        #region SUMMA
        private int summaTotal;
        public int SummaTotal
        {
            get { return summaTotal; }
            set { summaTotal = value; OnPropertyChanged(); }


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

        #region SELECTEDITEM

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
                if (IsEnabledAntalAlpin) AntalAlpin = utrustningsKontroller.SökBenämningTyp(SelectedItemAlpin.Benämning, SelectedItemAlpin.Typ, Inlämning);
            }
        }

        private Utrustning selectedItemSnowboard = null!;
        public Utrustning SelectedItemSnowboard
        {
            get => selectedItemSnowboard; set
            {
                selectedItemSnowboard = value; OnPropertyChanged();

                IsEnabledAntalSnowboard = ÄrRedanIBokning(SelectedItemSnowboard);
                if (IsEnabledAntalSnowboard) AntalSnowboard = utrustningsKontroller.SökBenämningTyp(SelectedItemSnowboard.Benämning, SelectedItemSnowboard.Typ, Inlämning);
            }
        }
        private Utrustning selectedItemLängd = null!;
        public Utrustning SelectedItemLängd
        {
            get => selectedItemLängd; set
            {
                selectedItemLängd = value; OnPropertyChanged();
                IsEnabledAntalSnowboard = ÄrRedanIBokning(SelectedItemLängd);
                if (IsEnabledAntalSnowboard) AntalLängd = utrustningsKontroller.SökBenämningTyp(SelectedItemLängd.Benämning, SelectedItemLängd.Typ, Inlämning);
            }
        }
        private Utrustning selectedItemHjälm = null!;
        public Utrustning SelectedItemHjälm
        {
            get => selectedItemHjälm; set
            {
                selectedItemHjälm = value; OnPropertyChanged();
                IsEnabledAntalHjälm = ÄrRedanIBokning(SelectedItemHjälm);
                if (IsEnabledAntalHjälm) AntalHjälm = utrustningsKontroller.SökBenämningTyp(SelectedItemHjälm.Benämning, SelectedItemHjälm.Typ, Inlämning);
            }
        }
        private Utrustning selectedItemSkoter = null!;
        public Utrustning SelectedItemSkoter
        {
            get => selectedItemSkoter; set
            {
                selectedItemSkoter = value; OnPropertyChanged();
                IsEnabledAntalSkoter = ÄrRedanIBokning(SelectedItemSkoter);
                if (IsEnabledAntalSkoter) AntalSkoter = utrustningsKontroller.SökBenämningTyp(SelectedItemSkoter.Benämning, SelectedItemSkoter.Typ, Inlämning);
            }
        }
        private Utrustning selectedItemPaket = null!;
        public Utrustning SelectedItemPaket
        {
            get => selectedItemPaket; set
            {
                selectedItemPaket = value; OnPropertyChanged();
                IsEnabledAntalSkoter = ÄrRedanIBokning(SelectedItemPaket);
                if (IsEnabledAntalPaket) AntalPaket = utrustningsKontroller.SökPaketTyp(SelectedItemPaket.Benämning, SelectedItemPaket.Typ, Inlämning);
            }
        }

        #endregion

        #region Metoder

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
        public void LaddaOmSida()
        {
            TotalDisplayUtrustning.Clear();
            IsEnabledAntalAlpin = true;
            TypAlpin.Clear();
            AntalAlpin.Clear();
        }
        #endregion

        #region SELECTED INT

        private int selectedItemAntalAlpin;
        public int SelectedItemAntalAlpin
        {
            get => selectedItemAntalAlpin; set
            {
                selectedItemAntalAlpin = value; OnPropertyChanged();
                SummaAlpin = priskontroller.BeräknaPrisUtrustning(SelectedItemAntalAlpin, SelectedItemAlpin.Typ, SelectedItemAlpin.Benämning, Inlämning);

            }
        }

        private int selectedItemAntalSnowboard;
        public int SelectedItemAntalSnowboard
        {
            get => selectedItemAntalSnowboard; set
            {
                selectedItemAntalSnowboard = value; OnPropertyChanged();

                SummaSnowboard = priskontroller.BeräknaPrisUtrustning(SelectedItemAntalSnowboard, SelectedItemSnowboard.Typ, SelectedItemSnowboard.Benämning, Inlämning);

            }
        }
        private int selectedItemAntalLängd;
        public int SelectedItemAntalLängd
        {
            get => selectedItemAntalLängd; set
            {
                selectedItemAntalLängd = value; OnPropertyChanged();

                SummaLängd = priskontroller.BeräknaPrisUtrustning(SelectedItemAntalLängd, SelectedItemLängd.Typ, SelectedItemLängd.Benämning, Inlämning);
            }
        }


        private int selectedItemAntalHjälm;
        public int SelectedItemAntalHjälm
        {
            get => selectedItemAntalHjälm; set
            {
                selectedItemAntalHjälm = value; OnPropertyChanged();

                SummaHjälm = priskontroller.BeräknaPrisUtrustning(SelectedItemAntalHjälm, SelectedItemHjälm.Typ, SelectedItemHjälm.Benämning, Inlämning);
            }
        }
        private int selectedItemAntalSkoter;
        public int SelectedItemAntalSkoter
        {
            get => selectedItemAntalSkoter; set
            {
                selectedItemAntalSkoter = value; OnPropertyChanged();

                SummaSkoter = priskontroller.BeräknaPrisUtrustning(SelectedItemAntalSkoter, SelectedItemSkoter.Typ, SelectedItemSkoter.Benämning, Inlämning);
            }
        }
        private int selectedItemAntalPaket;
        public int SelectedItemAntalPaket
        {
            get => selectedItemAntalPaket; set
            {
                selectedItemAntalPaket = value; OnPropertyChanged();

                SummaPaket = priskontroller.BeräknaPrisUtrustning(SelectedItemAntalPaket, SelectedItemPaket.Typ, SelectedItemPaket.Benämning, Inlämning);
            }
        }


        #endregion

        #region SKIDLEKTION ............
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
        private ObservableCollection<Elev> eleverna = null!;
        public ObservableCollection<Elev> Eleverna
        {
            get => eleverna;
            set
            {
                eleverna = value; OnPropertyChanged();
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

            GruppLektion gLektion = SelectedGrupp;
            PrivatLektion pLektion = SelectedPrivat;
            Elev e = ElevTillLektion;
            
            if (SelectedPrivat != null && InFörnamn != string.Empty && InEfternamn != string.Empty)
            {
                ElevTillLektion = lektionsKontroller.RegistreraElev(InFörnamn, InEfternamn);
                lektionsKontroller.BokaPrivatLektion(e, pLektion);
                Eleverna = new ObservableCollection<Elev>(lektionsKontroller.HämtaDeltagareFrånLektionP(pLektion));
            }
            if (SelectedGrupp != null && InFörnamn != string.Empty && InEfternamn != string.Empty)
            {
                ElevTillLektion = lektionsKontroller.RegistreraElev(InFörnamn, InEfternamn);
                lektionsKontroller.BokaGruppLektion(e, gLektion);
                Eleverna = new ObservableCollection<Elev>(lektionsKontroller.HämtaDeltagareFrånLektionG(gLektion));
            }
           
        });
        #endregion


        //private DisplayUtrustning antalTest = null!;
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



        private string inPutKundSök;
        public string InputKundSök { get => inPutKundSök; set { inPutKundSök = value; OnPropertyChanged(); } }






    }
}


