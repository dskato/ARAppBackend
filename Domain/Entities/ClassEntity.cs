﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ClassEntity : BaseEntity
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public string ClassName { get; set; }
        public string UserListId { get; set; }
        public virtual GameEntity? Game { get; set; }
        public virtual List<GameMetricEntity> GameMetrics { get; set; } 


    }
}
