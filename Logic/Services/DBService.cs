using Logic.DAL;
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
    }
}