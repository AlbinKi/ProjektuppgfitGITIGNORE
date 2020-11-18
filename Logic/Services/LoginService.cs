using Logic.DAL;
using Logic.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Logic.Services
{
    public class LoginService
    {
        private DataAccess<User> _userdb;
        private DataAccess<Mechanic> _mechanicdb;
        private List<User> _users;
        private List<Mechanic> _mechanics; 
        private const string _path = @"DAL\User.json";
        private const string _folderpath = @"DAL";


        public LoginService()
        {
            _userdb = new DataAccess<User>();
            _mechanicdb = new DataAccess<Mechanic>();
            _mechanics = new List<Mechanic>();
            _users = new List<User>();


            if (!Directory.Exists(_folderpath))
            {
                Directory.CreateDirectory(_folderpath);
                var fs = File.Create(_path);
                fs.Close();
                
                _userdb.Save(AddDefaultAdmin());
            }
            if (!File.Exists(_path))
            {
                var fs = File.Create(_path);
                fs.Close();
                _userdb.Save(AddDefaultAdmin());

            }
            else if (new FileInfo(_path).Length == 0)
            {
                _userdb.Save(AddDefaultAdmin());
            }

        }

        public bool Login(string username, string password)
        {
            _users = _userdb.Load();
            return _users.Exists(user => user.Username.Equals(username) && user.Password.Equals(password));           
        }

        public void GetCurrentUser(string username, string password)
        {
            CurrentUser.user = _users.FirstOrDefault(user => user.Username.Equals(username) && user.Password.Equals(password));         
        }

        private User AddDefaultAdmin()
        {         
            var mechanic = new Mechanic("Bosse", "Andersson", new DateTime(1967, 05, 23));
            mechanic.Skills.Add("Motor");

            mechanic.Skills.Add("Hjul");
            mechanic.Skills.Add("Bromsar");
            mechanic.Skills.Add("Vindrutor");
            mechanic.Skills.Add("Kaross");

            _mechanicdb.Save(mechanic);

            var user = new User();
            user.Username = "Bosse";
            user.Password = "Meckarn123";
            user.UserID = mechanic.MechanicID;
            user.Admin = true;

            return user;
        }
    }
}
