using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationslagerWPF.Views;
using PresentationslagerWPF.ViewModels;
using System.Windows;
using PresentationslagerWPF.Stores;
using Affärslager;
using System.Runtime.CompilerServices;
using PresentationslagerWPF.Services;
using System.Windows.Input;
using PresentationslagerWPF.Models;
using Entiteter.Personer;
using System.Windows.Navigation;

namespace PresentationslagerWPF.Commands
{
    public class LoggaInCommand : CommandBase
    {
        


        /// <summary>
        /// KOMMANDS ATT KONTROLLERA BOKNING 
        /// </summary>

        BokningsKontroller bokningsKontroller = new BokningsKontroller();

        public readonly LoggaInViewModel _viewModel;
        private readonly NavigationService<HuvudMenyViewModel> _navigationService;


        public LoggaInCommand(LoggaInViewModel viewModel, NavigationService<HuvudMenyViewModel> navigationService)
        {
            _viewModel = viewModel;
            _navigationService = navigationService;
        }

        public override bool CanExecute(object parameter)
        {
            return true; 
                
        }
        public override void Execute(object parameter)
        {
            Användare anv = bokningsKontroller.Inloggning(_viewModel.Användarnamn, _viewModel.Lösenord);
            if (anv != null)
            {
                _navigationService.Navigate();

            }


        }
    }
}
