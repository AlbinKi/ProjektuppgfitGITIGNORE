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
    public partial class AddMechanic : Page
    {
        private UserService21 _userservice;
        private MechanicService _mechanicService;

        private Mechanic _mechanic;
        private List<Mechanic> _mechanics;
        private DataAccess<Mechanic> _mechanicdb;

        public AddMechanic()
        {
            InitializeComponent();
            _userservice = new UserService21();
            _mechanicService = new MechanicService();

            _mechanic = new Mechanic();
            _mechanics = new List<Mechanic>();
            _mechanicdb = new DataAccess<Mechanic>();

        }
       
        /// <summary>
        /// Admin lägger till bilmekaniker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddMechanic_Click(object sender, RoutedEventArgs e)
        {
            if(Firstname.Text == "" || Lastname.Text == "" || DOB.SelectedDate == null)
            {
                MessageBox.Show("Fyll i alla fälten");
                return;
            }

            string firstName = Firstname.Text;
            string lastName = Lastname.Text;
            DateTime dob = DOB.DisplayDate;

            
            var _mechanic = _mechanicService.AddMechanic(firstName, lastName, dob);
            


            MessageBox.Show($"Bilmekaniker {Firstname.Text} {Lastname.Text} har lagts till");
            Firstname.Clear();
            Lastname.Clear();
        }
    }
}




