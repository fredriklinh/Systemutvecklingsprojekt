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

namespace PresentationslagerWPF.ViewModels
{
    public class HuvudMenyViewModel : ObservableObject
    {

        public HuvudMenyViewModel(NavigationStore navigationStore)
        {

            NavigateMasterBokningCommand = new NavigateCommand<MasterBokningViewModel>(new NavigationService<MasterBokningViewModel>(navigationStore, () => new MasterBokningViewModel(navigationStore)));
            NavigateKundHanteringCommand = new NavigateCommand<HuvudMenyViewModel>(new NavigationService<HuvudMenyViewModel>(navigationStore, () => new HuvudMenyViewModel(navigationStore)));

            NavigateStatistikCommand = new NavigateCommand<HuvudMenyViewModel>(new NavigationService<HuvudMenyViewModel>(navigationStore, () => new HuvudMenyViewModel(navigationStore)));





        }
        public HuvudMenyViewModel() { }

        //**** NAVIGATION *******//
        public ICommand NavigateMasterBokningCommand { get; }
        public ICommand NavigateKundHanteringCommand { get; }
        public ICommand NavigateStatistikCommand { get; }




        private ICommand exitCommand = null!;
        public ICommand ExitCommand =>
        exitCommand ??= exitCommand = new RelayCommand(() => App.Current.Shutdown());


    }
}
