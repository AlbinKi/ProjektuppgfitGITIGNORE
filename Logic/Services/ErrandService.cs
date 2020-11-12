using Logic.DAL;
using Logic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Services
{
    public class ErrandService
    {
   
        private DataAccess<Mechanic> _mechanicdb;
        private DataAccess<Errand> _erranddb;

        public ErrandService()
        {
            _mechanicdb = new DataAccess<Mechanic>();          
            _erranddb = new DataAccess<Errand>();
        }

        /// <summary>
        /// Metod för att se vilka mekaniker som är tillgängliga för ett ärende
        /// </summary>
        /// <param name="issue"></param>
        /// <returns></returns>
        public List<Mechanic> AvailableMechanics(string issue)
        {
            var mechanicsAvailable = _mechanicdb.Load();          
            return mechanicsAvailable.Where(m => m.Skills.FirstOrDefault(s => s == issue) == issue && m.NumberOfErrands < 2 && m.NumberOfErrands >= 0).ToList();
        }

        /// <summary>
        /// Returnerar en lista av ärenden som ej har en mekaniker tilldelade till sig
        /// </summary>
        /// <returns></returns>
        public List<Errand> UnassignedErrands()
        {
            var errands = _erranddb.Load();
            return errands.Where(errand => errand.MechanicID == Guid.Empty).OrderBy(o => o.Issue).ToList();
        }

        /// <summary>
        /// Returnerar alla pågående ärenden som har en mekaniker tilldelad
        /// </summary>
        /// <returns></returns>
        public List<Errand> OnGoingErrands()
        {
            var errands = _erranddb.Load();
            return errands.Where(errand => errand.Status == true && errand.MechanicID != Guid.Empty).OrderBy(o => o.Issue).ToList();
        }
    }
}