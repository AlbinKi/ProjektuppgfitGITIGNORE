using GUI.Errands.Admin;
using GUI.Errands.Admin.NewErrand;
using GUI.ErrandScreen;
using GUI.Home;
using GUI.UserPages.EndErrand;
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

namespace GUI
{
    /// <summary>
    /// Interaction logic for homemenu.xaml
    /// </summary>
    public partial class HomeMenu : Window
    {
        public HomeMenu()
        {
            var us = new UserService21();
            InitializeComponent();
            ThisUser.Text = CurrentUser.user.Username;
            Tabs.Visibility = Visibility.Hidden;
            PageView1.Content = new HomePage();
            var mechanic = us.NextBirthday();
            Birthday.Text = $"{mechanic.FirstName} {mechanic.LastName} fyller år om {us.DaysUntilBirthday(mechanic)} dagar.";

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Tabs.Visibility = Visibility.Visible;

            Tab1.Header = "Skapa en ny användare";
            Tab2.Header = "Radera en användare";
            Tab3.Header = "Lägg till en mekaniker på ärende";

            PageView1.Content = new NewErrandPage();
            PageView2.Content = new ErrandStatus();
            PageView3.Content = new ErrandMechanic();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Tabs.Visibility = Visibility.Visible;

            Tab1.Header = "Lägg till en mekaniker";
            Tab2.Header = "Radera en mekaniker";
            Tab3.Header = "Ändra en befintlig mekaniker";

            PageView1.Content = new NewErrandPage();
            PageView2.Content = new ErrandStatus();
            PageView3.Content = new ErrandMechanic();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Tabs.Visibility = Visibility.Visible;
            Tab1.Header = "Skapa nytt ärende";
            Tab2.Header = "Ändra status på ärenden";
            Tab3.Header = "Lägg till en mekaniker på ärende";

            PageView1.Content = new NewErrandPage();
            PageView2.Content = new ErrandStatus();
            PageView3.Content = new ErrandMechanic();
        }
    }
}
