using PresentationslagerWPF.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PresentationslagerWPF.Stores;
using PresentationslagerWPF.Services;
using PresentationslagerWPF.Models;
using Affärslager;
using Entiteter.Personer;
using Microsoft.Identity.Client;
using System.Diagnostics.Eventing.Reader;
using System.Windows;
using System.CodeDom.Compiler;
using System.Windows.Controls;
using System.Security;

namespace PresentationslagerWPF.ViewModels
{
    public class LoggaInViewModel : ObservableObject
    {

        //**** NAVIGATION *******//
        public ICommand LoggaInCommand { get; }

        public LoggaInViewModel(NavigationStore navigationStore)
        {
            LoggaInCommand = new LoggaInCommand(this, new NavigationService<HuvudMenyViewModel>(navigationStore, () => new HuvudMenyViewModel(navigationStore)));

        }

        //STATUS
        private string status = "Ready";
        public string Status { get { return status; } set { status = value; OnPropertyChanged(); } }


        //Användarnamn för ANVÄNDARE
        private string användarnamn = null!;
        public string Användarnamn { get => användarnamn; set { användarnamn = value; OnPropertyChanged(); } }

        //Lösenord för ANVÄNDARE
        private string lösenord = null!;
        public string Lösenord { get => lösenord; set { lösenord = value; OnPropertyChanged(); } }


        //OBS DENNA SKA VARA PRIVAT FÖR ATT VARA 100% KORREKT MVVM
        public string Password { get; set; }
        public SecureString SecurePassword { get; set; }

        //AVBRYT
        private ICommand exitCommand = null!;
        public ICommand ExitCommand =>
        exitCommand ??= exitCommand = new RelayCommand(() => App.Current.Shutdown());


    }
}
