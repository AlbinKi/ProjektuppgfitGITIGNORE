using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Entities
{
    public class User : IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserID { get; set; }
    }
}
