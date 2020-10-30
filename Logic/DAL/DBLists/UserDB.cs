using Logic.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.DAL
{
    public class UserDB
    {
        public List<User> DBList { get; set; }

         public UserDB()
        {
            DBList = new List<User>();
        }
    }
}
