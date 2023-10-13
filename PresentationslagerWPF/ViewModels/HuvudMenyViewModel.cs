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
            NavigateStatistikCommand = new NavigateCommand<HuvudMenyViewModel>(new NavigationService<HuvudMenyViewModel>(navigationStore, () => new HuvudMenyViewModel(navigationStore, användare)));
            NavigateSkidshopCommand = new NavigateCommand<SkidshopViewModel>(new NavigationService<SkidshopViewModel>(navigationStore, () => new SkidshopViewModel(navigationStore, användare)));
            NavigateStatistikCommand = new NavigateCommand<StatistikViewModel>(new NavigationService<StatistikViewModel>(navigationStore, () => new StatistikViewModel(navigationStore, användare)));

        }
        public HuvudMenyViewModel() { }

        //**** NAVIGATION *******//
        public ICommand NavigateSkidshopCommand { get; }

        public ICommand NavigateLoggaUtCommand { get; }
        public ICommand NavigateMasterBokningCommand { get; }
        public ICommand NavigateKundHanteringCommand { get; }
        public ICommand NavigateStatistikCommand { get; }

        



        //**** NAVBAR *******//
        private ICommand exitCommand = null!;
        public ICommand ExitCommand =>
        exitCommand ??= exitCommand = new RelayCommand(() => App.Current.Shutdown());


    }
}
