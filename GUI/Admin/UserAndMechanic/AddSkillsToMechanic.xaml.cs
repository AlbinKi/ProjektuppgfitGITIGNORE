using Logic.DAL;
using Logic.Entities;
using Logic.Services;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace GUI.Admin.UserAndMechanic
{
    /// <summary>
    /// Interaction logic for AddSkillToMechanicxaml.xaml
    /// </summary>
    public partial class AddSkillsToMechanic : Page
    {
        private DataAccess<Mechanic> _mechanicdb;
        private List<string> _allskills;
        public AddSkillsToMechanic()
        {
            InitializeComponent();
            _mechanicdb = new DataAccess<Mechanic>();
            Mechanics.ItemsSource = _mechanicdb.Load();
            _allskills = new List<string>()
            {
                "Motor",
                "Kaross",
                "Bromsar",
                "Hjul",
                "Vindrutor"
            };
        }

        private void Mechanics_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var mechanic = Mechanics.SelectedItem as Mechanic;
            Skills.ItemsSource = _allskills.Except(mechanic.Skills).ToList();
            CurrentSkills.ItemsSource = mechanic.Skills;
        }

        private void AddSkill_Click(object sender, RoutedEventArgs e)
        {
            if (Mechanics.SelectedItem == null)
            {
                return;
            }
            var mechanic = Mechanics.SelectedItem as Mechanic;

            var addedskills = new List<string>();
            foreach (var item in Skills.SelectedItems)
            {
                addedskills.Add(item as string);
            }

            mechanic.Skills.AddRange(addedskills);
            UpdateLists(mechanic);

        }

        private void RemoveSkill_Click(object sender, RoutedEventArgs e)
        {
            if (Mechanics.SelectedItem == null)
            {
                return;
            }
            var mechanic = Mechanics.SelectedItem as Mechanic;
        
            foreach (var skill in CurrentSkills.SelectedItems)
            {
                mechanic.Skills.Remove(skill as string);
            }
            UpdateLists(mechanic);
        }

        private void UpdateLists(Mechanic mechanic)
        {
            DBService.Modify(mechanic);
            Skills.ItemsSource = null;
            Skills.ItemsSource = _allskills.Except(mechanic.Skills).ToList();
            CurrentSkills.ItemsSource = null;
            CurrentSkills.ItemsSource = mechanic.Skills;
        }
    }
}
