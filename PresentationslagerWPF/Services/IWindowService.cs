using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationslagerWPF.Services
{
    public interface IWindowService
    {

        void Show<TViewModel>(TViewModel model);
        bool ShowDialog<TViewModel>(TViewModel model);
    }
}
