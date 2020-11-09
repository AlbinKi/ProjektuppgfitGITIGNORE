using System;
using System.Collections.Generic;
using System.Text;
using Logic.Entities.Vehicles;

namespace Logic.Entities
{
    public class Errand
    {
        public string Description { get; set; }

        public Guid ID { get; set; }
        public string VehicleID{ get; set; }
        public string Issue { get; set; }
        public Guid MechanicID { get; set; }
        public bool Status { get; set; }

        public Errand()
        {

        }

        public Errand(string description, string vehicleid, string issue, Guid mechanicid, bool status)
        {
            ID = new Guid();
            Description = description;
            VehicleID = vehicleid;
            Issue = issue;
            MechanicID = mechanicid;
            Status = status;
        }
    }
}
