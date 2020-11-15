using GUI.Login;
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
using MessageBox = System.Windows.MessageBox;
using Xceed.Wpf.Toolkit;
using System.Linq;
using Logic.DAL;

namespace GUI
{
    /// <summary>
    /// Interaction logic for NewUser.xaml
    /// </summary>
    public partial class NewUser : Page
    {
        private Mechanic _mechanic;
        private UserService21 _userService;
        private List<Mechanic> _mechanics;
        private DataAccess<Mechanic> _mechanicdb;

        public NewUser()
        {
            InitializeComponent();
            _mechanicdb = new DataAccess<Mechanic>();
            _userService = new UserService21();
            _mechanics = _userService.MechanicNoUser();
            NoUserList.ItemsSource = _mechanics;
        }

        private void NoUserList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddNewUserClick(object sender, RoutedEventArgs e)
        {
            //Bara test nedan! Kollat om regex funkar.
            var userName = UserNameAsEmail.Text;

            if (_userService.TryUsername(userName).Success)
            {
                MessageBox.Show("Korrekt användarnamn!");
            }
            else
            {
                MessageBox.Show("Ange en epost som användarnamn.");
            }

            UserNameAsEmail.Clear();
        }
    }
}
