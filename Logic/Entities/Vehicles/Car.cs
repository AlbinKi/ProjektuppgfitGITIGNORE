using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;

namespace Logic.Entities.Vehicles
{
    public class Car : Vehicle
    {
        public bool HasTowbar { get; set; }

        public Car()
        {

        }
        public Car(string model, string registrationnumber, int odometer, string fueltype, bool hastowbar):base(model, registrationnumber, odometer, fueltype)
        {
            HasTowbar = hastowbar;
        }
    }
}
