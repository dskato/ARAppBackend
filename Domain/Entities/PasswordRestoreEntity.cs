﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PasswordRestoreEntity : BaseEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Code { get; set; }

        public virtual UserEntity? User { get; set; }
    }
}
