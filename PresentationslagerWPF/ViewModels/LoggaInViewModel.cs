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

namespace PresentationslagerWPF.ViewModels
{
    public class LoggaInViewModel : ObservableObject
    {

        //public ICommand LoggaInCommand { get; }
        //NavigationStore navigationStore = null;


        public ICommand NavigateLoggaInCommand { get; }

        public LoggaInViewModel(NavigationStore navigationStore)
        {
            NavigateLoggaInCommand = new LoggaInCommand(this, new NavigationService<HuvudMenyViewModel>(navigationStore, () => new LoggaInViewModel(navigationStore)));
        }
    }
}
