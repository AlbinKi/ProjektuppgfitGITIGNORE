using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Entities.Vehicles
{
   public class Vehicle
    {
        public string Model { get; set; }
        public string RegistrationNumber { get; set; }
        public int Odometer { get; set; }
        public string FuelType { get; set; }

        public Vehicle(string model, string registrationnumber, int odometer, string fueltype)
        {
            Model = model;
            RegistrationNumber = registrationnumber;
            Odometer = odometer;
            FuelType = fueltype;
        }
    }
}
