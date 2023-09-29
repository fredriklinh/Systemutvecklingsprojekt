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
        
        private PrislistaLogi prislistaLogi = null!;
        public PrislistaLogi PrislistaLogi { get => prislistaLogi; set { prislistaLogi = value; OnPropertyChanged(); } }

        private int totalPris;
        public int TotalPris { get => totalPris; set { totalPris = value; OnPropertyChanged(); } }

        private Logi tillgänliglogiSelectedItem = null!;
        public Logi TillgänliglogiSelectedItem { 
            get => tillgänliglogiSelectedItem; 
            set { tillgänliglogiSelectedItem = value; OnPropertyChanged();
                TotalPris = prisKontroller.BeräknaPrisLogi(TillgänliglogiSelectedItem.LogiNamn, Starttid, Sluttid);
            } }

        private int tillgänliglogiSelectedIndex;
        public int TillgänliglogiSelectedIndex { get => tillgänliglogiSelectedIndex; set { tillgänliglogiSelectedIndex = value; OnPropertyChanged(); } }

        #endregion

        #region Obervible Collections 
        private ObservableCollection<Logi> tillgänliglogi = null!;
        public ObservableCollection<Logi> Tillgänliglogi { get => tillgänliglogi; set { tillgänliglogi = value; OnPropertyChanged(); } }

        
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
        
        #endregion

    }
}
