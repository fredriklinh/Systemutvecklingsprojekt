using System;
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

namespace PresentationslagerWPF.ViewModels
{
    public class MasterBokningViewModel : ObservableObject
    {
        #region Kontrollers
        BokningsKontroller bokningsKontroller = new BokningsKontroller();
        PrisKontroller prisKontroller = new PrisKontroller();
        #endregion

        #region On property change
        private DateTime starttid = DateTime.Now;
        public DateTime Starttid { get => starttid; set { starttid = value; OnPropertyChanged(); } }

        private DateTime sluttid = DateTime.Now;
        public DateTime Sluttid { get => sluttid; set { sluttid = value; OnPropertyChanged(); } }

        private int? antalSovplatser;
        public int? AntalSovplatser { get => antalSovplatser; set { antalSovplatser = value; OnPropertyChanged(); } }

        private int? totalKostnad;
        public int? TotalKostnad { get => totalKostnad; set { totalKostnad = value; OnPropertyChanged(); } }

        private PrislistaLogi prislistaLogi = null!;
        public PrislistaLogi PrislistaLogi { get => prislistaLogi; set { prislistaLogi = value; OnPropertyChanged(); } }

        private int? totalPris;
        public int? TotalPris { get => totalPris; set { totalPris = value; OnPropertyChanged(); } }

        private Logi tillgänligLogiSelectedItem = null!;
        public Logi TillgänligLogiSelectedItem { 
            get => tillgänligLogiSelectedItem; 
            set { tillgänligLogiSelectedItem = value; OnPropertyChanged();
                if (TillgänligLogiSelectedItem != null)
                {
                    TotalPris = prisKontroller.BeräknaPrisLogi(TillgänligLogiSelectedItem.LogiNamn, Starttid, Sluttid);
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
        #endregion

        #region Obervible Collections 
        private ObservableCollection<Logi> tillgänligLogi = null!;
        public ObservableCollection<Logi> TillgänligLogi { get => tillgänligLogi; set { tillgänligLogi = value; OnPropertyChanged(); } }

        private ObservableCollection<Logi> valdLogi = null!;
        public ObservableCollection<Logi> ValdLogi { 
            get => valdLogi; 
            set { 
                valdLogi = value; OnPropertyChanged();

            } }

        #endregion
        public MasterBokningViewModel(NavigationStore navigationStore)
        {
                
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
                int resKostnad = 0;
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

        private ICommand taBortCommand = null!;
        public ICommand TaBortCommand => taBortCommand ??= taBortCommand = new RelayCommand(() =>
        {
            if (valdLogiSelectedItem != null)
            {
                Logi tabortLogi = ValdLogiSelectedItem;
                //Ta bort kostnad
                if (tabortLogi != null)
                {
                    TotalPris = prisKontroller.BeräknaPrisLogi(tabortLogi.LogiNamn, Starttid, Sluttid);
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
