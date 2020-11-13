using GUI.Errands.Admin;
using GUI.Errands.Admin.NewErrand;
using GUI.ErrandScreen;
using GUI.UserPages.EndErrand;
using Logic.Entities;
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

namespace GUI
{
    /// <summary>
    /// Interaction logic for homemenu.xaml
    /// </summary>
    public partial class homemenu : Window
    {
        public homemenu()
        {
            InitializeComponent();
            ThisUser.Text = CurrentUser.user.Username;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Tab1.Header = "Skapa nytt ärende";
            Tab2.Header = "Ändra status på ärenden";
            Tab3.Header = "Lägg till en mekaniker på ärende";

            PageView1.Content = new NewErrandPage();
            PageView2.Content = new ErrandStatus();
            PageView3.Content = new ErrandMechanic();
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
