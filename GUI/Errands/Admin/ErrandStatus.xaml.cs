using GUI.ErrandScreen;
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

namespace GUI.Errands.Admin
{
    /// <summary>
    /// Interaction logic for ErrandStatus.xaml
    /// </summary>
    public partial class ErrandStatus : Page
    {
        private ErrandService _errandservice;
        private UserService21 _userservice;
        public ErrandStatus()
        {
            _userservice = new UserService21();
            InitializeComponent();
            _errandservice = new ErrandService();
            Errands.ItemsSource = _errandservice.OnGoingErrands();
            FinishedErrands.ItemsSource = _errandservice.FinishedErrands();
        }

        private void EndErrand_Click(object sender, RoutedEventArgs e)
        {
            if (Errands.SelectedItem == null)
            {
                return;
            }
            var errand = Errands.SelectedItem as Errand;
            errand.Status = false;
            var mechanic = _userservice.GetMechanic(errand.MechanicID);
            mechanic.NumberOfErrands -= 1;
            DBService.Modify(mechanic);
            DBService.Modify(errand);
            Errands.ItemsSource = null;
            FinishedErrands.ItemsSource = null;
            Errands.ItemsSource = _errandservice.OnGoingErrands();
            FinishedErrands.ItemsSource = _errandservice.FinishedErrands();

        }
    }
}
