using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class GameEntity : BaseEntity
    {
        public int Id { get; set; }
        public string GameName { get; set; }
        public virtual List<GameMetricEntity> GameMetrics { get; set; } 

    }
}
