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


namespace GUI.User.Skills
{
    /// <summary>
    /// Interaction logic for UpdateSkills.xaml
    /// </summary>
    public partial class UpdateSkills : Page
    {

        private DBService _dbservice;
        private Mechanic _mechanic; //Kanske "mechanic == user"
        //Hämta en lista med skills och spara till variabel här?

        public UpdateSkills()
        {
            InitializeComponent();
            _dbservice = new DBService();
            //_mechanic = 
        }

        private void CurrentSkills_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserService21 list = new UserService21();
            //list.ListSkills();
        }
    }
}
