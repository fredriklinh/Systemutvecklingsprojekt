using Affärslager;
using Entiteter.Personer;
using PresentationslagerWPF.Commands;
using PresentationslagerWPF.Models;
using PresentationslagerWPF.Services;
using PresentationslagerWPF.Stores;
using PresentationslagerWPF.ViewModels.FönsterViewModel;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace PresentationslagerWPF.ViewModels
{
    public class AdminViewModel : ObservableObject
    {
        AnvändarKontroller användarKontroller = new AnvändarKontroller();
        private IWindowService windowService;


        #region NAVIGATION
        public AdminViewModel()
        {
        }

        public AdminViewModel(NavigationStore navigationStore, Användare användare)
        {
            AllaAnvändare = new ObservableCollection<Användare>(användarKontroller.HämtaAllaAnvändare());

            TillbakaCommand = new NavigateCommand<HuvudMenyViewModel>(new NavigationService<HuvudMenyViewModel>(navigationStore, () => new HuvudMenyViewModel(navigationStore, användare)));
            UppddateraCommand = new NavigateCommand<AdminViewModel>(new NavigationService<AdminViewModel>(navigationStore, () => new AdminViewModel(navigationStore, användare)));
            NavigateLoggaUtCommand = new NavigateCommand<LoggaInViewModel>(new NavigationService<LoggaInViewModel>(navigationStore, () => new LoggaInViewModel(navigationStore)));

            this.windowService = new WindowService();
        }


        #endregion

        #region COMMANDS
        public ICommand TillbakaCommand { get; }
        public ICommand UppddateraCommand { get; }
        public ICommand NavigateLoggaUtCommand { get; }



        private ICommand skapaAnvändareWindowCommand = null!;
        public ICommand SkapaAnvändareWindowCommand => skapaAnvändareWindowCommand ??= skapaAnvändareWindowCommand = new RelayCommand(() =>
        {
            SkapaAnvändareViewModel skapaAnvändareWindow = new SkapaAnvändareViewModel();
            bool result = windowService.ShowDialog(skapaAnvändareWindow);
        });


        #endregion

        private ICommand exitCommand = null!;
        public ICommand ExitCommand =>
        exitCommand ??= exitCommand = new RelayCommand(() => App.Current.Shutdown());


        private Användare användare = null!;
        public Användare Användare { get => användare; set { användare = value; OnPropertyChanged(); } }


        private ICommand taBortBokningCommand = null!;
        public ICommand TaBortBokningCommand => taBortBokningCommand ??= taBortBokningCommand = new RelayCommand(() =>
        {

            if (Användare == SelectedItemAllaAnvändare) MessageBox.Show("Kan inte ta bort inloggad Användare", "Användare", MessageBoxButton.OK);
            else
            {
                MessageBoxResult var = MessageBox.Show("Är du säker att användare ska tas bort?", "Användare", MessageBoxButton.YesNo);
                if (var == MessageBoxResult.Yes) användarKontroller.TaBortAnvändare(SelectedItemAllaAnvändare);

            }
        });


        #region OBSERVABLE COLLECTION ANVÄNDARE

        private ObservableCollection<Användare> allaAnvändare = null!;
        public ObservableCollection<Användare> AllaAnvändare
        {
            get => allaAnvändare;
            set
            {
                allaAnvändare = value; OnPropertyChanged();


            }
        }

        #endregion


        #region SELECTEDITEM ANVÄNDARE

        private Användare selectedItemAllaAnvändare = null!;
        public Användare SelectedItemAllaAnvändare
        {
            get => selectedItemAllaAnvändare;
            set
            {
                selectedItemAllaAnvändare = value; OnPropertyChanged();

            }
        }


        #endregion
    }
}
