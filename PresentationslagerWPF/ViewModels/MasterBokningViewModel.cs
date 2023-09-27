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
using System.Windows;

namespace PresentationslagerWPF.ViewModels
{
    public class MasterBokningViewModel : ObservableObject
    {

        public MasterBokningViewModel(NavigationStore navigationStore)
        {
            NavigateHuvudMenyCommand = new NavigateCommand<HuvudMenyViewModel>(new NavigationService<HuvudMenyViewModel>(navigationStore, () => new HuvudMenyViewModel(navigationStore)));

        }
        public MasterBokningViewModel()
        {
            
        }


        //**** NAVIGATION *******//
        public ICommand NavigateHuvudMenyCommand { get; }


        //Användarnamn för ANVÄNDARE
        private DateTime startTid;
        public DateTime Starttid { get => startTid; set { startTid = value; OnPropertyChanged(); } }

        //Lösenord för ANVÄNDARE
        private DateTime slutTid;
        public DateTime SlutTid { get => slutTid; set { slutTid = value; OnPropertyChanged(); } }


        private ICommand hämtaBokningCommand = null!;
        public ICommand HämtaBokningCommand => hämtaBokningCommand ??= hämtaBokningCommand = new RelayCommand(() =>
        {
            //bokningsKontroller.hämtaBokningCommand(Starttid, SlutTid);

        });

    }
}
