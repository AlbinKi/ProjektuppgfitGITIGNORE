using GUI.Home;
using Logic.DAL;
using Logic.Entities;
using Logic.Exceptions;
using Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace GUI.Login
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private const string _errorMsg = "Inloggningen misslyckades";
        private IDataAccess<User> _userdb;


        private LoginService _loginService;
        public LoginPage()
        {
            _userdb = new DataAccess<User>();
            InitializeComponent();
            ShowsNavigationUI = false;
            _loginService = new LoginService();
        }


        private void Login_Click(object sender, RoutedEventArgs e)
        {

            //string username = "Bosse";
            //string password = "Meckarn123";
            string username = tbUsername.Text;
            string password = pbPassword.Password;


            
                bool successful = _loginService.Login(username, password);

                
           
            if (successful)
            {
                _loginService.GetCurrentUser(username, password);

                if (CurrentUser.user.Admin == true)
                {
                    HomeMenu home = new HomeMenu();
                    home.Show();
                    Window.GetWindow(this).Close();
                } else
                {
                    UserHome home = new UserHome();
                    home.Show();
                    Window.GetWindow(this).Close();
                }
            }
            else
            {
                try
                {
                    if (_userdb.Load().FirstOrDefault(u => u.Username == username) != null)
                        throw new IncorrectPasswordException("Fel lösenord för användaren: ", tbUsername.Text);
                    else
                    {
                        MessageBox.Show(_errorMsg);
                        this.pbPassword.Clear();
                        this.tbUsername.Clear();
                    }
                }
                catch (IncorrectPasswordException ex)
                {
                    MessageBox.Show(ex.Message + ex.UserName);                   
                    this.pbPassword.Clear();
                }              
            }
        }
    }
}