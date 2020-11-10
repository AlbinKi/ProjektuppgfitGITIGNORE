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
        public ErrandStatus()
        {
            InitializeComponent();
            _errandservice = new ErrandService();
            Errands.ItemsSource = _errandservice.OnGoingErrands();

            if (Errands.Items.Count == 0)
            {
                MessageBox.Show("Det finns inga pågående ärenden just nu");
                var ep = new ErrandPageAdmin();
                NavigationService.Navigate(ep);
            }
        }

        private void EndErrand_Click(object sender, RoutedEventArgs e)
        {

            var errand = Errands.SelectedItem as Errand;
            errand.Status = false;
            DBService.Modify(errand);
            Errands.ItemsSource = _errandservice.OnGoingErrands();

        }
    }
}
