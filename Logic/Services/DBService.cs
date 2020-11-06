using Logic.DAL;
using Logic.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Services
{
    public class DBService
    {
        public void SaveEntity<T>(T entity)
        {
            var db = new DataAccess<T>();
            db.Save(entity);
        }

        public void Modify(Mechanic m)
        {
            var db = new DataAccess<Mechanic>();
            var mechanics = db.Load();
            mechanics[mechanics.FindIndex(ind => ind.MechanicID == m.MechanicID)] = m;
            mechanics.Add(m);
            db.Save(mechanics);
        }

    }
}