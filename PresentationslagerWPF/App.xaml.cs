using Affärslager;
using PresentationslagerWPF.Services;
using PresentationslagerWPF.Stores;
using PresentationslagerWPF.ViewModels;
using PresentationslagerWPF.ViewModels.FönsterViewModel;
using PresentationslagerWPF.Views.Fönster;
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
            NavigationStore navigationStore = new NavigationStore();
            AnvändarKontroller användarKontroller = new AnvändarKontroller();

            Startup += (s, e) =>
            {
                WindowService.RegisterWindow<SkapaAnvändareViewModel, SkapaAnvändareWindow>();

            };

            navigationStore.CurrentViewModel = new LoggaInViewModel(navigationStore);


            användarKontroller.LaddaData();
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(navigationStore)

            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
