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
        private IDataAccess<Mechanic> _mechanicdb;
        private MechanicService _mechanicService;

        public NewUser()
        {
            InitializeComponent();
            _mechanicdb = new DataAccess<Mechanic>();
            _userService = new UserService21();
            _mechanicService = new MechanicService();
            _mechanics = _mechanicService.MechanicNoUser();
            NoUserList.ItemsSource = _mechanics;
        }

        private void NoUserList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddNewUserClick(object sender, RoutedEventArgs e)
        {
            var userName = UserNameAsEmail.Text;
            var password = Password.Text;
            bool isAdmin = false;

            if (NoUserList.SelectedItem==null)
            {
                MessageBox.Show("Välj först en mekaniker i listan");
                return;
            }
            
            _mechanic = (Mechanic)NoUserList.SelectedItem;
            var userGuid = _mechanic.MechanicID;

            if ((bool)IsAdminCheck.IsChecked)
            {
                isAdmin = true;
            }

            if (!_userService.TryUsername(userName).Success)
            {
                MessageBox.Show("Ange en epostadress som användarnamn.");
                UserNameAsEmail.Clear();
                return;
            }
            else if (!_userService.TryPassword(password).Success)
            {
                MessageBox.Show("Ange ett lämpligt lösenord!");
                Password.Clear();
                return;
            }
            else
            {
                _userService.AddUser(userName, password, isAdmin, userGuid);
                MessageBox.Show("Användaren har sparats.");
            }

            UserNameAsEmail.Clear();
            Password.Clear();
            IsAdminCheck.IsChecked = false;
            _mechanics = _mechanicService.MechanicNoUser();
            NoUserList.ItemsSource = _mechanics;

        }
    }
}
