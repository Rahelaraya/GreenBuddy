using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class CareTasksDto
    {
        public int Id { get; set; }
        public int PlantId { get; set; }
        public string Type { get; set; } = string.Empty;
        public DateTime LastDoneAt { get; set; }
        public DateTime NextDueAt { get; set; }
    }
}
