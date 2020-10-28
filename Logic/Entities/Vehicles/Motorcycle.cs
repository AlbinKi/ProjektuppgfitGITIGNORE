using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Entities.Vehicles
{
    public class Motorcycle : Vehicle
    {
        public int MaxSpeed { get; set; }
        public Motorcycle(string model, string registrationnumber, int odometer, string fueltype, int maxspeed) : base(model, registrationnumber, odometer, fueltype)
        {
            MaxSpeed = maxspeed;
        }
    }
}
