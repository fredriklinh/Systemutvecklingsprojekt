using PresentationslagerWPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
        public SecureString SecurePassword {  get; set; }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((dynamic)this.DataContext).Password = ((PasswordBox)sender).Password; }
        }
    }
}
