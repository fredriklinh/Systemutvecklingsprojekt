using Entiteter.Personer;
using Entiteter.Tjänster;
using PresentationslagerWPF.Models;
using PresentationslagerWPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PresentationslagerWPF.Commands;
using PresentationslagerWPF.Services;
using System.Windows.Markup;
using LiveCharts;
using System.Collections.ObjectModel;
using Affärslager;

namespace PresentationslagerWPF.ViewModels
{
    public class StatistikViewModel : ObservableObject
    {
        #region Kontrollers
        
        StatistikKontroller statistikKontroller = new StatistikKontroller();       
        #endregion

        #region NAVIGATION
        public StatistikViewModel(NavigationStore navigationStore, Användare användare)
        {

            NavigateLoggaUtCommand = new NavigateCommand<LoggaInViewModel>(new NavigationService<LoggaInViewModel>(navigationStore, () => new LoggaInViewModel(navigationStore)));
            TillbakaCommand = new NavigateCommand<HuvudMenyViewModel>(new NavigationService<HuvudMenyViewModel>(navigationStore, () => new HuvudMenyViewModel(navigationStore, användare)));
        }
        public ICommand NavigateLoggaUtCommand { get; }

        private ICommand exitCommand = null!;
        public ICommand ExitCommand =>
        exitCommand ??= exitCommand = new RelayCommand(() => App.Current.Shutdown());

        public ICommand TillbakaCommand { get; }
        #endregion

        #region MasterBokning

        private ObservableCollection<MasterBokning> masterbokningar = null!;
        public ObservableCollection<MasterBokning> Masterbokningar { get => masterbokningar; set { masterbokningar = value; OnPropertyChanged(); } }

        private ObservableCollection<MasterBokning> objekt = null!;
        public ObservableCollection<MasterBokning> Objekt { get => objekt; set { objekt = value; OnPropertyChanged(); } }

        private DateTime valtÅr = DateTime.Now;
        public DateTime ValtÅr { get => valtÅr; set { valtÅr = value; OnPropertyChanged(); } }


        private ObservableCollection<int> årtal = new ObservableCollection<int>
        {
            2020,
            2021,
            2022,
            2023
        };
        public ObservableCollection<int> Årtal { get => årtal; set { årtal = value; OnPropertyChanged(); } }

        private int selectedItemÅr;
        public int SelectedItemÅr
        {
            get => selectedItemÅr;
            set
            {
                selectedItemÅr = value; OnPropertyChanged();
                Objekt = new ObservableCollection<MasterBokning>(statistikKontroller.HämtaAllaBokningar(SelectedItemÅr));
                Totalen = Objekt.Count;


            }
        }
        private int totalen;
        public int Totalen {  get => totalen; set {  totalen = value; OnPropertyChanged();} }





        //private int? År = ValtÅr.Year;
        //public int År { get => år; set => år = value; }





        #endregion

    }


}