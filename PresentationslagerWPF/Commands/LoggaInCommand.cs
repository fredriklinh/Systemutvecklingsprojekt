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

namespace PresentationslagerWPF.Commands
{
    public class LoggaInCommand<TViewModel> : CommandBase
       where TViewModel : ObservableObject
    {

        BokningsKontroller bokningsKontroller = new BokningsKontroller();

        private readonly LoggaInViewModel _viewModel;
        private readonly NavigationService<HuvudMenyViewModel> _navigationService;
        

        //public ICommand NavigateLoggaInCommand { get; }

         //NavigateLoggaInCommand = new NavigateCommand<LoggaInCommand>(new NavigationService<LoggaInViewModel>(navigationStore, () => new LoggaInViewModel(navigationStore)));
        

        public LoggaInCommand(NavigationService<TViewModel> navigationService)
        {
            //_viewModel = viewModel;
            //_navigationService = navigationService;
        }

        public override bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public override void Execute(object parameter)
        {
            MessageBox.Show("Loggar in");

            _navigationService.Navigate();

        }
    }
}
