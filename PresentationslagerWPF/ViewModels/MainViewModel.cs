using Affärslager;
using PresentationslagerWPF.Commands;
using PresentationslagerWPF.Models;
using PresentationslagerWPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Affärslager;
using PresentationslagerWPF.Stores;

namespace PresentationslagerWPF.ViewModels
{
    public class MainViewModel : ObservableObject
    {

        private readonly NavigationStore _navigationStore;

        //****NAVIGATION*****//
        public ObservableObject CurrentViewModel => _navigationStore.CurrentViewModel;

        private BokningsKontroller bokningsKontroller;


        //Konstruktor
        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

            bokningsKontroller = new BokningsKontroller();
        }
        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

    }
}

