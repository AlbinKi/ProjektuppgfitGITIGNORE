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

namespace GUI.User.Skills
{
    /// <summary>
    /// Interaction logic for UpdateSkills.xaml
    /// </summary>
    public partial class UpdateSkills : Page
    {

        private DBService _dbservice;
        private Mechanic _mechanic;
        private UserService21 _userService;
        //private DataAccess<Mechanic> _dataAccess;
        private List<Mechanic> _mechanics;
        private DataAccess<Mechanic> _mechanicdb;


        public UpdateSkills()
        {
            InitializeComponent();
            _dbservice = new DBService();
            _mechanicdb = new DataAccess<Mechanic>();
            _userService = new UserService21();

            List<string> SkillList = _userService.ListSkills();
            CurrentSkills.ItemsSource = SkillList;

        }

        //Visar den inloggade mekanikerns nuvarande kompetenser.
        private void CurrentSkills_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        //Lägger till en kompetens i den inloggade mekanikerns skill-lista.
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            _mechanics = _mechanicdb.Load();

            _mechanic = _mechanics.FirstOrDefault(mechanic => mechanic.MechanicID == CurrentUser.ID.UserID);

            List<string> SkillList = _userService.ListSkills();

            var skill = SkillBox.Text;

            if(SkillList.Any(x => x == skill))
            {
                MessageBox.Show("Du har angett en kompetens som du redan har.");
            }
            else
            {
                SkillList.Add(skill);

                _mechanic.Skills.Add(skill);

                _dbservice.Modify(_mechanic);

                CurrentSkills.ItemsSource = SkillList;
            }

        }

        //Tar bort en kompetens i den inloggade mekanikerns skill-lista.
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            _mechanics = _mechanicdb.Load();

            _mechanic = _mechanics.FirstOrDefault(mechanic => mechanic.MechanicID == CurrentUser.ID.UserID);

            List<string> SkillList = _userService.ListSkills();

            var skill = SkillBox.Text;

            if (SkillList.Any(x => x == skill))
            {
                SkillList.Remove(skill);

                _mechanic.Skills.Remove(skill);

                _dbservice.Modify(_mechanic);

                CurrentSkills.ItemsSource = SkillList;

            }
            else
            {
                MessageBox.Show("Du försöker ta bort en kompetens som du inte har.");
            }
        }

        //Visar alla tillgängliga kompetenser.
        private void SkillBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        
    }
}
