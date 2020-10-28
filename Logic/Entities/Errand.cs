using System;
using System.Collections.Generic;
using System.Text;
using Logic.Entities.Vehicles;

namespace Logic.Entities
{
    public class Errand
    {
        public string Description { get; set; }
        public Vehicle Vehicle{ get; set; }
        public string Issue { get; set; }
        public Mechanic Mechanic { get; set; }
        public bool Status { get; set; }
    }
}
