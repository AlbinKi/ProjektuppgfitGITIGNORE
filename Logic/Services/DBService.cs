using Logic.DAL;
using Logic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic.Services
{
    
    public static class DBService
    {
        public static void Save<T>(T entity)
        {
            var db = new DataAccess<T>();
            db.Save(entity);
        }


        public static void  Modify(Mechanic m)
        {
            var db = new DataAccess<Mechanic>();
            var mechanics = db.Load();
            mechanics[mechanics.FindIndex(ind => ind.MechanicID == m.MechanicID)] = m;
            mechanics.Add(m);
            db.Save(mechanics);
        }

        public static void Modify(Errand e)
        {
            var db = new DataAccess<Errand>();
            var mechanics = db.Load();
            mechanics[mechanics.FindIndex(ind => ind.ID == e.ID)] = e;
            mechanics.Add(e);
            db.Save(mechanics);
        }   
        public static void Modify(User u)
        {
            var db = new DataAccess<User>();
            var mechanics = db.Load();
            mechanics[mechanics.FindIndex(ind => ind.UserID == u.UserID)] = u;
            mechanics.Add(u);
            db.Save(mechanics);
        }
    }
}
