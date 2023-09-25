using PresentationslagerWPF.Models;
using PresentationslagerWPF.Stores;
using PresentationslagerWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationslagerWPF.Services;

namespace PresentationslagerWPF.Commands
{
    public class NavigateCommand<TViewModel> : CommandBase
        where TViewModel : ObservableObject
    {
        private readonly NavigationService<TViewModel> _navigationService;

        private readonly Func<bool> _canExecute = null!;

        public NavigateCommand(NavigationService<TViewModel> navigationService)
        {
            _navigationService = navigationService;
        }

        public override bool CanExecute(object parameter) =>
                _canExecute == null || _canExecute();

        public override void Execute(object parameter)
        {
            _navigationService.Navigate();
        }
    }
}
