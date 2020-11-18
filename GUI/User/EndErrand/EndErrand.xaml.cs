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

        private UserService _userService;
        private IDataAccess<Mechanic> _mechanicdb;
        //private List<Errand> _activeErrandList;
        //private List<Errand> _endErrandList;
        private MechanicService _mechanicService;


        public EndErrand()
        {
            InitializeComponent();

            _userService = new UserService();
            _mechanicService = new MechanicService();
            _mechanicdb = new DataAccess<Mechanic>();
            //errandList = _userService.ListErrands();
            //_activeErrandList = _mechanicService.ListActiveErrands();
            //_endErrandList = _mechanicService.ListEndErrands();

            Errands.ItemsSource = _mechanicService.ListActiveErrands();
            EndErrands.ItemsSource = _mechanicService.ListEndErrands();
        }

        private void Errands_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void EndErrands_SelectionChanged(object sender, SelectionChangedEventArgs e)
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

            //_activeErrandList = _mechanicService.ListActiveErrands();
            //_endErrandList = _mechanicService.ListEndErrands();
            Errands.ItemsSource = _mechanicService.ListActiveErrands();
            EndErrands.ItemsSource = _mechanicService.ListEndErrands();
        }

    }
}
