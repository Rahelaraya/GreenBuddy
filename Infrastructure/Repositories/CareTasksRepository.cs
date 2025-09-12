using Application.DTO;
using Application.Interface;
using Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CareTasksRepository : ICareTasksRepository
    {
        private readonly AppDbContext _context;
        public CareTasksRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CareTasksDto>> GetAllAsync()
        {
            var entities = await _context.CareTasks.ToListAsync();
            return entities.Select(x => new CareTasksDto
            {
                Id = x.Id,
                PlantId = x.PlantId,
                Type = x.Type,
                LastDoneAt = x.LastDoneAt,
                NextDueAt = x.NextDueAt,

            });

        }

        public async Task<CareTasksDto> GetByIdAsync(int id)
        {
            var entity = await _context.CareTasks.FindAsync(id);
            if (entity == null) return null;
            return new CareTasksDto
            {
                Id = entity.Id,
                PlantId = entity.PlantId,
                Type = entity.Type,
                LastDoneAt = entity.LastDoneAt,
                NextDueAt = entity.NextDueAt,
            };
        }

        public async Task AddAsync(CareTasksDto careTasksDto)
        {
            try
            {
                var entity = new Domain.Entities.CareTasks
                {
                    PlantId = careTasksDto.PlantId,
                    Type = careTasksDto.Type,
                    LastDoneAt = careTasksDto.LastDoneAt,
                    NextDueAt = careTasksDto.NextDueAt,
                };
                _context.CareTasks.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
               
                throw new Exception("An error occurred while adding the care task.", ex);
            }
        }
        public async Task UpdateAsync(CareTasksDto careTasksDto)
        {
            try
            {
                var entity = await _context.CareTasks.FindAsync(careTasksDto.Id);
                if (entity == null)
                {
                    throw new Exception("Care task not found.");
                }
                entity.PlantId = careTasksDto.PlantId;
                entity.Type = careTasksDto.Type;
                entity.LastDoneAt = careTasksDto.LastDoneAt;
                entity.NextDueAt = careTasksDto.NextDueAt;
                _context.CareTasks.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                
                throw new Exception("An error occurred while updating the care task.", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var entity = await _context.CareTasks.FindAsync(id);
                if (entity == null)
                {
                    throw new Exception("Care task not found.");
                }
                _context.CareTasks.Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                
                throw new Exception("An error occurred while deleting the care task.", ex);
            }
        }





    }
}
