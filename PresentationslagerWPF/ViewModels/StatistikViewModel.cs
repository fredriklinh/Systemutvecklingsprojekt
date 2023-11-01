using Affärslager;
using Entiteter.Personer;
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

        #region ------------------------------------------NAVIGATION
        public StatistikViewModel(NavigationStore navigationStore, Användare användare)
        {

            NavigateLoggaUtCommand = new NavigateCommand<LoggaInViewModel>(new NavigationService<LoggaInViewModel>(navigationStore, () => new LoggaInViewModel(navigationStore)));
            TillbakaCommand = new NavigateCommand<HuvudMenyViewModel>(new NavigationService<HuvudMenyViewModel>(navigationStore, () => new HuvudMenyViewModel(navigationStore, användare)));

            //Commands
            UppddateraCommand = new NavigateCommand<StatistikViewModel>(new NavigationService<StatistikViewModel>(navigationStore, () => new StatistikViewModel(navigationStore, användare)));


            DisplayStatistikLogi = new ObservableCollection<DisplayStatistik>();
            DisplayStatistikUtrustning = new ObservableCollection<DisplayStatistik>();
            Årtal = new ObservableCollection<int>(statistikKontroller.HämtaÅr());
            ÅrtalUtrustning = new ObservableCollection<int>(statistikKontroller.HämtaÅr());

        }
        public ICommand UppddateraCommand { get; }

        public ICommand NavigateLoggaUtCommand { get; }

        private ICommand exitCommand = null!;
        public ICommand ExitCommand =>
        exitCommand ??= exitCommand = new RelayCommand(() => App.Current.Shutdown());

        public ICommand TillbakaCommand { get; }


        #endregion

        private ObservableCollection<int> årtal = null!;
        public ObservableCollection<int> Årtal { get => årtal; set { årtal = value; OnPropertyChanged(); } }

        private ObservableCollection<int> årtalUtrustning = null!;
        public ObservableCollection<int> ÅrtalUtrustning { get => årtalUtrustning; set { årtalUtrustning = value; OnPropertyChanged(); } }

        #region -----------------------------------MasterBokning Logi

        private int totalenLogi;
        public int TotalenLogi { get => totalenLogi; set { totalenLogi = value; OnPropertyChanged(); } }

        private ObservableCollection<DisplayStatistik> displayStatistikLogi = null!;
        public ObservableCollection<DisplayStatistik> DisplayStatistikLogi { get => displayStatistikLogi; set { displayStatistikLogi = value; OnPropertyChanged(); } }


        private int selectedItemLogiÅr;
        public int SelectedItemLogiÅr
        {
            get => selectedItemLogiÅr;
            set
            {
                selectedItemLogiÅr = value; OnPropertyChanged();
                DisplayStatistikLogi.Clear();
                List<string> typAvLogier = statistikKontroller.HämtaUnikaBenämningarLogi();
                foreach (var typL in typAvLogier)
                {
                    List<Dictionary<int, int>> bokningarPerMånad = statistikKontroller.HämtaAntalBokningarLogi(typL, selectedItemLogiÅr);
                    PopuleraDisplayLogi(bokningarPerMånad, typL);
                }
            }
        }
        public void PopuleraDisplayLogi(List<Dictionary<int, int>> bokningarPerMånad, string typ)
        {
            DisplayStatistik statistikLogi = new DisplayStatistik();
            foreach (var item in bokningarPerMånad)
            {
                statistikLogi.Typ = typ;
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
            statistikLogi.Typ = typ;
            DisplayStatistikLogi.Add(statistikLogi);
        }

        #endregion

        #region Bokningar Utrustning

        private int totalenUtrustning;
        public int TotalenUtrustning { get => totalenUtrustning; set { totalenUtrustning = value; OnPropertyChanged(); } }

        private ObservableCollection<DisplayStatistik> displayStatistikUtrustning = null!;
        public ObservableCollection<DisplayStatistik> DisplayStatistikUtrustning { get => displayStatistikUtrustning; set { displayStatistikUtrustning = value; OnPropertyChanged(); } }

        private int selectedItemUtrustningÅr;
        public int SelectedItemUtrustningÅr
        {
            get => selectedItemUtrustningÅr;
            set
            {
                selectedItemUtrustningÅr = value; OnPropertyChanged();
                DisplayStatistikUtrustning.Clear();
                List<string> typAvUtrustning = statistikKontroller.HämtaUnikaBenämningarUtrustning();
                foreach (var typU in typAvUtrustning)
                {
                    List<Dictionary<int, int>> bokningarPerMånad = statistikKontroller.HämtaAntalBokningarUtrustning(typU, selectedItemUtrustningÅr);
                    PopuleraDisplayUtrustning(bokningarPerMånad, typU);
                }
            }
        }
        public void PopuleraDisplayUtrustning(List<Dictionary<int, int>> bokningarPerMånad, string typ)
        {
            DisplayStatistik statistikUtrustning = new DisplayStatistik();
            foreach (var item in bokningarPerMånad)
            {
                statistikUtrustning.Typ = typ;
                foreach (var key in item.Keys)
                {
                    foreach (var antal in item.Values)
                    {
                        if (key == 1) statistikUtrustning.Jan = antal;
                        if (key == 2) statistikUtrustning.Feb = antal;
                        if (key == 3) statistikUtrustning.Mar = antal;
                        if (key == 4) statistikUtrustning.Apr = antal;
                        if (key == 5) statistikUtrustning.Maj = antal;
                        if (key == 6) statistikUtrustning.Jun = antal;
                        if (key == 7) statistikUtrustning.Jul = antal;
                        if (key == 8) statistikUtrustning.Aug = antal;
                        if (key == 9) statistikUtrustning.Sep = antal;
                        if (key == 10) statistikUtrustning.Okt = antal;
                        if (key == 11) statistikUtrustning.Nov = antal;
                        if (key == 12) statistikUtrustning.Dec = antal;
                    }
                }
            }
            statistikUtrustning.Typ = typ;
            DisplayStatistikUtrustning.Add(statistikUtrustning);

        }
        #endregion
    }
}