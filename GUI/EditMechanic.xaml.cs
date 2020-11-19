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
        private MechanicService _mechanicService;
        private List<Mechanic> _mechanics;
        private IDataAccess<Mechanic> _mechanicdb;

        public EditMechanic()
        {
            InitializeComponent();
            _mechanicdb = new DataAccess<Mechanic>();
            _mechanicService = new MechanicService();

            _mechanics = _mechanicdb.Load();

            AllMechanics.ItemsSource = _mechanics;
        }


        private void AllMechanics_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _mechanic = (Mechanic)AllMechanics.SelectedItem;
            if (_mechanic !=null)
            {
                FirstName.Text = _mechanic.FirstName;
                LastName.Text = _mechanic.LastName;
                NewBirthDate.DisplayDate = _mechanic.DateOfBirth;
                NewBirthDate.Text = _mechanic.DateOfBirth.ToString();
                SetEndDate.DisplayDate = _mechanic.EndDate;
                SetEndDate.Text = _mechanic.EndDateString;
            }
            
        }

        private void SaveMechanic_click(object sender, RoutedEventArgs e)
        {
            if (AllMechanics.SelectedItem==null)
            {
                return;
            }
            
            _mechanic.FirstName = FirstName.Text;
            _mechanic.LastName = LastName.Text;
            _mechanic.DateOfBirth = (DateTime)NewBirthDate.SelectedDate;
            _mechanic.Age = _mechanicService.CalculateAge(_mechanic.DateOfBirth);
            _mechanic.EndDate = (DateTime)SetEndDate.SelectedDate;
            _mechanic.EndDateString = _mechanic.EndDate.ToString("yyy/MM/dd");
            DBService.Modify(_mechanic);
            MessageBox.Show("Mekanikern är sparad.");
            _mechanics = _mechanicdb.Load();
            AllMechanics.ItemsSource = _mechanics;
            FirstName.Text = null;
            LastName.Text = null;
            NewBirthDate.SelectedDate = null;
        }

        private void FirstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void LastName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
