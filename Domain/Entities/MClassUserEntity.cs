using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MClassUserEntity  : BaseEntity
    {
        public int UserId { get; set; }
        public int ClassId { get; set; }

        public virtual UserEntity? User { get; set; }
        public virtual ClassEntity? Class { get; set; }
    }
}
