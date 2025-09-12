using Application.DTO;
using Application.Interface;
using Domain.Entities;
using Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CareLogRepository : ICareLogRepository
    {
        private readonly AppDbContext _context;
        public CareLogRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CareLogDto>> GetAllAsync()
        {
            var careLogs = await _context.CareLogs.ToListAsync();
            return careLogs.Select(cl => new CareLogDto
            {

                Id = cl.Id,
                PlantId = cl.PlantId,
                TaskType = cl.TaskType,
                Note = cl.Note,
                Date = cl.Date

            });

        }

        public async Task<CareLogDto> GetByIdAsync(int id)
        {
            var careLog = await _context.CareLogs.FindAsync(id);
            if (careLog == null) return null;
            return new CareLogDto
            {
                Id = careLog.Id,
                PlantId = careLog.PlantId,
                TaskType = careLog.TaskType,
                Note = careLog.Note,
                Date = careLog.Date
            };
        }


        public async Task AddAsync(CareLogDto careLogDto)
        {
            try
            {
                var careLogs = new CareLogs
                {
                    PlantId = careLogDto.PlantId,
                    TaskType = careLogDto.TaskType,
                    Note = careLogDto.Note,
                    Date = careLogDto.Date
                };
                _context.CareLogs.Add(careLogs);
                await _context.SaveChangesAsync();
                careLogDto.Id = careLogs.Id;
            }
            catch (DbUpdateException dbEx)
            {
                var innerMessage = dbEx.InnerException?.Message ?? dbEx.Message;
                throw new Exception($"Error saving careLog: {innerMessage}", dbEx);

            }

        }
        public async Task UpdateAsync(CareLogDto careLogDto)
        {
            var existingCareLog = await _context.CareLogs.FindAsync(careLogDto.Id);
            if (existingCareLog == null)
            {
                throw new KeyNotFoundException($"CareLog with ID {careLogDto.Id} not found.");
            }
            existingCareLog.PlantId = careLogDto.PlantId;
            existingCareLog.TaskType = careLogDto.TaskType;
            existingCareLog.Note = careLogDto.Note;
            existingCareLog.Date = careLogDto.Date;
            try
            {
                _context.CareLogs.Update(existingCareLog);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                var innerMessage = dbEx.InnerException?.Message ?? dbEx.Message;
                throw new Exception($"Error updating careLog: {innerMessage}", dbEx);
            }
        }

        public async Task DeleteAsync(int id)
        {
            var careLog = await _context.CareLogs.FindAsync(id);
            if (careLog == null)
            {
                throw new KeyNotFoundException($"CareLog with ID {id} not found.");
            }
            try
            {
                _context.CareLogs.Remove(careLog);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                var innerMessage = dbEx.InnerException?.Message ?? dbEx.Message;
                throw new Exception($"Error deleting careLog: {innerMessage}", dbEx);
            }
        }


    }
}
