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

        #endregion

        #region On property change
        private DateTime starttid = DateTime.Now;
        public DateTime Starttid { get => starttid; set { starttid = value; OnPropertyChanged(); } }

        private DateTime sluttid = DateTime.Now;
        public DateTime Sluttid { get => sluttid; set { sluttid = value; OnPropertyChanged(); } }

        private long kundnummer;
        public long Kundnummer { get => kundnummer; set { kundnummer = value; OnPropertyChanged(); } }

        private Privatkund privatkund = null!;
        public Privatkund Privatkund { get => privatkund; set { privatkund = value; OnPropertyChanged(); } }

        private Företagskund företagskund = null!;
        public Företagskund Företagskund { get => företagskund; set { företagskund = value; OnPropertyChanged(); } }

        private PrislistaLogi prislistaLogi = null!;
        public PrislistaLogi PrislistaLogi { get => prislistaLogi; set { prislistaLogi = value; OnPropertyChanged(); } }

        private int totalPris;
        public int TotalPris { get => totalPris; set { totalPris = value; OnPropertyChanged(); } }

        private Logi tillgänligLogiSelectedItem = null!;
        public Logi TillgänligLogiSelectedItem
        {
            get => tillgänligLogiSelectedItem;
            set
            {
                tillgänligLogiSelectedItem = value; OnPropertyChanged();
                TotalPris = prisKontroller.BeräknaPrisLogi(TillgänligLogiSelectedItem.Typen, Starttid, Sluttid);
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

        private int valdLogiSelectedIndex;
        public int ValdLogiSelectedIndex { get => valdLogiSelectedIndex; set { valdLogiSelectedIndex = value; OnPropertyChanged(); } }

        #endregion

        #region Obervible Collections 
        private ObservableCollection<Logi> tillgänligLogi = null!;
        public ObservableCollection<Logi> TillgänligLogi { get => tillgänligLogi; set { tillgänligLogi = value; OnPropertyChanged(); } }


        #endregion
        public MasterBokningViewModel(NavigationStore navigationStore)
        {
            //Tillbaka = new NavigateCommand<HuvudMenyViewModel>(new NavigationService<HuvudMenyViewModel>(navigationStore, () => new HuvudMenyViewModel(navigationStore)));

        }
        public MasterBokningViewModel()
        {
            
        }



        #region Icommands
        private ICommand hämtaBokningCommand = null!;
        public ICommand HämtaBokningCommand => hämtaBokningCommand ??= hämtaBokningCommand = new RelayCommand(() =>
        {
            TillgänligLogi = new ObservableCollection<Logi>(bokningsKontroller.HämtaTillgängligLogi(Starttid, Sluttid));
            

        });

        private ICommand sökKund = null!;
        public ICommand SökKund => sökKund ??= sökKund = new RelayCommand(() =>
        {

            //Privatkund = new ObservableCollection<Privatkund>(privatkundKontroller.SökPrivatkund(Kundnummer));
        });
        #endregion

    }
}
