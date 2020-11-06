using FluentValidation;
using Logic.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace GUI.Validators
{
    public class MechanicToErrandValidator :AbstractValidator<MechanicToErrandValidator>
    {
        public Mechanic MechanicList { get; set; }
        public Errand ErrandList { get; set; }

        public MechanicToErrandValidator()
        {
            RuleFor(m => m.MechanicList).NotEmpty().WithMessage("Välj en mekaniker");
            RuleFor(m => m.ErrandList).NotEmpty().WithMessage("Välj ett ärrende");
        }
    }

}
