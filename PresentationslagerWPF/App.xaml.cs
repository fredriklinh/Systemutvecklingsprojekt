using PresentationslagerWPF.Services;
using PresentationslagerWPF.Views;
using PresentationslagerWPF.ViewModels;
using System.Windows;
using Affärslager;
using PresentationslagerWPF.Stores;

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

            HuvudMenyViewModel h = new HuvudMenyViewModel(navigationStore);
            MasterBokningViewModel n = new MasterBokningViewModel(navigationStore);

            //navigationStore.CurrentViewModel = new HomeViewModel(navigationStore);
            navigationStore.CurrentViewModel = new MasterBokningViewModel(navigationStore);


            AnvändarKontroller användarKontroller = new AnvändarKontroller();

            användarKontroller.LaddaData();
            MainWindow = new MainWindow()
            {
                //DataContext = new MainViewModel(navigationStore)
                DataContext = new MainViewModel(navigationStore)


            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
