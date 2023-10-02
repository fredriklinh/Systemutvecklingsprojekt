﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationslagerWPF.Services;
using PresentationslagerWPF.Commands;
using PresentationslagerWPF.Views;
using PresentationslagerWPF.Stores;
using PresentationslagerWPF.Models;
using Affärslager;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Entiteter.Tjänster;
using Entiteter.Prislistor;
using Affärslager.KundKontroller;
using Entiteter.Personer;

namespace PresentationslagerWPF.ViewModels
{
    public class MasterBokningViewModel : ObservableObject
    {
        #region Kontrollers
        BokningsKontroller bokningsKontroller = new BokningsKontroller();
        PrisKontroller prisKontroller = new PrisKontroller();
        PrivatkundKontroller privatkundKontroller = new PrivatkundKontroller();
        FöretagskundKontroller företagskundKontroller = new FöretagskundKontroller();

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


        private string inputOrt;
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


        //private Privatkund bajs = null!;
        //public Privatkund Bajs
        //{
        //    get { return bajs; }
        //    set
        //    {
        //        bajs = value; OnPropertyChanged();

        //        if (bajs == null)
        //        {

        //        }
        //    }
        //}





        private Företagskund företagskund = null!;
        public Företagskund Företagskund { get => företagskund; set { företagskund = value; OnPropertyChanged(); } }

        private PrislistaLogi prislistaLogi = null!;
        public PrislistaLogi PrislistaLogi { get => prislistaLogi; set { prislistaLogi = value; OnPropertyChanged(); } }

        private double? totalPris;
        public double? TotalPris { get => totalPris; set { totalPris = value; OnPropertyChanged(); } }

        private Logi tillgänligLogiSelectedItem = null!;
        public Logi TillgänligLogiSelectedItem { 
            get => tillgänligLogiSelectedItem; 
            set { tillgänligLogiSelectedItem = value; OnPropertyChanged();
                if (TillgänligLogiSelectedItem != null)
                {
                    TotalPris = prisKontroller.BeräknaPrisLogi(TillgänligLogiSelectedItem.Typen, Starttid, Sluttid, Privatkund);
                }
            } }

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

        private int valdLogiSelectedIndex;
        public int ValdLogiSelectedIndex { get => valdLogiSelectedIndex; set { valdLogiSelectedIndex = value; OnPropertyChanged(); } }

        private bool isNotModified = true;
        public bool IsNotModified { get { return isNotModified; } set { isNotModified = value; OnPropertyChanged(); } }

        private bool avbeställningsskydd = true;
        public bool Avbeställningsskydd { get { return avbeställningsskydd; } set { avbeställningsskydd = value; OnPropertyChanged(); } }
        #endregion

        #region Obervible Collections 
        private ObservableCollection<Logi> tillgänligLogi = null!;
        public ObservableCollection<Logi> TillgänligLogi { get => tillgänligLogi; set { tillgänligLogi = value; OnPropertyChanged(); } }

        private ObservableCollection<Kund> kund = null!;
        public ObservableCollection<Kund> Kund { get => kund; set { kund = value; OnPropertyChanged(); } }

        private ObservableCollection<Logi> valdLogi = null!;
        public ObservableCollection<Logi> ValdLogi { 
            get => valdLogi; 
            set { 
                valdLogi = value; OnPropertyChanged();

            } }


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
        public MasterBokningViewModel(NavigationStore navigationStore, Användare användare)
        {
            //Tillbaka = new NavigateCommand<HuvudMenyViewModel>(new NavigationService<HuvudMenyViewModel>(navigationStore, () => new HuvudMenyViewModel(navigationStore)));
            Användare = användare;
        }
        public MasterBokningViewModel()
        {
            
        }

        

        #region Icommands
        private ICommand hämtaBokningCommand = null!;
        public ICommand HämtaBokningCommand => hämtaBokningCommand ??= hämtaBokningCommand = new RelayCommand(() =>
        {
            TillgänligLogi = new ObservableCollection<Logi>(bokningsKontroller.HämtaTillgängligLogi(Starttid, Sluttid));
            ValdLogi = new ObservableCollection<Logi>();

        });

        private ICommand läggTillCommand = null!;
        public ICommand LäggTillCommand => läggTillCommand ??= läggTillCommand = new RelayCommand(() =>
        {
            
            if (tillgänligLogiSelectedItem != null)
            {
                Logi logi = tillgänligLogiSelectedItem;
                ValdLogi.Add(logi);
                TillgänligLogi.Remove(logi);
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
                double resKostnad = 0;
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
                InputAdress = Privatkund.Adress;
                InputPostnummer = Privatkund.Postnummer;
                InputOrt = Privatkund.Ort;
                InputTelefonnummer = Privatkund.Telefonnummer;
                InputMailAdress = Privatkund.MailAdress;
                Kundnummer = Privatkund.Personnummer;
                InputFörnamn = Privatkund.Förnamn;
                InputEfternamn = Privatkund.Efternamn;
            }

        });
        private ICommand spara = null!;
        public ICommand Spara => spara ??= spara = new RelayCommand(() =>
        {
            
            if (Privatkund == null)
            {

                Privatkund = privatkundKontroller.RegistreraPrivatKund(InputAdress, InputPostnummer, InputOrt, InputTelefonnummer, InputMailAdress, Kundnummer, InputFörnamn, InputEfternamn); ;
                bokningsKontroller.SkapaMasterbokningPrivatkund(true, Starttid, Sluttid, ValdLogi, Privatkund, Användare);
                valdLogi.Clear();
            }
            else
            {

                bokningsKontroller.SkapaMasterbokningPrivatkund(true, Starttid, Sluttid, ValdLogi, Privatkund, Användare);
            }

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
                    TotalPris = prisKontroller.BeräknaPrisLogi(tabortLogi.Typen, Starttid, Sluttid, Privatkund);
                }
                TillgänligLogi.Add(tabortLogi);
                ValdLogi.Remove(tabortLogi);
                //Ta bort bäddar totalt
                int res = 0;
                if (ValdLogi != null)
                {
                    for (var i = 0; i < ValdLogi.Count; i++)
                    {
                        res = ValdLogi[i].Bäddar;
                    }
                }
                
                TotalKostnad = TotalKostnad - TotalPris;
                AntalSovplatser = AntalSovplatser - res;
            }
        });
        #endregion

    }
}
