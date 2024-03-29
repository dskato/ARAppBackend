﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public int Age  { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public string Role { get; set; } // STUDENT, TEACHER, ADMIN
        public string Status { get; set; } //Active, Inactive
        public virtual List<GameMetricEntity> GameMetrics { get; set; }
        public virtual List<PasswordRestoreEntity> PasswordRestores { get; set; }
        public virtual List<MClassUserEntity> MClassUsers { get; set; }


    }
}
