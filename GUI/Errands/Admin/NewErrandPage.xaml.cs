using GUI.ErrandScreen;
using GUI.Validators;
using Logic.Entities;
using Logic.Entities.Vehicles;
using Logic.Services;
using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using MessageBox = System.Windows.MessageBox;

namespace GUI.Errands.Admin.NewErrand
{
    /// <summary>
    /// Interaction logic for NewErrandPage.xaml
    /// </summary>
    public partial class NewErrandPage : Page
    {
        private ErrandService _errandservice; 
        private Errand _errand;


        public NewErrandPage()
        {
            InitializeComponent();
            _errandservice = new ErrandService();
            _errand = new Errand();
            //Binder sidans datakontext till ett ärende
            this.DataContext = _errand;
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
                CarType.Visibility = Visibility.Visible;
                CarType.SelectedIndex = 0;
            }
            else
            {
                Towbar1.Visibility = Visibility.Hidden;
                Towbar1.IsChecked = false;
                Towbar2.Visibility = Visibility.Hidden;
                Towbar2.IsChecked = true;
                CarType.Visibility = Visibility.Hidden;
                CarType.SelectedIndex = 1;
            }

            if (value == "Lastbil")
            {
                MaxLoad.Text = "";
                MaxLoad.Visibility = Visibility.Visible;

            }
            else
            {
                MaxLoad.Visibility = Visibility.Hidden;
                MaxLoad.Text = "0";
            }

            if (value == "Buss")
            {
                MaxPassenger.Text = "";
                MaxPassenger.Visibility = Visibility.Visible;
            }
            else
            {
                MaxPassenger.Visibility = Visibility.Hidden;
                MaxPassenger.Text = "0";
            }

            if (value == "Motorcykel")
            {
                MaxSpeed.Text = "";
                MaxSpeed.Visibility = Visibility.Visible;
            }
            else
            {
                MaxSpeed.Visibility = Visibility.Hidden;
                MaxSpeed.Text = "0";
            }
            #endregion
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
        
            MechanicsAvailable.ItemsSource = _errandservice.AvailableMechanics(value);

            if (MechanicsAvailable.Items.Count == 0)
            {
                var noMechanic = new string[] { "Väntar på ledig mekaniker" };

                MechanicsAvailable.ItemsSource = noMechanic;        
            }          
        }

        /// <summary>
        /// Lägger till ärendet när AddErrandknappen trycks ned
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddErrand_CLICK(object sender, RoutedEventArgs e)
        {
            #region Kollar om inmatningarna är giltiga annars kliver den ut ur metoden
            NewErrandValidator ev = new NewErrandValidator()
            {
                Description = Description.Text,
                Issue = Issue.Text,
                MechanicID = MechanicsAvailable.SelectedValuePath,
                RegistrationNumber = RegistrationNumber.Text,
                VehicleType = VehicleType.Text,
                Model = Model.Text,
                FuelType = FuelType.Text,
                Odometer = Odometer.Text,
                MaxSpeed = MaxSpeed.Text,
                MaxLoad = MaxLoad.Text,
                MaxPassenger = MaxPassenger.Text,
                CarType = CarType.Text
            };

            var results = ev.Validate(ev);
            if (!results.IsValid)
            {
                var sb = new StringBuilder();
                foreach (var failure in results.Errors)
                {
                    sb.Append($"{failure.ErrorMessage}\n");
                }
                MessageBox.Show(sb.ToString());
                return;
            }
            #endregion

            //All kod under denna kommentar körs endast om datan användaren matat in är giltiga
            #region Sparandet av fordon till databasen
            //Skapar upp fordon
            switch (VehicleType.Text)
            {
                case "Bil":
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
                        var vehicle = new Car(Model.Text, RegistrationNumber.Text, int.Parse(Odometer.Text), FuelType.Text, towbar, CarType.Text);
                        DBService.Save(vehicle);
                        break;
                    }
                case "Lastbil":
                    {
                        var vehicle = new Truck(Model.Text, RegistrationNumber.Text, int.Parse(Odometer.Text), FuelType.Text, int.Parse(MaxLoad.Text));
                        DBService.Save(vehicle);
                        break;
                    }
                case "Motorcykel":
                    {
                        var vehicle = new Motorcycle(Model.Text, RegistrationNumber.Text, int.Parse(Odometer.Text), FuelType.Text, int.Parse(MaxSpeed.Text));
                        DBService.Save(vehicle);
                        break;
                    }
                case "Buss":
                    {
                        var vehicle = new Bus(Model.Text, RegistrationNumber.Text, int.Parse(Odometer.Text), FuelType.Text, int.Parse(MaxPassenger.Text));
                        DBService.Save(vehicle);
                        break;
                    }
            }
            #endregion
               
            

            if (MechanicsAvailable.SelectedItem is Mechanic)
            {
                var mechanic = MechanicsAvailable.SelectedItem as Mechanic;
                mechanic.NumberOfErrands += 1;
                DBService.Modify(mechanic);
            }
            
           
            //Sparar ärendet till databasen
            DBService.Save(_errand);

            //Går tillbaka till föregående sida
            ErrandPageAdmin page = new ErrandPageAdmin();
            NavigationService.Navigate(page);          
        }
    }
}

