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

namespace PresentationslagerWPF.ViewModels
{
    public class LoggaInViewModel : ObservableObject
    {
        AnvändarKontroller användarKontroller = new AnvändarKontroller();

        //**** NAVIGATION *******//
        public ICommand LoggaInCommand { get; }

        public LoggaInViewModel(NavigationStore navigationStore)
        {
            LoggaInCommand = new LoggaInCommand(this, new NavigationService<HuvudMenyViewModel>(navigationStore, () => new HuvudMenyViewModel(navigationStore, Användare)));



        }


        //STATUS
        private string status = "Ready";
        public string Status { get { return status; } set { status = value; OnPropertyChanged(); } }


        //Användarnamn för ANVÄNDARE
        private string användarnamn = null!;
        public string Användarnamn { get => användarnamn; set { användarnamn = value; OnPropertyChanged();
                Användare = användarKontroller.Inloggning(Användarnamn, Lösenord);
            } }

        //Lösenord för ANVÄNDARE
        private string lösenord = null!;
        public string Lösenord { 
            get => lösenord; 
            set { lösenord = value; OnPropertyChanged();
            Användare = användarKontroller.Inloggning(Användarnamn, Lösenord);
            } }

        //Observable object användare
        
        
        private Användare användare = null!;
        public Användare Användare { get => användare; set { användare = value; OnPropertyChanged();} }

        //AVBRYT
        private ICommand exitCommand = null!;
        public ICommand ExitCommand =>
        exitCommand ??= exitCommand = new RelayCommand(() => App.Current.Shutdown());




    }
}
