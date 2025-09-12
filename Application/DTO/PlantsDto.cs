using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class PlantsDto
    {
        public int Id { get; set; }
        public string PlantName { get; set; }
        public string Species { get; set; }
        public DateTime PlantedAt { get; set; }
        public int WaterFrequencyInDays { get; set; }
        public string SunlightRequirement { get; set; }
        public int FrequencyOfChangeSoil { get; set; }
        public int FrequencyOfGivingNutrition { get; set; }


    }
}
