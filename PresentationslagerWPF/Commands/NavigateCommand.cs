using PresentationslagerWPF.Models;
using PresentationslagerWPF.Services;

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
