using System;
using System.Collections.Generic;
using System.Text;
using Logic.Entities.Vehicles;

namespace Logic.Entities
{
    public class Errand
    {
        public string Description { get; set; }
<<<<<<< HEAD
        public Vehicle Vehicle { get; set; }
=======
        public Vehicle Vehicle{ get; set; }
>>>>>>> parent of dd3800b... Merge pull request #1 from AlbinKi/Albin-V1
        public string Issue { get; set; }
        public Mechanic Mechanic { get; set; }
        public bool Status { get; set; }
    }
}
