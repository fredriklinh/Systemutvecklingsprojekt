using PresentationslagerWPF.Models;
using PresentationslagerWPF.Stores;
using PresentationslagerWPF.Services;
using System.Windows.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using PresentationslagerWPF.Commands;
using System.Threading.Channels;
using Entiteter.Personer;

namespace PresentationslagerWPF.ViewModels
{
    public class HuvudMenyViewModel : ObservableObject
    {

        public HuvudMenyViewModel(NavigationStore navigationStore, Användare användare)
        {
            NavigateLoggaUtCommand = new NavigateCommand<LoggaInViewModel>(new NavigationService<LoggaInViewModel>(navigationStore, () => new LoggaInViewModel(navigationStore)));
            NavigateMasterBokningCommand = new NavigateCommand<MasterBokningViewModel>(new NavigationService<MasterBokningViewModel>(navigationStore, () => new MasterBokningViewModel(navigationStore, användare)));
            NavigateKundHanteringCommand = new NavigateCommand<KundhanteringViewModel>(new NavigationService<KundhanteringViewModel>(navigationStore, () => new KundhanteringViewModel(navigationStore)));
            NavigateStatistikCommand = new NavigateCommand<HuvudMenyViewModel>(new NavigationService<HuvudMenyViewModel>(navigationStore, () => new HuvudMenyViewModel(navigationStore, användare)));

        }
        public HuvudMenyViewModel() { }

        //**** NAVIGATION *******//
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
