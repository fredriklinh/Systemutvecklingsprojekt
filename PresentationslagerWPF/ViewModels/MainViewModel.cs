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

namespace PresentationslagerWPF.ViewModels
{
    public class MainViewModel : ObservableObject
    {

        //****NAVIGATION*****//
        public ObservableObject CurrentViewModel { get; }


        //OBS. VÅR KONTROLLER HÄR
        //private BokningKontroller bokningsKontroller;
        private IWindowService windowService;

        //Konstruktor

        public MainViewModel()
        {
            CurrentViewModel = new HomeViewModel();
            //OBS. VÅR KONTROLLER HÄR
            //bokningsKontroller = new BokningKontroller();
        }

    }
}

