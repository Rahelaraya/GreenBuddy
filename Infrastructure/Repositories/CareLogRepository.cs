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
    public class CareLogRepository : ICareLogRepository
    {
        private readonly AppDbContext _context;
        public CareLogRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task <IEnumerable<CareLogDto>> GetAllAsync()
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
    }
}
