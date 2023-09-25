using PresentationslagerWPF.Services;
using PresentationslagerWPF.Views;
using PresentationslagerWPF.ViewModels;
using System.Windows;
using Affärslager;

namespace PresentationslagerWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        { 
            
            BokningsKontroller bokningsKontroller = new BokningsKontroller();

            bokningsKontroller.LaddaData();
            MainWindow = new MainWindow()
            {
            DataContext = new MainViewModel()

            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
