using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using FluentValidation;
using Logic.Entities;

namespace GUI.Validators
{
    public class ErrandValidator : AbstractValidator<ErrandValidator>
    {

        public string Description { get; set; }
        public string Issue { get; set; }
        public string MechanicID { get; set; }
        public string RegistrationNumber { get; set; }
        public string VehicleType { get; set; }
        public string FuelType { get; set; }
        public string Model { get; set; }
        public string MaxLoad { get; set; }
        public string MaxSpeed { get; set; }
        public string MaxPassenger { get; set; }
        public string Odometer { get; set; }
        public string CarType { get; set; }
        private static readonly Regex _nospecialchars = new Regex(@"^[_A-z0-9]*((-|\s)*[_A-z0-9])*$");
        private static readonly Regex _regexonlynumbers = new Regex("[0-9]+");

        public ErrandValidator()
        {
            RuleFor(e => e.Description).Cascade(CascadeMode.Stop).Length(5, 100).WithMessage("Ärendebeskrivningen måste vara mellan 5-100 tecken");
            RuleFor(e => e.VehicleType).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Fordonstyp måste anges");
            RuleFor(e => e.Issue).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Fordonsproblem måste anges");
            RuleFor(e => e.RegistrationNumber).Cascade(CascadeMode.Stop).Length(2, 7).WithMessage("Registreringsnumret måste vara mellan 2-7 tecken").Matches(_nospecialchars).WithMessage("Registreringsnumret kan ej innehålla speicaltecken");
            RuleFor(e => e.MechanicID).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Mekaniker måste vara specifierad alt. 'Väntar på mekaniker'");
            RuleFor(e => e.Model).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Fordonets modell måste anges");
            RuleFor(e => e.FuelType).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Fordonets drivmedel måste anges");
            RuleFor(e => e.Odometer).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Fordonets milmätarantal måste anges").Matches(_regexonlynumbers).WithMessage("Ange milmätaren i siffror");
            RuleFor(e => e.MaxLoad).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Fordonets maxlast måste anges").Matches(_regexonlynumbers).WithMessage("Ange maxvikten i siffror");
            RuleFor(e => e.MaxSpeed).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Fordonets maxhastighet måste anges").Matches(_regexonlynumbers).WithMessage("Ange maxhastigheten i siffror");
            RuleFor(e => e.MaxPassenger).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Fordonets maxpassagerare måste anges").Matches(_regexonlynumbers).WithMessage("Ange max antal passagerare i siffror");
            RuleFor(e => e.CarType).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Ange bilens typ");
        }

    }
}
