using Logic.DAL;
using Logic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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


        /// <summary>
        /// Admin och användare kan lägga till kompetenser.
        /// </summary>
        /// <param name="mechanic"></param>
        /// <param name="skill"></param>
        public void AddSkill(Mechanic mechanic, string skill)
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
        /// En användare kan ändra status på ett pågående ärende till "klart".
        /// </summary>
        /// <param name="e"></param>
        public void EndActiveErrand(Errand e)
        {
            _mechanics = _mechanicdb.Load();
            _mechanic = _mechanics.FirstOrDefault(mechanic => mechanic.MechanicID == CurrentUser.user.UserID);

            e.Status = false;
            _mechanic.NumberOfErrands--;

            DBService.Modify(e);
            DBService.Modify(_mechanic);
        }

        public int DaysUntilBirthday(Mechanic mechanic)
        {
                      
            DateTime today = DateTime.Today;
            DateTime next = mechanic.DateOfBirth.AddYears(today.Year - mechanic.DateOfBirth.Year);

            if (next < today)
                next = next.AddYears(1);

            int numDays = (next - today).Days;

            return numDays - 1; //Dunno why men verkar vara något konstigt med antingen DateTime.today eller något annat då det läggs på en extra dag på numdays
        }

        public Mechanic NextBirthday()
        {
            var mechanics = _mechanicdb.Load();
            mechanics = mechanics.OrderBy(m => DaysUntilBirthday(m)).ToList();
            return mechanics[0];
        }

        /// <summary>
        /// Admin lägger till en användare.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="admin"></param>
        public void AddUser(string username, string password, bool admin, Guid userID)
        {
            User user = new User(username, password, admin, userID);

            _userdb.Save(user);
        }

        /// <summary>
        /// Testar om angiven sträng är en giltig epostadress.
        /// </summary>
        /// <param name="email"></param>
        /// <returns>Kolla om match==success för att använda</returns>
        public Match TryUsername(string email)
        {
            Regex tryEmail = new Regex(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");

            var match = tryEmail.Match(email);

            return match;
        }

        /// <summary>
        /// Testar om angiven sträng är ett giltigt lösenord.
        /// </summary>
        /// <param name="password"></param>
        /// <returns>Kolla om match==success för att använda</returns>
        public Match TryPassword(string password)
        {
            //Minimum eight characters, at least one letter and one number.
            Regex tryPass = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");

            var match = tryPass.Match(password);

            return match;
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
                            break;
                        }
                    }

                    _users.Remove(item);
                    _userdb.Save(_users);
                    return;
                }
            }

        
        }

        public Mechanic GetMechanic(Guid ID)
        {
            _mechanics = _mechanicdb.Load();
            var mechanic = _mechanics.FirstOrDefault(m => m.MechanicID == ID);
            return mechanic;
        }
    }
}

