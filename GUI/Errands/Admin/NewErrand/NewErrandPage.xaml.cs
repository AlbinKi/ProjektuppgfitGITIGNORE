using System;
using System.Collections.Generic;
using System.Security.Cryptography.Xml;
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
using Logic.Entities;
using Logic.Entities.Vehicles;
using System.Text.RegularExpressions;
using Xceed.Wpf.Toolkit;
using MessageBox = System.Windows.MessageBox;

namespace GUI.Errands.Admin.NewErrand
{
    /// <summary>
    /// Interaction logic for NewErrandPage.xaml
    /// </summary>
    public partial class NewErrandPage : Page
    {
        private static readonly Regex _regex = new Regex("[^0-9]+"); //Ser till så det bara går att lägga in siffror i Textboxen
        public NewErrandPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Kollar vilken fordonstyp som användaren har valt och visar korresponderande fråga till användaren
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VehicleType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Möjliggör inmatning av fordon först när användaren valt fordonstyp
            if (VehicleType.SelectedIndex != 0)
            {
                VehicleEntry.IsEnabled = true;
            }

            //Value == fordonstypen som eftersöks
            var box = (ComboBoxItem)(sender as ComboBox).SelectedItem;
            var value = box.Content.ToString();


            //Olika frågor visas beroende på vilken fordonstyp som matas in
            if (value == "Bil")
            {
                Towbar1.Visibility = Visibility.Visible;
                Towbar2.Visibility = Visibility.Visible;
            }
            else
            {
                Towbar1.Visibility = Visibility.Hidden;
                Towbar2.Visibility = Visibility.Hidden;
            }

            if (value == "Lastbil")
            {
                MaxLoad.Visibility = Visibility.Visible;
            }
            else
            {
                MaxLoad.Visibility = Visibility.Hidden;
            }
           
            if (value == "Buss")
            {
                MaxPassenger.Visibility = Visibility.Visible;
            }
            else
            {
                MaxPassenger.Visibility = Visibility.Hidden;
            }
           
            if (value == "Motorcykel")
            {
                MaxSpeed.Visibility = Visibility.Visible;
            }
            else
            {
                MaxSpeed.Visibility = Visibility.Hidden;
            }
           
        }
     
        /// <summary>
        /// Ser till så att bara numeriska värden kan fyllas i i de textrutor som innehar metoden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Numeric_LOSTFOCUS(object sender, RoutedEventArgs e)
        {
            var textbox = sender as WatermarkTextBox;
            if (!IsTextAllowed(textbox.Text))
            {
                MessageBox.Show("Mata in svaret i siffror!");
                textbox.Text = "";
                AddErrand.IsEnabled = false;
            }
            else
            {
                AddErrand.IsEnabled = true;
            }
        }

        /// <summary>
        /// Lägger till ärendet när AddErrandknappen trycks ned
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddErrand_CLICK(object sender, RoutedEventArgs e)
        {
            var box = (ComboBoxItem)Issue.SelectedItem;
            var issue = box.Content.ToString();
            var description = Description.Text;
            var modell = Modell.Text;
            var registrationnumber = RegistrationNumber.Text;
            var odometer = int.Parse(Odometer.Text);

            var maxload = int.Parse(MaxLoad.Text);
            var maxspeed = int.Parse(MaxSpeed.Text);
            var maxpassenger = int.Parse(MaxPassenger.Text);



        }

        /// <summary>
        /// Returnerar om texten stämmer överens med den skapade regexen
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }
    }
}
