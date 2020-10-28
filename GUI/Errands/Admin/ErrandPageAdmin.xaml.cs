using GUI.Errands.Admin.NewErrand;
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

namespace GUI.ErrandScreen
{
    /// <summary>
    /// Interaction logic for ErrandPageAdmin.xaml
    /// </summary>
    public partial class ErrandPageAdmin : Page
    {
        public ErrandPageAdmin()
        {
            InitializeComponent();
        }

        private void NewErrand_CLICK(object sender, RoutedEventArgs e)
        {
            var newErrand = new NewErrandPage();
            this.NavigationService.Navigate(newErrand);
        }
    }
}
