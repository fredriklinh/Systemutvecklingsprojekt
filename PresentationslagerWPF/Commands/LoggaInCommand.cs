using Affärslager;
using Entiteter.Personer;
using PresentationslagerWPF.Services;
using PresentationslagerWPF.ViewModels;
using System.Windows;

namespace PresentationslagerWPF.Commands
{
    public class LoggaInCommand : CommandBase
    {

        AnvändarKontroller användarKontroller = new AnvändarKontroller();

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

        //Validerar och kontrollerar om inloggnign stämmer överens. Om det stämmer navigeras användare till nästa fönster.
        public override void Execute(object parameter)
        {
            Användare anv = användarKontroller.Inloggning(_viewModel.Användarnamn, _viewModel.Password);
            if (anv != null)
            {
                _navigationService.Navigate();
            }
            else
            {

                MessageBox.Show("Felaktig inloggningsinformation. Försök igen", "Inlogg", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
