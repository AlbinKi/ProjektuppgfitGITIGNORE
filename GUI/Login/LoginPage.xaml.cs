
using GUI.Home;
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

namespace GUI.Login
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private const string _errorMsg = "Inloggningen misslyckades";

        private LoginService _loginService;
        public LoginPage()
        {
            InitializeComponent();
            ShowsNavigationUI = false;
            _loginService = new LoginService();
        }
        
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string username = "Bosse";
            string password = "Meckarn123";

            bool successful = _loginService.Login(username, password);

            if (successful)
            {

                _loginService.GetCurrentUser(username, password);
                
                homemenu home = new homemenu();
                home.Show();
                Window.GetWindow(this).Close();
            }
            else
            {

                MessageBox.Show(_errorMsg);
                this.tbUsernam.Clear();
                this.pbPassword.Clear();
            }
        }
    }
}
