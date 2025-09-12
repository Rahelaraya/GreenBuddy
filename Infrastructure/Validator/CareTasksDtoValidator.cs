using Application.DTO;
using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Validator
{
    public class CareTasksDtoValidator : AbstractValidator<CareTasksDto>
    {
        public CareTasksDtoValidator() 
        {
            RuleFor(c => c.PlantId).GreaterThan(0).WithMessage("plantId must be greater than 0.");
            RuleFor(c => c.Type).NotEmpty().WithMessage("Type is required.");
            RuleFor(c => c.LastDoneAt).LessThanOrEqualTo(DateTime.Now).WithMessage("LastDoneAt cannot be in the future.");
            RuleFor(c => c.NextDueAt).GreaterThan(c => c.LastDoneAt).WithMessage("NextDueAt must be after LastDoneAt.");
                



        }
    }
}
