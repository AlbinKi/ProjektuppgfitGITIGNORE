using Logic.Entities;
using Logic.Services;
using Logic.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Linq;

namespace GUI.Admin.UserOrMechanic
{
    /// <summary>
    /// Interaction logic for UserAndMechanic.xaml
    /// </summary>
    public partial class UserAndMechanic : Page
    {
        private UserService21 _userservice21;
        private DBService _dbservice;

        private Mechanic _mechanic;
        private List<Mechanic> _mechanics;
        private DataAccess<Mechanic> _mechanicdb;

        //private List<User> _users;
        //private DataAccess<User> _userdb;

        public UserAndMechanic()
        {
            InitializeComponent();
            _userservice21 = new UserService21();
            _dbservice = new DBService();

            _mechanic = new Mechanic();
            _mechanics = new List<Mechanic>();
            _mechanicdb = new DataAccess<Mechanic>();

        }

        private void AddRemoveU_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var box = (ComboBoxItem)(sender as ComboBox).SelectedItem;
            var value = box.Content.ToString();

            if (value == "Lägg till användare" || value == "Ta bort användare")
            {
                Username.Visibility = Visibility.Visible;
                Password.Visibility = Visibility.Visible;
            }
            else
            {
                Username.Visibility = Visibility.Hidden;
                Password.Visibility = Visibility.Hidden;
                Username.Text = "";
            }
        }

        private void AddRemoveUser_Click(object sender, RoutedEventArgs e)
        {
            var username = Username.Text;
            var password = Password.Text;

            var pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            var isCorrect = Regex.IsMatch(username, pattern);
            


            _userservice21.AddUser(username, password, true);

            

            if (isCorrect)
            {
                //AddRemoveUser.Visibility = Visibility.Visible;

                MessageBox.Show("Användaren är skapad");
            }
            else
            {
                //AddRemoveUser.Visibility = Visibility.Visible;
                MessageBox.Show("Ogiltig användarnamn.\nFörsök igen!");
                Username.Clear();
                Password.Clear();
            }
        }

        private void AddRemoveM_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var box = (ComboBoxItem)(sender as ComboBox).SelectedItem;
            var value = box.Content.ToString();

            if (value == "Lägg till bilmekaniker" || value == "Ta bort bilmekaniker")
            {
                Firstname.Visibility = Visibility.Visible;
                Lastname.Visibility = Visibility.Visible;
                DOB.Visibility = Visibility.Visible;
            }
            else
            {
                Username.Visibility = Visibility.Hidden;
                Password.Visibility = Visibility.Hidden;
                DOB.Visibility = Visibility.Hidden;
                //Username.Text = "";
            }
        }
        /// <summary>
        /// Admin lägger till bilmekaniker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddRemoveMechanic_Click(object sender, RoutedEventArgs e)
        {
            string firstName = Firstname.Text;
            string lastName = Lastname.Text;
            DateTime dob = DOB.DisplayDate;


            var _mechanic = _userservice21.AddMechanic(firstName, lastName, dob);
            _mechanics.Add(_mechanic);
            //_dbservice.SaveEntity(_mechanic);

            MessageBox.Show("Bilmekaniker har lagts till"); 
        }

        private void AddRemoveS_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var box = (ComboBoxItem)(sender as ComboBox).SelectedItem;
            var value = box.Content.ToString();

            if (value == "Lägg till kompetens" || value == "Ta bort kompetens")
            {
                fiveSkills.Visibility = Visibility.Visible;
            }
            else
            {
                fiveSkills.Visibility = Visibility.Hidden;
            }
        }

        private void RemoveMechanic_Click(object sender, RoutedEventArgs e)
        {
            _userservice21.RemoveMechanic(_mechanic);
            MessageBox.Show("Bilmekaniker har tagits bort");
        }

        //private void MechanicList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{

        //}
    }
}
