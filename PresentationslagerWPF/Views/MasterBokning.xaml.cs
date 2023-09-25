using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for MasterBokning.xaml
    /// </summary>
    public partial class MasterBokning : Window
    {
        public MasterBokning()
        {
            InitializeComponent();
        }

        private void btnLogi_Click(object sender, RoutedEventArgs e)
        {
            SetActiveUserControl(logi);
        }

        public void SetActiveUserControl(UserControl control)
        {
            logi.Visibility = Visibility.Collapsed;
            konferens.Visibility = Visibility.Collapsed;
            utrustning.Visibility = Visibility.Collapsed;
            lektion.Visibility = Visibility.Collapsed;
            bokningTotal.Visibility = Visibility.Collapsed;

            control.Visibility = Visibility.Visible;
        }
    }
}
