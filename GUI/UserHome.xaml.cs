using GUI.Admin.UserAndMechanic;
using GUI.Admin.UserOrMechanic;
using GUI.Errands.Admin;
using GUI.Errands.Admin.NewErrand;
using GUI.ErrandScreen;
using GUI.Home;
using GUI.UserPages.EndErrand;
using GUI.UserPages.Skills;
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
    /// Interaction logic for UserHome.xaml
    /// </summary>
    public partial class UserHome : Window
    {
       
        public UserHome()
        {
            InitializeComponent();

            var us = new UserService21();
            ThisUser.Text = CurrentUser.user.Username;            
            var mechanic = us.NextBirthday();
            Birthday.Text = $"{mechanic.FirstName} {mechanic.LastName} fyller år om {us.DaysUntilBirthday(mechanic)} dagar.";

            Tab1.Header = "Avsluta ett av dina ärenden";
            Tab2.Header = "Ändra på dina kompetenser";
            PageView1.Content = new EndErrand();
            PageView2.Content = new UpdateSkills();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow login = new MainWindow();
            login.Show();
            GetWindow(this).Close();
        }
    }

}
