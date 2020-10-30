using Logic.DAL;
using Logic.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Services
{
    public class UserService21
    {
        private MechanicDB _mechanics;
        private DataAccess<MechanicDB> _mechanicdb;
        private ErrandDB _errands;
        private DataAccess<ErrandDB> _erranddb;

        public UserService21()
        {
            _mechanicdb = new DataAccess<MechanicDB>();
            _erranddb = new DataAccess<ErrandDB>();
        }

        private List<Mechanic> AvailableMechanics(Errand errand)
        {
            _errands = _erranddb.GetEntities();
            _errands.ListDB.Add(errand);
            _mechanics = _mechanicdb.GetEntities();

            var mechanicsAvailable = new List<Mechanic>();

            foreach (var mechanic in _mechanics.DBList)
            {
                var errandCount = mechanic.NumberOfErrands.Count;
                foreach (var skill in mechanic.Skills)
                {
                    if (errand.Issue == skill)
                    {
                        if (errandCount < 2 && errandCount >= 0)
                        {
                            mechanicsAvailable.Add(mechanic);
                        }
                    }
                } 
            }

            return mechanicsAvailable;
        }
    }
}
