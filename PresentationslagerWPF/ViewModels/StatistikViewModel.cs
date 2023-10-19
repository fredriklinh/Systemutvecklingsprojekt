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
                List<string> query = statistikKontroller.HämtaUnikaBenämningarLogi();
                foreach (var item in query)
                {
                    List<Dictionary<int, int>> test69 = statistikKontroller.HämtaAntalBokningarLogi(item, selectedItemÅr);
                    PopuleraDisplayLogi(test69, item);

                }
                

            }
        }
        public void PopuleraDisplayLogi(List<Dictionary<int, int>> antalBokningarPerMånad, string logityp)
        {
            DisplayStatistik test1 = new DisplayStatistik();
            foreach (var item in antalBokningarPerMånad)
            {
                test1.LogiTyp = logityp;
                foreach (var key in item.Keys)
                {
                    foreach (var test in item.Values)
                    {
                        if (key == 1) test1.Jan = test;
                        if (key == 2) test1.Feb = test;
                        if (key == 3) test1.Mar = test;
                        if (key == 4) test1.Apr = test;
                        if (key == 5) test1.Maj = test;
                        if (key == 6) test1.Jun = test;
                        if (key == 7) test1.Jul = test;
                        if (key == 8) test1.Aug = test;
                        if (key == 9) test1.Sep = test;
                        if (key == 10) test1.Okt = test;
                        if (key == 11) test1.Nov = test;
                        if (key == 12) test1.Dec = test;
                    }
                }

            }
            DisplayStatistik.Add(test1);
        }





        //private int? År = ValtÅr.Year;
        //public int År { get => år; set => år = value; }





        #endregion

    }


}