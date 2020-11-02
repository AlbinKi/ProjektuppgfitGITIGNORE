using Logic.DAL;
using Logic.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Services
{
    public class UserService21 //: IAdmin, IUser
    {
        private List<Mechanic> _mechanics;
        private DataAccess<Mechanic> _mechanicdb;
        private List<Errand> _errands;
        private DataAccess<Errand> _erranddb;
        private List<User> _users;
        private DataAccess<User> _userdb;

        public UserService21()
        {
            _mechanicdb = new DataAccess<Mechanic>();
            _erranddb = new DataAccess<Errand>();
            _userdb = new DataAccess<User>();
        }

       
        public void AddMechanic(string firstName, string lastName, DateTime dob)
        {

            Mechanic mechanic = new Mechanic(firstName, lastName, dob);

            _mechanicdb.Save(mechanic);

        }

        public void RemoveMechanic(Mechanic mechanic)
        {
            _mechanics = _mechanicdb.Load();

            foreach (var item in _mechanics)
            {
                if (item.MechanicID == mechanic.MechanicID)
                {
                    _mechanics.Remove(item);
                    _mechanicdb.Save(_mechanics);
                    
                    return;
                }
            }
        }

        /// <summary>
        /// Admin och användare kan lägga till kompetenser.
        /// </summary>
        /// <param name="mechanic"></param>
        /// <param name="skill"></param>
        public void AddSkill(Mechanic mechanic, String skill)
        {
            _mechanics = _mechanicdb.Load();

            foreach (var item in _mechanics)
            {
                if (item.MechanicID == mechanic.MechanicID)
                {
                    //Hur många skills?? Kontrollera för att ej lägga in för många! 5!
                    mechanic.Skills.Add(skill);
                    _mechanicdb.Save(mechanic);
                    return;
                }
            }
        }

        /// <summary>
        /// Admin lägger till en användare.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="admin"></param>
        public void AddUser(string username, string password, bool admin)
        {
            User user = new User(username, password, admin); //Metod för userid behövs i user-klassen.

            _userdb.Save(user);
        }

        /// <summary>
        /// Admin tar bort användare (och mekaniker kopplad till användare).
        /// </summary>
        /// <param name="user"></param>
        public void RemoveUser(User user)
        {
            _users = _userdb.Load();
            _mechanics = _mechanicdb.Load();

            foreach (var item in _users)
            {
                if (item.UserID == user.UserID)
                {
                    foreach (var mechanic in _mechanics)
                    {
                        if (mechanic.MechanicID == item.UserID)
                        {
                            _mechanics.Remove(mechanic);
                            _mechanicdb.Save(_mechanics);
                        }
                    }

                    _users.Remove(item);
                    _userdb.Save(_users);
                    return;
                }
            }
        }

    }
}
