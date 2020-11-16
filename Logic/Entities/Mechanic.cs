using System;
using System.Collections.Generic;
using System.Text;
using Logic.Services;
using Logic.DAL;

namespace Logic.Entities
{
    public class Mechanic
    {
        public Guid MechanicID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int NumberOfErrands { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<string> Skills { get; set; }

        public DateTime EndDate { get; set; }


        public Mechanic(string firstname, string lastname, DateTime dateofbirth)
        {
            FirstName = firstname;
            LastName = lastname;
            DateOfBirth = dateofbirth;
            Skills = new List<string>();
            NumberOfErrands = 0;
            
            MechanicID = Guid.NewGuid();

            CalculateAge();
        }

        public Mechanic()
        {

        }
        
        /// <summary>
        /// Räknar ut åldern baserat på mekanikerns födelsedag
        /// </summary>
        private void CalculateAge()
        {
            var today = DateTime.Today;

            Age = today.Year - DateOfBirth.Year;

            if (DateTime.Now.DayOfYear < DateOfBirth.DayOfYear)
            {
                Age = Age - 1;
            }
        }

    }
}
