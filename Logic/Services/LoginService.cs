using Logic.DAL;
using Logic.Entities;
using System;
using System.IO;

namespace Logic.Services
{
    public class LoginService
    {
        private DataAccess<UserDB> _userdb;
        private DataAccess<MechanicDB> _mechanicdb;
        private UserDB _users;
        private MechanicDB _mechanics;


        public LoginService()
        {
            _userdb = new DataAccess<UserDB>();
            _mechanicdb = new DataAccess<MechanicDB>();
            _users = new UserDB();
            _mechanics = new MechanicDB();

            var path = @"DAL\UserDB.json";
            if (!File.Exists(path))
            {
                var adminFile = File.Create(path);
                adminFile.Close();
                _users.DBList.Add(AddDefaultAdmin());
                _userdb.AddEntity(_users);

            }
            else if (new FileInfo(path).Length == 0)
            {
                _users.DBList.Add(AddDefaultAdmin());
                _userdb.AddEntity(_users);
            }

        }

        public bool Login(string username, string password)
        {
            _users = _userdb.GetEntities();

            return _users.DBList.Exists(user => user.Username.Equals(username) && user.Password.Equals(password));
        }

        private Admin AddDefaultAdmin()
        {
            var mechanic = new Mechanic("Bosse", "Andersson", new DateTime(1967, 05, 23));
            _mechanics.DBList.Add(mechanic);
            _mechanicdb.AddEntity(_mechanics);


            var admin = new Admin();
            admin.Username = "Bosse";
            admin.Password = "Meckarn123";
            admin.UserID = mechanic.MechanicID;

            return admin;
        }
    }
}
