using System;
using System.Collections.Generic;
using System.Text;
using Logic.Entities.Vehicles;

namespace Logic.Entities
{
    public class Errand
    {
        public string Description { get; set; }
        public string VehicleID{ get; set; }
        public string Issue { get; set; }
        public string MechanicID { get; set; }
        public bool Status { get; set; }

        public Errand()
        {

        }

        public Errand(string description, string vehicleid, string issue, string mechanicid, bool status)
        {
            Description = description;
            VehicleID = vehicleid;
            Issue = issue;
            MechanicID = mechanicid;
            Status = status;
        }
    }
}
