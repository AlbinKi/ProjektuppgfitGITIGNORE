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
    }
}
