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
    /// Interaction logic for EditMechanic.xaml
    /// </summary>
    public partial class EditMechanic : Page
    {

        private Mechanic _mechanic;
        private UserService21 _userService;
        private List<Mechanic> _mechanics;
        private DataAccess<Mechanic> _mechanicdb;

        public EditMechanic()
        {
            InitializeComponent();
            _mechanicdb = new DataAccess<Mechanic>();

            _mechanics = _mechanicdb.Load();

            AllMechanics.ItemsSource = _mechanics;

        }


        private void AllMechanics_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
