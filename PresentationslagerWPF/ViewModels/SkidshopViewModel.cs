using Entiteter.Personer;
using PresentationslagerWPF.Models;
using PresentationslagerWPF.Stores;
using PresentationslagerWPF.Commands;
using PresentationslagerWPF.Services;
using System.Windows.Input;
using Microsoft.VisualBasic;
using System.Collections.ObjectModel;

namespace PresentationslagerWPF.ViewModels
{
    public class SkidshopViewModel : ObservableObject
    {
        //TABORT
        public class Utrustning { }

        private ObservableCollection<Utrustning> hjälm = null!;
        public ObservableCollection<Utrustning> Hjälm { get => hjälm; set { hjälm = value; OnPropertyChanged(); } }




        public SkidshopViewModel()
        {

        }

        //**** NAVIGATION *******//

        public SkidshopViewModel(NavigationStore navigationStore, Användare användare)
        {
            TillbakaCommand = new NavigateCommand<HuvudMenyViewModel>(new NavigationService<HuvudMenyViewModel>(navigationStore, () => new HuvudMenyViewModel(navigationStore, användare)));
        }

        public ICommand TillbakaCommand { get; }

        //**** SKIDLEKTION *******//


    }
}
