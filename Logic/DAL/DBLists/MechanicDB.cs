using Logic.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.DAL
{
    public class MechanicDB
    {
        public List<Mechanic> DBList { get; set; }
        public MechanicDB()
        {
            DBList = new List<Mechanic>();
        }
    }
}

