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
            DisplayStatistik = new ObservableCollection<DisplayStatistik>();
            Årtal = new ObservableCollection<int>(statistikKontroller.HämtaÅr());
        }
        public ICommand NavigateLoggaUtCommand { get; }

        private ICommand exitCommand = null!;
        public ICommand ExitCommand =>
        exitCommand ??= exitCommand = new RelayCommand(() => App.Current.Shutdown());

        public ICommand TillbakaCommand { get; }
        #endregion

        #region MasterBokning

        private int totalen;
        public int Totalen { get => totalen; set { totalen = value; OnPropertyChanged(); } }

        private ObservableCollection<MasterBokning> masterbokningar = null!;
        public ObservableCollection<MasterBokning> Masterbokningar { get => masterbokningar; set { masterbokningar = value; OnPropertyChanged(); } }



        private ObservableCollection<DisplayStatistik> displayStatistik = null!;
        public ObservableCollection<DisplayStatistik> DisplayStatistik { get => displayStatistik; set { displayStatistik = value; OnPropertyChanged(); } }

        private ObservableCollection<int> årtal = null!;
        public ObservableCollection<int> Årtal { get => årtal; set { årtal = value; OnPropertyChanged(); } }

        private int selectedItemÅr;
        public int SelectedItemÅr
        {
            get => selectedItemÅr;
            set
            {
                selectedItemÅr = value; OnPropertyChanged();
                DisplayStatistik.Clear();
                List<string> typAvLogier = statistikKontroller.HämtaUnikaBenämningarLogi();
                foreach (var item in typAvLogier)
                {
                    List<Dictionary<int, int>> bokningarPerMånad = statistikKontroller.HämtaAntalBokningarLogi(item, selectedItemÅr);
                    PopuleraDisplayLogi(bokningarPerMånad, item);

                }
                

            }
        }
        public void PopuleraDisplayLogi(List<Dictionary<int, int>> bokningarPerMånad, string logityp)
        {
            DisplayStatistik statistikLogi = new DisplayStatistik();
            foreach (var item in bokningarPerMånad)
            {
                statistikLogi.LogiTyp = logityp;
                foreach (var key in item.Keys)
                {
                    foreach (var antal in item.Values)
                    {
                        if (key == 1) statistikLogi.Jan = antal;
                        if (key == 2) statistikLogi.Feb = antal;
                        if (key == 3) statistikLogi.Mar = antal;
                        if (key == 4) statistikLogi.Apr = antal;
                        if (key == 5) statistikLogi.Maj = antal;
                        if (key == 6) statistikLogi.Jun = antal;
                        if (key == 7) statistikLogi.Jul = antal;
                        if (key == 8) statistikLogi.Aug = antal;
                        if (key == 9) statistikLogi.Sep = antal;
                        if (key == 10) statistikLogi.Okt = antal;
                        if (key == 11) statistikLogi.Nov = antal;
                        if (key == 12) statistikLogi.Dec = antal;
                    }
                }

            }
            DisplayStatistik.Add(statistikLogi);
        }





        //private int? År = ValtÅr.Year;
        //public int År { get => år; set => år = value; }





        #endregion

    }


}