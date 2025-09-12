using Application.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Validator
{
    public class CareLogDtoValidator : AbstractValidator<CareLogDto>
    {
        public CareLogDtoValidator()
        {
            
            RuleFor(c => c.plantId).GreaterThan(0).WithMessage("plantId must be greater than 0.");
            RuleFor(c => c.TaskType).NotEmpty().WithMessage("TaskType is required.");
            RuleFor(c => c.Note).MaximumLength(500).WithMessage("Note cannot exceed 500 characters.");
            RuleFor(c => c.Date).LessThanOrEqualTo(DateTime.Now).WithMessage("Date cannot be in the future.");
            

        }
    }


}
