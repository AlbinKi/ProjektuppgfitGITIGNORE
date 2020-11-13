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
        
        private Mechanic _mechanic;
        private List<Mechanic> _mechanics;
        private DataAccess<Mechanic> _mechanicdb;

        private User2 _user;
        private List<User2> _users;
        private DataAccess<User2> _userdb;

        public UserAndMechanic()
        {
            InitializeComponent();
            _userservice21 = new UserService21();

            _mechanic = new Mechanic();
            _mechanics = new List<Mechanic>();
            _mechanicdb = new DataAccess<Mechanic>();

        }
        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            User1.Items.Add(Username.Text);

            var username = Username.Text;
            var password = Password.Text;

            var pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            var isCorrect = Regex.IsMatch(username, pattern);
            
            _userservice21.AddUser(username, password, true);

            // tillagda bilmekaniker i wpf
            AddRemoveM.Items.Add(Firstname.Text + " " + Lastname.Text + " " + DOB.DisplayDate);


            if (isCorrect)
            {
                MessageBox.Show("Användaren är skapad");
                Username.Clear();
                Password.Clear();
            }
            else
            {
                MessageBox.Show("Ogiltig användarnamn.\nFörsök igen!");
                Username.Clear();
                Password.Clear();
            }

        }

        private void RemoveUser_Click(object sender, RoutedEventArgs e)
        {
            User1.Items.RemoveAt(User1.Items.IndexOf(User1.SelectedItem));

            _users = new List<User2>();
            _user = (User2)User1.SelectedItem;
            _userservice21.RemoveUser(_user);
            //_userservice21.RemoveUser(User1.SelectedItem as User2);


            MessageBox.Show("Användaren är borttagen");
        }


        /// <summary>
        /// Admin lägger till bilmekaniker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddMechanic_Click(object sender, RoutedEventArgs e)
        {
            _mechanics = _mechanicdb.Load();

            AddRemoveM.Items.Add(Firstname.Text + " " + Lastname.Text + " " + DOB.DisplayDate);

            string firstName = Firstname.Text;
            string lastName = Lastname.Text;
            DateTime dob = DOB.DisplayDate;

            _mechanics = new List<Mechanic>();
            var _mechanic = _userservice21.AddMechanic(firstName, lastName, dob);
            _mechanics.Add(_mechanic);

            _mechanicdb.Save(_mechanics);

            MessageBox.Show($"Bilmekaniker {Firstname.Text} {Lastname.Text} har lagts till");

            Firstname.Clear();
            Lastname.Clear();
        }
        /// <summary>
        /// Admin tar bort bilmekaniker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveMechanic_Click(object sender, RoutedEventArgs e)
        {
            _mechanics = _mechanicdb.Load();

            AddRemoveM.Items.RemoveAt(AddRemoveM.Items.IndexOf(AddRemoveM.SelectedItem));

            //_mechanics = new List<Mechanic>();
            //_mechanic = (Mechanic)AddRemoveM.SelectedItem;
            //_mechanics.Remove(_mechanic);
            
            _userservice21.RemoveMechanic(_mechanic); // tar ej bort från db?
            
            //_mechanicdb.Save(_mechanics); 

            MessageBox.Show($"Bilmekaniker har tagits bort");
        }

        private void AddSkill_Click(object sender, RoutedEventArgs e)
        {
            string skill = (string)fiveSkillsBreaks.SelectionBoxItem + " " + (string)fiveSkillsEngine.SelectionBoxItem + " " + (string)fiveSkillsBody.SelectionBoxItem + " " +
                            (string)fiveSkillsWindshields.SelectionBoxItem + " " + (string)fiveSkillsTire.SelectionBoxItem;


            //var skill = fiveskills.Text;
            
            _userservice21.AddSkill(_mechanic, skill);
        }
    }
}




