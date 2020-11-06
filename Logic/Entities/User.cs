using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Entities
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Guid userID { get; set; }
        //public string UserID { get; set; }
        public bool Admin { get; set; }

        public User(string username, string password, bool admin)
        {
            //Skapa metod för att sätta userid till lämpligt mechanicid.
            Username = username;
        }

        public User()
        {

        }

    }
}
