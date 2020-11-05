using GUI.Errands.Admin;
using GUI.Errands.Admin.NewErrand;
using Logic.Entities;
using Logic.Services;
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
            ErrandService es = new ErrandService();
            if (es.UnassignedErrands() == null)
            {
                ErrandMechanic.IsEnabled = false;
            }
            InitializeComponent();
        }

        private void NewErrand_CLICK(object sender, RoutedEventArgs e)
        {
            var newErrand = new NewErrandPage();
            this.NavigationService.Navigate(newErrand);
        }
        private void ErrandStatus_CLICK(object sender, RoutedEventArgs e)
        {
            var errandStatus = new ErrandStatus();
            this.NavigationService.Navigate(errandStatus);
        }
        private void ErrandMechanic_CLICK(object sender, RoutedEventArgs e)
        {
            var errandMechanic = new ErrandMechanic();
            this.NavigationService.Navigate(errandMechanic);
        }

    }
}
