using Logic.DAL;
using Logic.Entities;
using System.Collections.Generic;
namespace Logic.Services
{
    public class ErrandService
    {
        private List<Mechanic> _mechanics;
        private DataAccess<Mechanic> _mechanicdb;

        public ErrandService()
        {
            _mechanicdb = new DataAccess<Mechanic>();
            _mechanics = new List<Mechanic>();
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
                var errandCount = mechanic.NumberOfErrands.Count;
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

    }
}
