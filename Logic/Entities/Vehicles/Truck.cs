using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Entities.Vehicles
{
    public class Truck : Vehicle
    {
        public int MaxLoad { get; set; }
        public Truck(string model, string registrationnumber, int odometer, string fueltype, int maxload)
        {
            Model = model;
            RegistrationNumber = registrationnumber;
            Odometer = odometer;
            FuelType = fueltype;
            MaxLoad = maxload;
        }
        public Truck()
        {

        }
    }
}
