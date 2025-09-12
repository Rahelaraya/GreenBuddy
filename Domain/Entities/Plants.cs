using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Plants
    {
        public int Id { get; set; }
        public string PlantName { get; set; } = string.Empty;
        public string Species { get; set; } = string.Empty;
        public int WaterFrequencyInDays { get; set; }
        public DateTime CreatedAt { get; set; }
        public string SunlightRequirement { get; set; } = string.Empty;
        public int FrequencyOfChangeSoil { get; set; }
        public int FrequencyOfGivingNutrition { get; set; }

    }
}
