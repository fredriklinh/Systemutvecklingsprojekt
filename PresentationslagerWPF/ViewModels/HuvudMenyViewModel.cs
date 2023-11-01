using Entiteter.Personer;
using PresentationslagerWPF.Commands;
using PresentationslagerWPF.Models;
using PresentationslagerWPF.Services;
using PresentationslagerWPF.Stores;
using System.Windows.Input;

namespace PresentationslagerWPF.ViewModels
{
    public class HuvudMenyViewModel : ObservableObject
    {
        public HuvudMenyViewModel(NavigationStore navigationStore, Användare användare)
        {
            NavigateLoggaUtCommand = new NavigateCommand<LoggaInViewModel>(new NavigationService<LoggaInViewModel>(navigationStore, () => new LoggaInViewModel(navigationStore)));
            NavigateMasterBokningCommand = new NavigateCommand<MasterBokningViewModel>(new NavigationService<MasterBokningViewModel>(navigationStore, () => new MasterBokningViewModel(navigationStore, användare)));
            NavigateKundHanteringCommand = new NavigateCommand<KundhanteringViewModel>(new NavigationService<KundhanteringViewModel>(navigationStore, () => new KundhanteringViewModel(navigationStore, användare)));
            NavigateSkidshopCommand = new NavigateCommand<SkidshopViewModel>(new NavigationService<SkidshopViewModel>(navigationStore, () => new SkidshopViewModel(navigationStore, användare)));
            NavigateStatistikCommand = new NavigateCommand<StatistikViewModel>(new NavigationService<StatistikViewModel>(navigationStore, () => new StatistikViewModel(navigationStore, användare)));
            NavigateAdminCommand = new NavigateCommand<AdminViewModel>(new NavigationService<AdminViewModel>(navigationStore, () => new AdminViewModel(navigationStore, användare)));
            UppdateraCommand = new NavigateCommand<HuvudMenyViewModel>(new NavigationService<HuvudMenyViewModel>(navigationStore, () => new HuvudMenyViewModel(navigationStore, användare)));
            
            Behörighet(användare);


        }
        public HuvudMenyViewModel() { }

        //**** NAVIGATION *******//
        public ICommand UppdateraCommand { get; }
        public ICommand NavigateSkidshopCommand { get; }
        public ICommand NavigateMasterBokningCommand { get; }
        public ICommand NavigateKundHanteringCommand { get; }
        public ICommand NavigateStatistikCommand { get; }
        public ICommand NavigateAdminCommand { get; }


        //**** NAVBAR *******//
        private ICommand exitCommand = null!;
        public ICommand ExitCommand =>
        exitCommand ??= exitCommand = new RelayCommand(() => App.Current.Shutdown());

        public ICommand NavigateLoggaUtCommand { get; }


        #region IsEnabled för navigation av knappar

        private bool isEnabledAdmin = false!;

        public bool IsEnabledAdmin { get => isEnabledAdmin; set { isEnabledAdmin = value; OnPropertyChanged(); } }
        
        private bool isEnabledBokning = false!;

        public bool IsEnabledBokning { get => isEnabledBokning; set { isEnabledBokning = value; OnPropertyChanged(); } }

        private bool isEnabledSkidshop = false!;

        public bool IsEnabledSkidshop { get => isEnabledSkidshop; set { isEnabledSkidshop = value; OnPropertyChanged(); } }


        //Metod för att kolla behörighet av användare
        public void Behörighet(Användare användare)
        {
            if (användare.Behörighetsnivå == 1)
            {
                IsEnabledAdmin = true;
                isEnabledBokning = true;
                IsEnabledSkidshop = true;
            }

            if (användare.Behörighetsnivå == 2)
            {
                isEnabledBokning = true;
                IsEnabledSkidshop = true;
            }
            if (användare.Behörighetsnivå == 3)
            {
                isEnabledBokning = false;
                IsEnabledSkidshop = true;
            }
            if (användare.Behörighetsnivå == 4)
            {
                isEnabledBokning = true;
                IsEnabledSkidshop = false;

            }

        }
        #endregion


    }
}
