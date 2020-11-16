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

        public User(string username, string password, bool admin, Guid userID)
        {
            Username = username;
            Password = password;

            Admin = admin;
            UserID = userID;
        }

        public User()
        {

        }

    }
}
