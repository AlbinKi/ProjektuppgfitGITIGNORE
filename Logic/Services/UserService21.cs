using Logic.DAL;
using Logic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private Mechanic _mechanic;

        public UserService21()
        {
            _mechanicdb = new DataAccess<Mechanic>();
            _erranddb = new DataAccess<Errand>();
            _userdb = new DataAccess<User>();
        }

       
        public Mechanic AddMechanic(string firstName, string lastName, DateTime dob)
        {

            Mechanic mechanic = new Mechanic(firstName, lastName, dob);

            _mechanicdb.Save(mechanic);

            return mechanic;

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
                    foreach (var mechSkill in item.Skills)
                    {
                        if (item.Skills.Contains(skill))
                        {
                            return;
                        }
                    }
                    //Totalt 5 skills!
                    mechanic.Skills.Add(skill);
                    _mechanicdb.Save(mechanic);
                    return;
                }
            }
        }

        /// <summary>
        /// Returnerar en lista med den inloggade mekanikerns nuvarande kompetenser.
        /// </summary>
        /// <returns></returns>
        public List<string> ListSkills()
        {
            //Kan inte längre ladda en lista, blir null!
            _mechanics = _mechanicdb.Load();

            _mechanic = _mechanics.FirstOrDefault(mechanic => mechanic.MechanicID == CurrentUser.user.UserID);
            
            return _mechanic.Skills;
        }

        /// <summary>
        /// Returnerar en lista med den inloggade mekanikerns pågående ärenden.
        /// </summary>
        /// <returns></returns>
        public List<Errand> ListErrands()
        {
            _errands = _erranddb.Load();

            return _errands.Where(e => (e.MechanicID == CurrentUser.user.UserID) && (e.Status == true)).ToList();

        }

        public void ShowInfo(Mechanic m)
        {

        }

        public void EndActiveErrand(Errand e)
        {
            _mechanics = _mechanicdb.Load();
            _mechanic = _mechanics.FirstOrDefault(mechanic => mechanic.MechanicID == CurrentUser.user.UserID);

            e.Status = false;
            _mechanic.NumberOfErrands--;

            DBService.Modify(e);
            DBService.Modify(_mechanic);
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

        public List<Mechanic> MechanicHasUser()
        {
            List<Mechanic> mechanicsNoUser = new List<Mechanic>();

            _mechanics = _mechanicdb.Load();
            _users = _userdb.Load();

            foreach (var m in _mechanics)
            {
                var mID = m.MechanicID;
                foreach (var u in _users)
                {
                    if (u.UserID == m.MechanicID)
                    {
                        _mechanics.Remove(m);
                    }
                }
            }

            return _mechanics;
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
