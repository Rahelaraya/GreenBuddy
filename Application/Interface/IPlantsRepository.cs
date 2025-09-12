using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IPlantsRepository
    {
         Task<IEnumerable<PlantsDto>> GetAllAsync();
         Task<PlantsDto> GetByIdAsync(int id);
         Task AddAsync(PlantsDto plantDto); 
         Task UpdateAsync(PlantsDto plantDto);
         Task DeleteAsync(int id);

        
    }
}
