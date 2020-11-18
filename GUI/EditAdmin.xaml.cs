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
    /// Interaction logic for EditAdmin.xaml
    /// </summary>
    public partial class EditAdmin : Page
    {
        private IDataAccess<User> _userdb;
        private User _user;
        private List<User> _users;
        private UserService _userService;
        
        public EditAdmin()
        {
            InitializeComponent();
            _userdb = new DataAccess<User>();
            _userService = new UserService();

            NotAdminList.ItemsSource = _userService.UserNotAdmin();
            IsAdminList.ItemsSource = _userService.UserIsAdmin();
        }

        private void NotAdminList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void IsAdminList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddAdminClick(object sender, RoutedEventArgs e)
        {
            if (NotAdminList.SelectedItem == null)
            {
                return;
            }

            _user = NotAdminList.SelectedItem as User;
            _user.Admin = true;
            DBService.Modify(_user);
            NotAdminList.ItemsSource = _userService.UserNotAdmin();
            IsAdminList.ItemsSource = _userService.UserIsAdmin();
        }

        private void RemoveAdminClick(object sender, RoutedEventArgs e)
        {

            if (IsAdminList.SelectedItem==null)
            {
                return;
            }

            _user = IsAdminList.SelectedItem as User;
            _user.Admin = false;
            DBService.Modify(_user);
            NotAdminList.ItemsSource = _userService.UserNotAdmin();
            IsAdminList.ItemsSource = _userService.UserIsAdmin();
        }
    }
}
