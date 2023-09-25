using PresentationslagerWPF.Models;
using System.Windows.Input;

namespace PresentationslagerWPF.ViewModels
{
    public class HomeViewModel : ObservableObject
    {
        public string WelcomeMessage => "Welcome";

        public ICommand NavigateHuvudMenyCommand { get; }

    }
}
