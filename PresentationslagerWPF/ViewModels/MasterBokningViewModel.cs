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

namespace PresentationslagerWPF.ViewModels
{
    public class MasterBokningViewModel : ObservableObject
    {

        public MasterBokningViewModel(NavigationStore navigationStore)
        {
                
        }
        public MasterBokningViewModel()
        {
            
        }

        //Användarnamn för ANVÄNDARE
        private DateTime startTid;
        public DateTime Starttid { get => startTid; set { startTid = value; OnPropertyChanged(); } }

        //Lösenord för ANVÄNDARE
        private DateTime slutTid;
        public DateTime SlutTid { get => slutTid; set { slutTid = value; OnPropertyChanged(); } }


    }
}
