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
using Logic.Services;
using Logic.DAL;

namespace GUI.Errands.Admin.NewErrand
{
    /// <summary>
    /// Interaction logic for NewErrandPage.xaml
    /// </summary>
    public partial class NewErrandPage : Page
    {
        private static readonly Regex _regexonlynumbers = new Regex("[^0-9]+"); //Ser till så det bara går att lägga in siffror i Textboxen
        private static readonly Regex _regexregisternumber = new Regex("[A-Öa-ö0-9]{2,7}");
        private ErrandService _errandservice;
        private DBService _dbservice;

        public NewErrandPage()
        {
            InitializeComponent();
            _errandservice = new ErrandService();
            _dbservice = new DBService();
        }

        /// <summary>
        /// Kollar vilken fordonstyp som användaren har valt och visar korresponderande fråga till användaren
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VehicleType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Value == fordonstypen som eftersöks
            var box = (ComboBoxItem)(sender as ComboBox).SelectedItem;
            var value = box.Content.ToString();

            //Olika frågor visas beroende på vilken fordonstyp som matas in
            #region Fordonstyper
            if (value == "Bil")
            {
                Towbar1.Visibility = Visibility.Visible;
                Towbar2.Visibility = Visibility.Visible;
                Towbar2.IsChecked = true;
            }
            else
            {
                Towbar1.Visibility = Visibility.Hidden;
                Towbar1.IsChecked = false;
                Towbar2.Visibility = Visibility.Hidden;
                Towbar2.IsChecked = false;
            }

            if (value == "Lastbil")
            {
                MaxLoad.Visibility = Visibility.Visible;
            }
            else
            {
                MaxLoad.Visibility = Visibility.Hidden;
                MaxLoad.Text = "";
            }
           
            if (value == "Buss")
            {
                MaxPassenger.Visibility = Visibility.Visible;
            }
            else
            {
                MaxPassenger.Visibility = Visibility.Hidden;
                MaxPassenger.Text = "";
            }
           
            if (value == "Motorcykel")
            {
                MaxSpeed.Visibility = Visibility.Visible;
            }
            else
            {
                MaxSpeed.Visibility = Visibility.Hidden;
                MaxSpeed.Text = "";
            }
            #endregion
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
            }
        }

        private void RegistrationNumber_LOSTFOCUS(object sender, RoutedEventArgs e)
        {
            var textbox = sender as WatermarkTextBox;
            if (IsRegisterNotNumberAllowed(textbox.Text))
            {
                MessageBox.Show("Ange endast 2-7 tecken");
                textbox.Text = "";
            }
        }

        /// <summary>
        /// Lägger till ärendet när AddErrandknappen trycks ned
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddErrand_CLICK(object sender, RoutedEventArgs e)
        {
            #region Parametrar för ärende
            var issuebox = (ComboBoxItem)Issue.SelectedItem;
            var issue = issuebox.Content.ToString();
            var description = Description.Text;
            
            var mechanic = MechanicsAvailable.SelectedItem as Mechanic;

            string mechanicID;
            if (mechanic == null)
            {
                mechanicID = MechanicsAvailable.SelectedItem as string;
            }
            else
            {
                mechanicID = mechanic.MechanicID.ToString();
            }
            #endregion

            #region Parametrar för fordonet
            var model = Model.Text;
            var registrationnumber = RegistrationNumber.Text;
            var odometer = int.Parse(Odometer.Text);
            var fueltype = FuelType.Text;
            var controller = (ComboBoxItem)VehicleType.SelectedItem;
            var vehicletype = controller.Content.ToString();
            #endregion

            #region Skapandet av fordon och ärenden
            //Skapar upp en bil
            if (vehicletype == "Bil")
            {
                var towbar = false;
                if (Towbar1.IsChecked == true)
                {
                    towbar = true;
                }
                else
                {
                    towbar = false;
                }
                var vehicle = new Car(model, registrationnumber, odometer, fueltype, towbar);
                Errand errand = new Errand(description, vehicle.RegistrationNumber, issue, mechanicID, true);
                _dbservice.SaveEntity(vehicle);
                _dbservice.SaveEntity(errand);
            }

            //Skapar upp en lastbil
            else if (vehicletype == "Lastbil")
            {
                var maxload = int.Parse(MaxLoad.Text);
                var vehicle = new Truck(model, registrationnumber, odometer, fueltype, maxload);
                Errand errand = new Errand(description, vehicle.RegistrationNumber, issue, mechanicID, true);
                _dbservice.SaveEntity(vehicle);
                _dbservice.SaveEntity(errand);
            }

            //Skapar upp en buss
            else if (vehicletype == "Buss")
            {
                var maxpassengers = int.Parse(MaxPassenger.Text);
                var vehicle = new Bus(model, registrationnumber, odometer, fueltype, maxpassengers);
                Errand errand = new Errand(description, vehicle.RegistrationNumber, issue, mechanicID, true);
                _dbservice.SaveEntity(vehicle);
                _dbservice.SaveEntity(errand);
            }

            //Skapar upp en motorcykel
            else if (vehicletype == "Motorcykel")
            {
                var maxspeed = int.Parse(MaxSpeed.Text);
                var vehicle = new Motorcycle(model, registrationnumber, odometer, fueltype, maxspeed);
                Errand errand = new Errand(description, vehicle.RegistrationNumber, issue, mechanicID, true);
                _dbservice.SaveEntity(vehicle);
                _dbservice.SaveEntity(errand);
            }
            #endregion 
        }

        /// <summary>
        /// Returnerar om texten stämmer överens med den skapade regexen
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static bool IsTextAllowed(string text)
        {
            return !_regexonlynumbers.IsMatch(text);
        }

        private static bool IsRegisterNotNumberAllowed(string text)
        {
            return !_regexregisternumber.IsMatch(text);
        }

        /// <summary>
        /// Matchar mekaniker med det valda ärendet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Issue_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MechanicsAvailable.ItemsSource = null;
            var box = (ComboBoxItem)(sender as ComboBox).SelectedItem;
            var value = box.Content.ToString();

            var _mechanics = _errandservice.AvailableMechanics(value);
            MechanicsAvailable.ItemsSource = _mechanics;

            if (MechanicsAvailable.Items.Count == 0)
            {
                 var noMechanic = new string[] { "Väntar på ledig mekaniker"};

                MechanicsAvailable.ItemsSource = noMechanic;
            }
            
        }
    }
}
