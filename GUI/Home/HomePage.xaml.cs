using GUI.ErrandScreen;
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

namespace GUI.Home
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }

        public void Errand_CLICK(object sender, RoutedEventArgs e)
        {
            ErrandPageAdmin errandPage = new ErrandPageAdmin();

            this.NavigationService.Navigate(errandPage);
        }

        public void Skills_CLICK(object sender, RoutedEventArgs e)
        {

        }
    }
}
