using PresentationslagerWPF.Models;
using PresentationslagerWPF.Stores;
using System;

namespace PresentationslagerWPF.Services
{
    public class NavigationService<TViewModel>
        where TViewModel : ObservableObject
    {
        //Används för att navigera användare vidare och tillbaka via fönster

        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;

        public NavigationService(NavigationStore navigationStore, Func<TViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _createViewModel();

        }

    }
}
