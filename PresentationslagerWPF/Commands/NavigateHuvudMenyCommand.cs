using PresentationslagerWPF.Stores;
using PresentationslagerWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationslagerWPF.Commands
{
    internal class NavigateHuvudMenyCommand :CommandBase
    {
        private readonly NavigationStore _navigationStore;

        public NavigateHuvudMenyCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new HuvudMenyViewModel(_navigationStore);
        }
    }
}
