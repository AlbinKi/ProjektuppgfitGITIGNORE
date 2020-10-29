using Logic.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Services
{
    class AdamService
    {
        public static void AddUser(UserDB user)
        {
            DataAccess<UserDB> dataAccess = new DataAccess<UserDB>();

            dataAccess.AddEntity(user);
            
        }

        //public static void RemoveUser(UserDB user)
        //{
        //    users = new DataAccess<user>
        //}

    }
}
