using Affärslager;
using Entiteter.Personer;
using PresentationslagerWPF.Services;
using PresentationslagerWPF.ViewModels;

namespace PresentationslagerWPF.Commands
{
    public class LoggaInCommand : CommandBase
    {



        /// <summary>
        /// KOMMANDS ATT KONTROLLERA BOKNING 
        /// </summary>

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
        public override void Execute(object parameter)
        {
            Användare anv = användarKontroller.Inloggning(_viewModel.Användarnamn, _viewModel.Lösenord);
            if (anv != null)
            {
                _navigationService.Navigate();

            }
        }
    }
}
