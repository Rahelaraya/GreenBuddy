using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class CareLogDto
    {
       public int Id { get; set; }
       public int PlantId { get; set; }
       public string TaskType { get; set; }
       public string Note { get; set; }
       public DateTime Date { get; set; }


    }
}
