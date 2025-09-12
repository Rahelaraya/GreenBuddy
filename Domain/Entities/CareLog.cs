using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CareLog
    {

        public int Id { get; set; }
        public int PlantId { get; set; }
        public string TaskType { get; set; }
        public string Note { get; set; }
        public DateTime Date { get; set; }
    }
}
