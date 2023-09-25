using Affärslager;
using PresentationslagerWPF.Commands;
using PresentationslagerWPF.Models;
using PresentationslagerWPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PresentationslagerWPF.ViewModels
{
    public class MainViewModel : ObservableObject
    {

        //****NAVIGATION*****//
        public ObservableObject CurrentViewModel { get; }


        //OBS. VÅR KONTROLLER HÄR
        //private BokningKontroller bokningsKontroller;
        private IWindowService windowService;

        //Konstruktor

        public MainViewModel()
        {
            CurrentViewModel = new HomeViewModel();
            //OBS. VÅR KONTROLLER HÄR
            //bokningsKontroller = new BokningKontroller();
        }
        //Användarnamn för ANVÄNDARE
        private string användarnamn = null!;
        public string Användarnamn { get => användarnamn; set { användarnamn = value; OnPropertyChanged(); } }

        //Lösenord för ANVÄNDARE
        private string lösenord = null!;
        public string Lösenord { get => lösenord; set { lösenord = value; OnPropertyChanged(); } }


        //Command för att trigga logga in och navigera mellan fönster. 
        private ICommand loggaInCommand = null!;
        public ICommand LoggaInCommand => loggaInCommand ??= loggaInCommand = new RelayCommand(() =>
        {
            //OBS. VÅR METOD FÖR ATT LOGGA IN 
            //Expedit e = bokningsKontroller.LoggaIn(Användarnamn, Lösenord);
            //if (e != null)
            //{
            //    HuvudMenyViewModel HuvudMeny = new HuvudMenyViewModel(e);
            //    bool result = windowService.ShowDialog(HuvudMeny);
            //}
            //else
            //{
            //    MessageBox.Show("Misslyckad inloggning");
            //}
        });
        // Stänger ner applikationen
        private ICommand exitCommand = null!;
        public ICommand ExitCommand =>
        exitCommand ??= exitCommand = new RelayCommand(() => App.Current.Shutdown());
    }
}

