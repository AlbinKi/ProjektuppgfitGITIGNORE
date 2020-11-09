using GUI.Validators;
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
using Xceed.Wpf.Toolkit;
using MessageBox = System.Windows.MessageBox;

namespace GUI.Errands.Admin
{
    /// <summary>
    /// Interaction logic for ErrandMechanic.xaml
    /// </summary>
    public partial class ErrandMechanic : Page
    {
        private ErrandService _errandserivce;
        public ErrandMechanic()
        {
            _errandserivce = new ErrandService();          
            InitializeComponent();
            ErrandList.ItemsSource = _errandserivce.UnassignedErrands();
            if (ErrandList.Items.Count == 0)
            {
                AddMechanic.IsEnabled = false;
                ErrandList.IsEnabled = false;
                MechanicList.IsEnabled = false;
                var noErrand = new string[] { "Det finns inga ärenden utan mekaniker" };
                ErrandList.ItemsSource = noErrand;
            }


        }

        private void ErrandList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AddMechanic.IsEnabled = true;
            var errand = ErrandList.SelectedItem as Errand;
            var value = errand.Issue;

            MechanicList.ItemsSource = _errandserivce.AvailableMechanics(value);
            if (MechanicList.Items.Count == 0)
            {
                AddMechanic.IsEnabled = false;
                var noMechanic = new string[] { "Det finns inga mekaniker lediga för ärendet ännu" };
                MechanicList.ItemsSource = noMechanic;
            }
        }


        private void AddMechanic_Click(object sender, RoutedEventArgs e)
        {
            MechanicToErrandValidator mv = new MechanicToErrandValidator()
            {              
                MechanicList = MechanicList.SelectedItem as Mechanic,
                ErrandList = ErrandList.SelectedItem as Errand
            };

            var results = mv.Validate(mv);
            if (!results.IsValid)
            {
                var sb = new StringBuilder();
                foreach (var failure in results.Errors)
                {
                    sb.Append($"{failure.ErrorMessage}\n");
                }
                MessageBox.Show(sb.ToString());
                return;
            }
            var errand = ErrandList.SelectedItem as Errand;
            var mechanic = MechanicList.SelectedItem as Mechanic;

            mechanic.NumberOfErrands += 1;

            errand.MechanicID = mechanic.MechanicID;

            DBService.Modify(mechanic);
            DBService.Modify(errand);


        }
    }
}
