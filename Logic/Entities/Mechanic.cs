using System;
using System.Collections.Generic;
using System.Text;
using Logic.Services;

namespace Logic.Entities
{
    public class Mechanic
    {
        //public string MechanicID { get; set; }

        public Guid MechanicID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int NumberOfErrands { get; set; } //Array???
        public DateTime DateOfBirth { get; set; }
        public List<string> Skills { get; set; }
        



        //public List<Errands> CurrentErrands { get; set; }
        public Mechanic(string firstname, string lastname, DateTime dateofbirth)
        {
            FirstName = firstname;
            LastName = lastname;
            DateOfBirth = dateofbirth;
            Skills = new List<string>(); //Kaross, Vindruta, Motor, Hjul & Bromsar
            NumberOfErrands = 0;
            MechanicID = Guid.NewGuid();
            CalculateAge();
            //SetMechanicID();
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
