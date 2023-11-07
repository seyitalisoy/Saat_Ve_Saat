using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class AnnouncementValidator : AbstractValidator<Announcement>
    {
        public AnnouncementValidator()
        {
            RuleFor(a=>a.Title).NotEmpty();
            RuleFor(a=>a.Content).NotEmpty();
            RuleFor(a=>a.ImageUrl).NotEmpty();

        }
    }
}
