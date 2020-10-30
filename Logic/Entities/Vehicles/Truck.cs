using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Entities.Vehicles
{
    public class Truck : Vehicle
    {
        public int MaxLoad { get; set; }
        public Truck(string model, string registrationnumber, int odometer, string fueltype, int maxload) : base(model, registrationnumber, odometer, fueltype)
        {
            MaxLoad = maxload;
        }

        public Truck()
        {

        }
    }
}
