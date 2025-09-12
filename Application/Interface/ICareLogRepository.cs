using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface ICareLogRepository
    {
        Task<IEnumerable<CareLogDto>> GetAllAsync();
        Task<CareLogDto> GetByIdAsync(int id);  
        Task AddAsync(CareLogDto careLogDto);
        Task UpdateAsync(CareLogDto careLogDto);
        Task DeleteAsync(int id);

    }
}
