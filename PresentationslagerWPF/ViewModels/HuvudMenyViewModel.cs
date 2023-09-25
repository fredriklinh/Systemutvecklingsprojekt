using PresentationslagerWPF.Models;
using PresentationslagerWPF.Stores;
using System.Windows.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PresentationslagerWPF.Commands;
 

namespace PresentationslagerWPF.ViewModels
{
    internal class HuvudMenyViewModel : ObservableObject
    {
        public ICommand NavigationHomeCommand { get; }

        public HuvudMenyViewModel(NavigationStore navigationStore)
        {
            NavigationHomeCommand = new NavigateCommand<HuvudMenyViewModel>(new Services.NavigationService<HuvudMenyViewModel>(navigationStore, () => new HuvudMenyViewModel(navigationStore)));
        }
    }
}
