using Logic.DAL;
using Logic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Services
{
    public class ErrandService
    {
        private List<Mechanic> _mechanics;
        private DataAccess<Mechanic> _mechanicdb;
        private DataAccess<Errand> _erranddb;

        public ErrandService()
        {
            _mechanicdb = new DataAccess<Mechanic>();
            _mechanics = new List<Mechanic>();
            _erranddb = new DataAccess<Errand>();
        }

        /// <summary>
        /// Metod för att se vilka mekaniker som är tillgängliga för ett ärende
        /// </summary>
        /// <param name="issue"></param>
        /// <returns></returns>
        public List<Mechanic> AvailableMechanics(string issue)
        {
            _mechanics = _mechanicdb.Load();


            var mechanicsAvailable = new List<Mechanic>();

            foreach (var mechanic in _mechanics)
            {
                var errandCount = mechanic.NumberOfErrands;
                foreach (var skill in mechanic.Skills)
                {
                    if (issue == skill)
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

        /// <summary>
        /// Returnerar en lista av ärenden som ej har en mekaniker tilldelade till sig
        /// </summary>
        /// <returns></returns>
        public List<Errand> UnassignedErrands()
        {
            var errands = _erranddb.Load();
            return errands.Where(errand => errand.MechanicID == Guid.Empty).ToList();
        }
    }
}