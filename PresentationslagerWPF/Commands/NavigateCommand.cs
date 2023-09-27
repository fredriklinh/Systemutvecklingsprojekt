using PresentationslagerWPF.Models;
using PresentationslagerWPF.Stores;
using PresentationslagerWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationslagerWPF.Services;
using Affärslager;
using Entiteter.Personer;
using System.Windows;
using Entiteter;

namespace PresentationslagerWPF.Commands
{
    public class NavigateCommand<TViewModel> : CommandBase
        where TViewModel : ObservableObject
    {


        private readonly NavigationService<TViewModel> _navigationService;





        public NavigateCommand(NavigationService<TViewModel> navigationService)
        {
            _navigationService = navigationService;
        }

        public override bool CanExecute(object parameter)
        {
            return true;

        }
        public override void Execute(object parameter)
        {

            _navigationService.Navigate();

        }
    }
}
