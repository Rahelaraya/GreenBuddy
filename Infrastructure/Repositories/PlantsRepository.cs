using Application.DTO;
using Application.Interface;
using Domain.Entities;
using Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PlantsRepository : IPlantsRepository 
    {
        private readonly AppDbContext _context;

        

        public PlantsRepository(AppDbContext context)
        {
            _context = context;

        }

        public async Task<IEnumerable<PlantsDto>> GetAllAsync()
        {
            var plants = await _context.Plants.ToListAsync();
            var plantsDto = plants.Select(p => new PlantsDto
            {
                Id = p.Id,
                PlantName = p.PlantName,
                Species = p.Species,
                WaterFrequencyInDays = p.WaterFrequencyInDays,
                SunlightRequirement = p.SunlightRequirement,
                FrequencyOfChangeSoil = p.FrequencyOfChangeSoil,
                FrequencyOfGivingNutrition = p.FrequencyOfGivingNutrition
            });
            return await Task.FromResult(plantsDto);
        }
     
        public async  Task<PlantsDto> GetByIdAsync(int id)
        {
            var plant = _context.Plants.Find(id);
            if (plant == null) return (null)!;
            

           result: return new PlantsDto
            {
                
                Id = plant.Id,
                PlantName = plant.PlantName,
                Species = plant.Species,
                WaterFrequencyInDays = plant.WaterFrequencyInDays,
                SunlightRequirement = plant.SunlightRequirement,
                FrequencyOfChangeSoil = plant.FrequencyOfChangeSoil,
                FrequencyOfGivingNutrition = plant.FrequencyOfGivingNutrition
            };
        }


        public async Task UpdateAsync(PlantsDto plantDto)
        {
            if (plantDto is null) throw new ArgumentNullException(nameof(plantDto));

            var plant = await _context.Plants.FindAsync( plantDto.Id );
            if (plant is null)
                throw new Exception($"Plant with ID {plantDto.Id} was not found.");

           
            plant.PlantName = plantDto.PlantName;                 
            plant.Species = plantDto.Species;
            plant.WaterFrequencyInDays = plantDto.WaterFrequencyInDays;
            plant.SunlightRequirement = plantDto.SunlightRequirement;
            plant.FrequencyOfChangeSoil = plantDto.FrequencyOfChangeSoil;
            plant.FrequencyOfGivingNutrition = plantDto.FrequencyOfGivingNutrition;

            await _context.SaveChangesAsync();
        }
   
        public async Task AddAsync(PlantsDto plantDto)
        { 
            
            var plant = new Plants
            {
                PlantName = plantDto.PlantName,
                Species = plantDto.Species,
                WaterFrequencyInDays = plantDto.WaterFrequencyInDays,
                SunlightRequirement = plantDto.SunlightRequirement,
                FrequencyOfChangeSoil = plantDto.FrequencyOfChangeSoil,
                FrequencyOfGivingNutrition = plantDto.FrequencyOfGivingNutrition,
                CreatedAt = DateTime.UtcNow
            };
            await _context.Plants.AddAsync(plant);
            await _context.SaveChangesAsync();
            plantDto.Id = plant.Id;
            if (plantDto is null) throw new ArgumentNullException(nameof(plantDto));
        }

        public async Task DeleteAsync(int id)
        {
            var plant = await _context.Plants.FindAsync(id);
            if (plant == null)
            {
                throw new KeyNotFoundException($"Plant with ID {id} was not found.");
            }
            _context.Plants.Remove(plant);
            await _context.SaveChangesAsync();

        }

    
    }
}
