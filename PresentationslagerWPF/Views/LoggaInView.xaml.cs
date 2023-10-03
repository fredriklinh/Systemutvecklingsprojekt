using System.Security;
using System.Windows;
using System.Windows.Controls;

namespace PresentationslagerWPF.Views
{
    /// <summary>
    /// Interaction logic for LoggaInView.xaml
    /// </summary>
    public partial class LoggaInView : UserControl
    {
        public LoggaInView()
        {
            InitializeComponent();
        }


        //SKA VARA PRIVATE GET
        public SecureString SecurePassword { get; set; }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((dynamic)this.DataContext).Password = ((PasswordBox)sender).Password; }
        }
    }
}
