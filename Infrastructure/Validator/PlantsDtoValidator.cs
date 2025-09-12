using Application.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Validator
{
    public class PlantsDtoValidator : AbstractValidator<PlantsDto>
    {
        public PlantsDtoValidator()
        {
            RuleFor(p => p.PlantName).NotEmpty().WithMessage("PlantName is required.");
            RuleFor(p => p.Species).NotEmpty().WithMessage("Species is required.");
            RuleFor(p => p.WaterFrequencyInDays).GreaterThan(0).WithMessage("WaterFrequencyInDays must be greater than 0.");
            RuleFor(p => p.SunlightRequirement).NotEmpty().WithMessage("SunlightRequirement is required.");
            RuleFor(p => p.FrequencyOfChangeSoil).GreaterThanOrEqualTo(0).WithMessage("FrequencyOfChangeSoil must be 0 or greater.");
            RuleFor(p => p.FrequencyOfGivingNutrition).GreaterThanOrEqualTo(0).WithMessage("FrequencyOfGivingNutrition must be 0 or greater.");
                
        }
    }
}
