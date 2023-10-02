using PresentationslagerWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PresentationslagerWPF.Stores;
using PresentationslagerWPF.Commands;
using Affärslager;
using Affärslager.KundKontroller;

namespace PresentationslagerWPF.ViewModels
{
    public  class KundhanteringViewModel: ObservableObject
    {

        FöretagskundKontroller företaskundKontroller = new FöretagskundKontroller();
        PrivatkundKontroller privatkundKontroller = new PrivatkundKontroller();

        public KundhanteringViewModel(NavigationStore navigationstore)
        {
                
        }

        //**** PRIVATKUND *******//

        private string privatFörnamn;
        public string PrivatFörnamn { get => privatFörnamn; set { privatFörnamn = value; OnPropertyChanged(); } }

        private string privatEfternamn;
        public string PrivatEfternamn { get => privatEfternamn; set { privatEfternamn = value; OnPropertyChanged(); } }
        
        private string privatPersonummer;
        public string PrivatPersonummer { get => privatPersonummer; set { privatPersonummer = value; OnPropertyChanged(); } }

        private int postnummer;
        public int Postnummer { get => postnummer; set { postnummer = value; OnPropertyChanged(); } }

        private string mail;
        public string Mail { get => mail; set { mail = value; OnPropertyChanged(); } }

        private ICommand sparaPrivatKund = null!;
        public ICommand SparaPrivatKund => sparaPrivatKund ??= sparaPrivatKund = new RelayCommand(() =>
        {

            //privatkundKontroller.RegistreraPrivatKund(PrivatFörnamn, PrivatEfternamn, PrivatPersonummer, PrivatPersonummer, Mail);
        });


        //**** FÖRETAGSKUND *******//

        private int orgnr;
        public int Orgnr { get => orgnr; set { orgnr = value; OnPropertyChanged(); } }

        private string företagsNamn;
        public string FöretagsNamn { get => företagsNamn; set { företagsNamn = value; OnPropertyChanged(); } }

        private string rabatt;
        public string Rabatt { get => rabatt; set { rabatt = value; OnPropertyChanged(); } }


        private ICommand sparaFöretagsKund = null!;
        public ICommand SparaFöretagsKund => sparaFöretagsKund ??= sparaFöretagsKund = new RelayCommand(() =>
        {
           
            //företaskundKontroller
        });

    }
}
