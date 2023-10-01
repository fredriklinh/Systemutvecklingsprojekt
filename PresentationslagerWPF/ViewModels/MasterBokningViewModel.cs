using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationslagerWPF.Services;
using PresentationslagerWPF.Commands;
using PresentationslagerWPF.Views;
using PresentationslagerWPF.Stores;
using PresentationslagerWPF.Models;
using Affärslager;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Entiteter.Tjänster;
using System.ComponentModel;

namespace PresentationslagerWPF.ViewModels
{
    public class MasterBokningViewModel : ObservableObject
    {
        #region Kontrollers
        BokningsKontroller bokningsKontroller = new BokningsKontroller();

        #endregion

        #region On property change
        private DateTime starttid = DateTime.Now;
        public DateTime Starttid { get => starttid; set { starttid = value; OnPropertyChanged(); } }

        private DateTime sluttid;
        public DateTime Sluttid { get => sluttid; set { sluttid = value; OnPropertyChanged(); } }

        #endregion

        #region Obervible Collections 
        //private ObservableCollection<Logi> tillgänliglogi = null!;
        //public ObservableCollection<Logi> Tillgänliglogi { get => tillgänliglogi; set {

        //        OnPropertyChanged(nameof(Tillgänliglogi));
        //        tillgänliglogi = value; OnPropertyChanged(); } }


        #endregion


        private ObservableCollection<Logi> tillgänliglogi;

        public ObservableCollection<Logi> Tillgänliglogi
        {
            get { return tillgänliglogi; }
            set
            {
                
                tillgänliglogi = value;
                OnPropertyChanged(nameof(tillgänliglogi));
            }
        }
        // This is a property that returns the count of items in YourProperty
        public int ItemCount
        {
            get { return Tillgänliglogi.Count; }
        }



    public ICommand Tillbaka { get; }
        public MasterBokningViewModel(NavigationStore navigationStore)
        {
            Tillbaka = new NavigateCommand<HuvudMenyViewModel>(new NavigationService<HuvudMenyViewModel>(navigationStore, () => new HuvudMenyViewModel(navigationStore)));

        }
        public MasterBokningViewModel()
        {
            
        }



        #region Icommands
        private ICommand hämtaBokningCommand = null!;
        public ICommand HämtaBokningCommand => hämtaBokningCommand ??= hämtaBokningCommand = new RelayCommand(() =>
        {
            Tillgänliglogi = new ObservableCollection<Logi>(bokningsKontroller.HämtaTillgängligLogi(Starttid, Sluttid));
            

        });
        #endregion

    }
}
