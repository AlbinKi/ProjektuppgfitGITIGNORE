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

namespace GUI.UserPages.EndErrand
{
    /// <summary>
    /// Interaction logic for EndErrand.xaml
    /// </summary>
    public partial class EndErrand : Page
    {

        private UserService21 _userService;
        private DataAccess<Mechanic> _mechanicdb;
        private List<Errand> errandList;


        public EndErrand()
        {
            InitializeComponent();

            _userService = new UserService21();
            _mechanicdb = new DataAccess<Mechanic>();
            errandList = _userService.ListErrands();
            Errands.ItemsSource = errandList;
        }

        private void Errands_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void EndErrand_button_Click(object sender, RoutedEventArgs e)
        {
            if (Errands.SelectedItem==null)
            {
                MessageBox.Show("Du har inte valt ett ärende.");

                return;
            }

            Errand selectedErrand = (Errand)Errands.SelectedItem;

            _userService.EndActiveErrand(selectedErrand);

            errandList = _userService.ListErrands();
            Errands.ItemsSource = errandList;
        }
    }
}
