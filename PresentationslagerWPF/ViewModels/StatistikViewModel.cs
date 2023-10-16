using Entiteter.Personer;
using PresentationslagerWPF.Models;
using PresentationslagerWPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PresentationslagerWPF.Commands;
using PresentationslagerWPF.Services;
using ScottPlot;
using System.Windows.Markup;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PresentationslagerWPF.ViewModels
{
    public class StatistikViewModel : ObservableObject
    {
        
        #region NAVIGATION
        public StatistikViewModel(NavigationStore navigationStore, Användare användare)
        {

            NavigateLoggaUtCommand = new NavigateCommand<LoggaInViewModel>(new NavigationService<LoggaInViewModel>(navigationStore, () => new LoggaInViewModel(navigationStore)));
            TillbakaCommand = new NavigateCommand<HuvudMenyViewModel>(new NavigationService<HuvudMenyViewModel>(navigationStore, () => new HuvudMenyViewModel(navigationStore, användare)));
        }
        public ICommand NavigateLoggaUtCommand { get; }

        private ICommand exitCommand = null!;
        public ICommand ExitCommand =>
        exitCommand ??= exitCommand = new RelayCommand(() => App.Current.Shutdown());

        public ICommand TillbakaCommand { get; }
        #endregion

        #region TEST
        
        
        
        #endregion

    }


}