using Entiteter.Personer;
using PresentationslagerWPF.Models;
using PresentationslagerWPF.Stores;
using PresentationslagerWPF.Commands;
using PresentationslagerWPF.Services;
using System.Windows.Input;
using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using Affärslager;
using System.Collections.Generic;
using Entiteter.Tjänster;
using System.Linq;

namespace PresentationslagerWPF.ViewModels
{
    public class SkidshopViewModel : ObservableObject
    {
        UtrustningsKontroller utrustningsKontroller = new UtrustningsKontroller();

        //TABORT
        private ObservableCollection<Utrustning> alpint = null!;
        public ObservableCollection<Utrustning> Alpint
        {
            get => alpint; set
            {
                alpint = value; OnPropertyChanged();
            }
        }

        private ObservableCollection<Utrustning> allaUtrustningar = null!;
        public ObservableCollection<Utrustning> AllaUtrustningar
        {
            get => allaUtrustningar; set
            {
                allaUtrustningar = value; OnPropertyChanged();
            }
        }


        private ObservableCollection<Utrustning> allUtrustning = null!;
        public ObservableCollection<Utrustning> AllUtrustning { get => allUtrustning; set {
                allUtrustning = value; OnPropertyChanged();
                IList<Utrustning> allaUtrustningar = utrustningsKontroller.HämtaTillgängligUtrustning();

                Alpint = new ObservableCollection<Utrustning>(allaUtrustningar.Where(i => i.Typ == "Alpint"));

            }
        }

        //public Dish DishesSelectedItem
        //{
        //    get { return dishesSelectedItem; }
        //    set
        //    {
        //        dishesSelectedItem = value;
        //        OnPropertyChanged();

        //        if (dishesSelectedItem != null)
        //        {
        //            Ingredients = new ObservableCollection<Ingredient>(dishesSelectedItem.DishIngredients.Select(di => di.Ingredient).ToList());
        //            IngredientsSelectedIndex = (Ingredients.Count > 0) ? 0 : -1;

        //            IList<Ingredient> allIngredients = pizzeriaController.GetIngredients();

        //            AvailableIngredients = new ObservableCollection<Ingredient>(allIngredients.Where(i => !Ingredients.Select(di => di.Id).Contains(i.Id)).ToList());
        //            AvailableIngredientsSelectedIndex = (AvailableIngredients.Count > 0) ? 0 : -1;

        //            Status = $"Selected dish #{DishesSelectedItem?.Id}: {DishesSelectedItem?.Name}";
        //        }
        //    }
        //}




        #region NAVIGATION
        public SkidshopViewModel()
        {

        }

        //**** NAVIGATION *******//

        public SkidshopViewModel(NavigationStore navigationStore, Användare användare)
        {
            TillbakaCommand = new NavigateCommand<HuvudMenyViewModel>(new NavigationService<HuvudMenyViewModel>(navigationStore, () => new HuvudMenyViewModel(navigationStore, användare)));
            AllaUtrustningar = new ObservableCollection<Utrustning>(utrustningsKontroller.HämtaTillgängligUtrustning());
            Alpint = new ObservableCollection<Utrustning>(allaUtrustningar.Where(i => i.UtrustningsTyp.Typ == "Snowboard"));

        }

        public ICommand TillbakaCommand { get; }

        //**** SKIDLEKTION *******//
        #endregion

    }
}
