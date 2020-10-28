using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;

namespace Logic.Entities.Vehicles
{
    public class Car : Vehicle
    {
        public bool HasTowbar { get; set; }
        public Car(string model, string registrationnumber, int odometer, string fueltype, bool hastowbar)
        {
            Model = model;
            RegistrationNumber = registrationnumber;
            Odometer = odometer;
            FuelType = fueltype;
            HasTowbar=hastowbar;
        }
    }
}
