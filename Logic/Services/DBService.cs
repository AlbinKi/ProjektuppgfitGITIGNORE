using Logic.DAL;
using Logic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic.Services
{
    public class DBService
    {
        public void Save<T>(T entity)
        {
            var db = new DataAccess<T>();
            db.Save(entity);
        }

    
        public void ModifyMechanic(Mechanic mechanic)
        {
            var db = new DataAccess<Mechanic>();
            var entities = db.Load();
            entities.RemoveAll(e => e.MechanicID == mechanic.MechanicID);
            entities.Add(mechanic);
            db.Save(entities);
        }
    }
}
