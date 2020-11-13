using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Logic.Entities
{
    public class Admin : User2
    {

        public Admin(string username, string password, bool admin)
        {
            Username = username;
            Password = password;
            Admin = admin;
        }

        //Tom konstruktor för att kunna skapa upp en admin i loginservice, kanske istället ändra metoden i loginservice...
        public Admin()
        {
                
        }

    }
}
