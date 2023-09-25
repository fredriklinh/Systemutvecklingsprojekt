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

namespace PresentationslagerWPF.ViewModels
{
    public class MainViewModel : ObservableObject
    {

        //****NAVIGATION*****//
        public ObservableObject CurrentViewModel { get; }



        private BokningsKontroller bokningsKontroller;
        private IWindowService windowService;

        //Konstruktor

        public MainViewModel()
        {
            CurrentViewModel = new HomeViewModel();
            bokningsKontroller = new BokningsKontroller();
        }

    }
}

