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
            AnvändarKontroller användarKontroller = new AnvändarKontroller();



            //navigationStore.CurrentViewModel = new HomeViewModel(navigationStore);
            navigationStore.CurrentViewModel = new LoggaInViewModel(navigationStore);

            
       

            HuvudMenyViewModel h = new HuvudMenyViewModel(navigationStore);
            MasterBokningViewModel m = new MasterBokningViewModel(navigationStore);


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
