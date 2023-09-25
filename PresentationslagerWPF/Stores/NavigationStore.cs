using PresentationslagerWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationslagerWPF.Stores
{
    public class NavigationStore
    {

        public event Action CurrentViewModelChanged;

        private ObservableObject _currentViewModel;

        public ObservableObject CurrentViewModel 
        { 
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }      
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }

    }
}
