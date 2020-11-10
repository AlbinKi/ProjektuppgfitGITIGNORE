using FluentValidation;
using Logic.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GUI.Validators
{
    class EndErrandValidator : AbstractValidator<EndErrandValidator>
    {
        public Errand Errand { get; set; }

        public EndErrandValidator()
        {
            RuleFor(e => e.Errand).NotEmpty().WithMessage("Välj ett ärende att avsluta");
        }
    }
}
