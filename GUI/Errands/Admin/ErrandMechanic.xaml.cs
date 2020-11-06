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
            
        }

        private void ErrandList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var errand = ErrandList.SelectedItem as Errand;
            var value = errand.Issue;

            MechanicList.ItemsSource = _errandserivce.AvailableMechanics(value);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

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

        }
    }
}
