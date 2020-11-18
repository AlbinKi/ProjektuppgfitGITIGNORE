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
using Logic.Entities;
using Logic.Services;
using Logic.DAL;
using System.Linq;

namespace GUI.Admin.UserAndMechanic
{
    /// <summary>
    /// Interaction logic for RemoveUser.xaml
    /// </summary>
    public partial class RemoveUser : Page
    {

        DataAccess<User> _userDB;
        UserService _userservice;
        private List<User> _users;
        public RemoveUser()
        {

            _userDB = new DataAccess<User>();
            _userservice = new UserService();
            InitializeComponent();
            UpdateList();

        }
        private void RemoveUser_Click(object sender, RoutedEventArgs e)
        {
            if (RemoveList.SelectedItem == null)
            {
                return;
            }

            var user = RemoveList.SelectedItem as User;
            _userservice.RemoveUser(user);
            UpdateList();
        }
       

        private void UpdateList()
        {
            _users = _userDB.Load();
            var user = _users.FirstOrDefault(u => u.UserID == CurrentUser.user.UserID);
            _users.Remove(user);
            RemoveList.ItemsSource = null;
            RemoveList.ItemsSource = _users;
        }
    }   
}
    



