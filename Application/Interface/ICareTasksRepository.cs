using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface ICareTasksRepository
    {
        Task<IEnumerable<CareTasksDto>> GetAllAsync();
        Task<CareTasksDto> GetByIdAsync(int id);
        Task AddAsync(CareTasksDto careTasksDto);
        Task UpdateAsync(CareTasksDto careTasksDto);
        Task DeleteAsync(int id);
    }
}
