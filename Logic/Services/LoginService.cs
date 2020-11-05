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
            CurrentUser.ID = _users.FirstOrDefault(user => user.Username.Equals(username) && user.Password.Equals(password)).UserID;          
        }
        private Admin AddDefaultAdmin()
        {         
            var mechanic = new Mechanic("Bosse", "Andersson", new DateTime(1967, 05, 23));
            mechanic.Skills[0] = "Motor";
            mechanic.Skills[1] = "Hjul";
            mechanic.Skills[2] = "Bromsar";
            mechanic.Skills[3] = "Vindruta";
            mechanic.Skills[4] = "Kaross";
            _mechanicdb.Save(mechanic);

            var admin = new Admin();
            admin.Username = "Bosse";
            admin.Password = "Meckarn123";
            admin.UserID = mechanic.MechanicID;
            admin.Admin = true;

            return admin;
        }
    }
}
