using Affärslager;
using Affärslager.KundKontroller;
using Entiteter.Personer;
using Entiteter.Tjänster;
using PresentationslagerWPF.Commands;
using PresentationslagerWPF.Models;
using PresentationslagerWPF.Services;
using PresentationslagerWPF.Stores;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace PresentationslagerWPF.ViewModels
{

    public class SkidshopViewModel : ObservableObject
    {


        UtrustningsKontroller utrustningsKontroller = new UtrustningsKontroller();


        #region ObservableColletion Utrustning
        //TABORT
        private ObservableCollection<Utrustning> alpint = null!;
        public ObservableCollection<Utrustning> Alpint
        {
            get => alpint; set
            {
                alpint = value; OnPropertyChanged();
            }
        }

        private ObservableCollection<Utrustning> hjälm = null!;
        public ObservableCollection<Utrustning> Hjälm
        {
            get => hjälm; set
            {

                hjälm = value; OnPropertyChanged();
                Antal = RäknaAntal(Hjälm);
            }
        }
        private ObservableCollection<Utrustning> längd = null!;
        public ObservableCollection<Utrustning> Längd
        {
            get => längd; set
            {
                längd = value; OnPropertyChanged();
                Antal = RäknaAntal(längd);
            }
        }
        private ObservableCollection<Utrustning> snöskoter = null!;
        public ObservableCollection<Utrustning> Snöskoter
        {
            get => snöskoter; set
            {
                snöskoter = value; OnPropertyChanged();
                Antal = RäknaAntal(snöskoter);
            }
        }

        private ObservableCollection<Utrustning> snowboard = null!;
        public ObservableCollection<Utrustning> Snowboard
        {
            get => snowboard; set
            {
                snowboard = value; OnPropertyChanged();
                Antal = RäknaAntal(Snowboard);
                SnowboardBoard = new ObservableCollection<Utrustning>(snowboard.Where(i => i.Benämning == "Snowboard"));
            }
        }
        private ObservableCollection<Utrustning> snowboardBoard = null!;
        public ObservableCollection<Utrustning> SnowboardBoard
        {
            get => snowboardBoard; set
            {
                snowboardBoard = value; OnPropertyChanged();


                Antal = RäknaAntal(SnowboardBoard);
                int nummer = Antal.Count;

                int iteration = 0;
                foreach (Utrustning item in Snowboard)
                {
                    iteration++;
                    if (iteration >= nummer)
                    {
                        break;
                    }
                    //ValdUtrustningTillBokning.Add(item);
                };
            }
        }

        #endregion

        private ObservableCollection<Utrustning> allaUtrustningar = null!;
        public ObservableCollection<Utrustning> AllaUtrustningar
        {
            get => allaUtrustningar; set
            {
                allaUtrustningar = value; OnPropertyChanged();
            }
        }


        private ObservableCollection<Utrustning> allUtrustning = null!;
        public ObservableCollection<Utrustning> AllUtrustning
        {
            get => allUtrustning; set
            {
                allUtrustning = value; OnPropertyChanged();
                IList<Utrustning> allaUtrustningar = utrustningsKontroller.HämtaTillgängligUtrustning();

                Alpint = new ObservableCollection<Utrustning>(allaUtrustningar.Where(i => i.Typ == "Alpint"));

            }
        }
        private ObservableCollection<Utrustning> valdUtrustningTillBokning = null!;
        public ObservableCollection<Utrustning> ValdUtrustningTillBokning
        {
            get => valdUtrustningTillBokning; set
            {
                valdUtrustningTillBokning = value; OnPropertyChanged();
            }
        }
        private List<int> antal;
        public List<int> Antal
        {
            get { return antal; }
            set { antal = value; OnPropertyChanged(); }

        }




        #region NAVIGATION

        //**** NAVIGATION *******//

        public SkidshopViewModel(NavigationStore navigationStore, Användare användare)
        {
            TillbakaCommand = new NavigateCommand<HuvudMenyViewModel>(new NavigationService<HuvudMenyViewModel>(navigationStore, () => new HuvudMenyViewModel(navigationStore, användare)));


            AllaUtrustningar = new ObservableCollection<Utrustning>(utrustningsKontroller.HämtaTillgängligUtrustning());
            Alpint = new ObservableCollection<Utrustning>(allaUtrustningar.Where(i => i.UtrustningsTyp.Typ == "Alpint")); //Pjäxor, Stavar, Skidor
            Snowboard = new ObservableCollection<Utrustning>(allaUtrustningar.Where(i => i.UtrustningsTyp.Typ == "Snowboard")); //Snowboard, Snowboardboots
            Längd = new ObservableCollection<Utrustning>(allaUtrustningar.Where(i => i.UtrustningsTyp.Typ == "Längd")); //Pjäxor, Stavar, Skidor
            Snöskoter = new ObservableCollection<Utrustning>(allaUtrustningar.Where(i => i.UtrustningsTyp.Typ == "Snöskoter")); //Skoter 1, Skoter 2, Pulka
            Hjälm = new ObservableCollection<Utrustning>(allaUtrustningar.Where(i => i.UtrustningsTyp.Typ == "Hjälm")); // Hjälm

            //HÄR


        }

        public List<int> RäknaAntal(ObservableCollection<Utrustning> utrustnings)
        {
            List<int> antal = new List<int>();
            int steg = 0;
            foreach (Utrustning item in utrustnings)
            {
                if (steg == 50)
                {
                    return antal;
                }
                steg = steg + 1;
                antal.Add(steg);
            }
            return antal;

        }

        public ICommand TillbakaCommand { get; }

        //**** SKIDLEKTION *******//
        #endregion


        private ICommand utrustningCommand = null!;
        public ICommand  UtrustningCommandSkidor => utrustningCommand ??= utrustningCommand = new RelayCommand(() =>
        {

            if (Antal != null)
            {
                
            }

            
            //AllaUtrustningar.Add(Test);

        });
    }
}


