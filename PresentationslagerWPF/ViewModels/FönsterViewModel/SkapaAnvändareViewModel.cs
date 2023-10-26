using Affärslager;
using Entiteter.Personer;
using PresentationslagerWPF.Commands;
using PresentationslagerWPF.Models;
using PresentationslagerWPF.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PresentationslagerWPF.ViewModels.FönsterViewModel
{
    public class SkapaAnvändareViewModel : ObservableObject
    {
        private IWindowService windowService;
        AnvändarKontroller användarKontroller = new AnvändarKontroller();


        public SkapaAnvändareViewModel()
        {
            this.windowService = new WindowService();
            Behörighet = new ObservableCollection<int> { 1, 2, 3, 4, 5};
        }

        #region COMMANDS
        private ICommand spara = null!;
        public ICommand Spara => spara ??= spara = new RelayCommand(() =>
        {
            try
            {
                användarKontroller.SkapaAnvändare(new Användare(SelectedItemBehörighetsnivå, Användarnamn, Lösenord, Förnamn, Efternamn));
                MessageBox.Show("Användare Skapad", "Skapad Användare", MessageBoxButton.OK);
                RensaVärden();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ange Korrekt format", "Skapad Användare", MessageBoxButton.OK);
            }

        });
        #endregion

        private ObservableCollection<int> behörighet = null!;
        public ObservableCollection<int> Behörighet
        {
            get => behörighet;
            set
            {
                behörighet = value; OnPropertyChanged();

            }
        }


        public void RensaVärden()
        {
            Förnamn = null;
            Efternamn = null;
            Användarnamn = null;
            Lösenord = null;
            SelectedItemBehörighetsnivå = 0;

        }

        public void Kontroll()
        {



            Förnamn = null;
            Efternamn = null;
            Användarnamn = null;
            Lösenord = null;
            SelectedItemBehörighetsnivå = 0;

        }

        #region  PROPERTIES

        private int selectedItemBehörighetsnivå;
        public int SelectedItemBehörighetsnivå
        {
            get { return selectedItemBehörighetsnivå; }
            set
            {
                selectedItemBehörighetsnivå = value; OnPropertyChanged();

            }
        }
        private string förnamn;
        public string Förnamn
        {
            get { return förnamn; }
            set
            {
                förnamn = value; OnPropertyChanged();

            }
        }
        private string efternamn;
        public string Efternamn
        {
            get { return efternamn; }
            set
            {
                efternamn = value; OnPropertyChanged();

            }
        }

        private string användarnamn;
        public string Användarnamn
        {
            get { return användarnamn; }
            set
            {
                användarnamn = value; OnPropertyChanged();

            }
        }
        private string lösenord;
        public string Lösenord
        {
            get { return lösenord; }
            set
            {
                lösenord = value; OnPropertyChanged();

            }
        }
        private int behörighetsnivå;
        public int Behörighetsnivå
        {
            get { return behörighetsnivå; }
            set
            {
                behörighetsnivå = value; OnPropertyChanged();

            }
        }
        #endregion

    }
}
