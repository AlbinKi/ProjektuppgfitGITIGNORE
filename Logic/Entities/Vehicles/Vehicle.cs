﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Entities.Vehicles
{
   public abstract class Vehicle
    {
        public string Model { get; set; }
        public string RegistrationNumber { get; set; }
        public int Odometer { get; set; }
        public string FuelType { get; set; }

    }
}
