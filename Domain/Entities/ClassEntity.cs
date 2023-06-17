using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ClassEntity : BaseEntity
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
        public string Grade { get; set; }
        public string Code { get; set; }
        public virtual List<GameMetricEntity> GameMetrics { get; set; }
        public virtual List<MClassUserEntity> MClassUsers { get; set; }

    }
}
