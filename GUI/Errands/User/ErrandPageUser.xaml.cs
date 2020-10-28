using GUI.Errands.User.EndErrand;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI.Errands.User
{
    /// <summary>
    /// Interaction logic for ErrandPageUser.xaml
    /// </summary>
    public partial class ErrandPageUser : Page
    {
        public ErrandPageUser()
        {
            InitializeComponent();
        }

        private void EndErrand_CLICK(object sender, RoutedEventArgs e)
        {
            var endErrand = new EndErrandPageUser();

            NavigationService.Navigate(endErrand);
        }
    }
}
