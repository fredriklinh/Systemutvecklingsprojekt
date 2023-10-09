using Affärslager;
using PresentationslagerWPF.Services;
using PresentationslagerWPF.ViewModels;

namespace PresentationslagerWPF.Commands
{
    public class TestNavigationCommand : CommandBase
    {

        /// <summary>
        /// KOMMANDS ATT KONTROLLERA BOKNING 
        /// </summary>

        BokningsKontroller bokningsKontroller = new BokningsKontroller();

        public readonly HuvudMenyViewModel _viewModel;
        private readonly NavigationService<MasterBokningViewModel> _navigationService;



        public TestNavigationCommand(HuvudMenyViewModel viewModel, NavigationService<MasterBokningViewModel> navigationService)
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
            _navigationService.Navigate();


        }
    }
}
