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
using Affärslager.KundKontroller;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Entiteter.Tjänster;
using Entiteter.Personer;



namespace PresentationslagerWPF.ViewModels
{
    public class MasterBokningViewModel : ObservableObject
    {
        #region Kontrollers
        BokningsKontroller bokningsKontroller = new BokningsKontroller();
        PrivatkundKontroller privatkundKontroller = new PrivatkundKontroller();
        PrisKontroller prisKontroller = new PrisKontroller();

        #endregion

        #region On property change
        private DateTime starttid = DateTime.Now;
        public DateTime Starttid { get => starttid; set { starttid = value; OnPropertyChanged(); } }

        private DateTime sluttid;
        public DateTime Sluttid { get => sluttid; set { sluttid = value; OnPropertyChanged(); } }
        
        private long kundnummer;
        public long Kundnummer { get => kundnummer;  set { kundnummer = value; OnPropertyChanged(); } }

        private Privatkund privatkund = null!;
        public Privatkund Privatkund { get => privatkund; set { privatkund = value; OnPropertyChanged(); } }

        private Företagskund företagskund = null!;
        public Företagskund Företagskund { get => företagskund; set { företagskund = value; OnPropertyChanged(); } }





        #endregion

        #region Obervible Collections 
        private ObservableCollection<Logi> tillgänliglogi = null!;
        public ObservableCollection<Logi> Tillgänliglogi { get => tillgänliglogi; set { tillgänliglogi = value; OnPropertyChanged(); } }

        //private ObservableCollection<Privatkund> privatkund = null!;
        //public ObservableCollection<Privatkund> Privatkund { get => privatkund; set { privatkund= value; OnPropertyChanged(); } }   



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
            Tillgänliglogi = new ObservableCollection<Logi>(bokningsKontroller.HämtaTillgängligLogi(Starttid, Sluttid));
            

        });

        private ICommand sökKund = null!;
        public ICommand SökKund => sökKund ??= sökKund = new RelayCommand(() =>
        {

            Privatkund = new ObservableCollection<Privatkund>(privatkundKontroller.SökPrivatkund(Kundnummer));
        });

        #endregion

    }
}
