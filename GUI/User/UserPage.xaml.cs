using GUI.User.EndErrand;
using GUI.User.Skills;
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

namespace GUI.User
{
    /// <summary>
    /// Interaction logic for UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        public UserPage()
        {
            InitializeComponent();
        }

        private void UpdateSkills_Click(object sender, RoutedEventArgs e)
        {
            var newUpdateSkills = new UpdateSkills();
            NavigationService.Navigate(newUpdateSkills);
        }

        private void EndErrand_Click(object sender, RoutedEventArgs e)
        {
            var newEndErrand = new EndErrand.EndErrand(); //Varför blir syntax så här??? Se UpdateSkills_Click!!

            NavigationService.Navigate(newEndErrand);
        }
    }
}
