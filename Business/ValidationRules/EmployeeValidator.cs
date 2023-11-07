using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(e=>e.FirstName).NotEmpty();
            RuleFor(e=>e.LastName).NotEmpty();
            RuleFor(e=>e.LastName).NotEmpty();
            RuleFor(e=>e.TcNo).Length(11).WithMessage("Tc No 11 karakterli olmalı");
            RuleFor(e => e.PhoneNumber).Length(10).WithMessage("Telefon Numarası 10 karakterli olmalı");
            RuleFor(e => e.PhoneNumber).Must(NotStartZero).WithMessage("Numara 0 ile başlayamaz");
        }

        private bool NotStartZero(string arg)
        {
            return !arg.StartsWith("0");
        }
    }
}
