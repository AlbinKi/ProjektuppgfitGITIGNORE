using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Entities.Vehicles
{
    public class Bus : Vehicle
    {
        public int MaxPassengers { get; set; }
        public Bus(string model, string registrationnumber, int odometer, string fueltype) : base(model, registrationnumber, odometer, fueltype)
        {

        }

    }
}
