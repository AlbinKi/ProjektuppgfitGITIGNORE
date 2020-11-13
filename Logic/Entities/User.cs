using Logic.DAL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Logic.Entities
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Guid UserID { get; set; }
        public bool Admin { get; set; }

        public User(string username, string password, bool admin)
        {
            Username = username;
            Password = password;
            UserID = Guid.NewGuid();

            MatchID(); //Skapa metod för att sätta userid till lämpligt mechanicid.
        }

        public void MatchID()
        {
            Mechanic mechanic = new Mechanic();
            List<Mechanic> mechanics = new List<Mechanic>();
            DataAccess<Mechanic> mechanicdb = new DataAccess<Mechanic>();

            UserID = Guid.NewGuid();

            mechanicdb.Load();

            foreach (var item in mechanics)
            {
                if (item.MechanicID == UserID)
                {
                    mechanicdb.Save(mechanic);
                }
            }
        }

        public User()
        {

        }

    }
}
