using GUI.Admin.UserAndMechanic;
using GUI.Admin.UserOrMechanic;
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
        private Page page1;
        private Page page2;
        private Page page3;
        private Page page4;
        private string menu;
        public HomeMenu()
        {
            var us = new MechanicService();
            InitializeComponent();
            ThisUser.Text = CurrentUser.user.Username;
            Tabs.Visibility = Visibility.Hidden;           
            var mechanic = us.NextBirthday();
            Birthday.Text = $"{mechanic.FirstName} {mechanic.LastName} fyller år om {us.DaysUntilBirthday(mechanic)} dagar.";

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Tab4.Visibility = Visibility.Hidden;

            Tabs.Visibility = Visibility.Visible;

            Tab1.Header = "Skapa en ny användare";
            Tab2.Header = "Radera en användare";
            Tab3.Header = "Ändra admin-status";
            PageView1.Content = new NewUser();
            menu = "användare";
          
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Tabs.Visibility = Visibility.Visible;
            Tab3.Visibility = Visibility.Visible;
            Tab4.Visibility = Visibility.Visible;

            Tab1.Header = "Lägg till en mekaniker";
            Tab2.Header = "Radera en mekaniker";
            Tab3.Header = "Ändra en befintlig mekaniker";
            Tab4.Header = "Lägg till eller ta bort kompetenser";
            PageView1.Content = new AddMechanic();

            menu = "mekaniker";

           
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Tab4.Visibility = Visibility.Hidden;

            Tab3.Visibility = Visibility.Visible;
            Tabs.Visibility = Visibility.Visible;
            Tab1.Header = "Skapa nytt ärende";
            Tab2.Header = "Ändra status på ärenden";
            Tab3.Header = "Lägg till en mekaniker på ärende";
            PageView1.Content = new NewErrandPage();

            menu = "ärende";

        }
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow login = new MainWindow();
            login.Show();
            GetWindow(this).Close();
        }
      
        private void Tabs_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is TabControl)
            {
                switch (menu)
                {
                    case "ärende":
                        {
                            page1 = new NewErrandPage();
                            page2 = new ErrandStatus();
                            page3 = new ErrandMechanic();
                            break;
                        }
                    case "mekaniker":
                        {
                            page1 = new AddMechanic();
                            page2 = new RemoveMechanic();
                            page3 = new EditMechanic();
                            page4 = new AddSkillsToMechanic();
                            break;
                        }
                    case "användare":
                        {
                            page1 = new NewUser();
                            page2 = new RemoveUser();
                            page3 = new EditAdmin();
                            break;

                        }
                }

                PageView1.Content = page1;
                PageView2.Content = page2;
                PageView3.Content = page3;
                PageView4.Content = page4;
            }
            
        }    
    }
}
