using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class GameMetricEntity : BaseEntity
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int UserId { get; set; }
        public int ClassId { get; set; }
        public string Score { get; set; }
        public string TimeElapsed { get; set; }

        public virtual GameEntity? Game { get; set; }
        public virtual UserEntity? User { get; set; }
        public virtual ClassEntity? Class { get; set; }
    }
}
