using PresentationslagerWPF.Services;
using PresentationslagerWPF.Views;
using PresentationslagerWPF.ViewModels;
using System.Windows;

namespace PresentationslagerWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel()

            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
