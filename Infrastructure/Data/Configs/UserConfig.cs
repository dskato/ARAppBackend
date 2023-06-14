using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Configs
{
    public class UserConfig : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("users");
            builder.HasKey(x => x.Id);
            builder.HasMany(p => p.GameMetrics).WithOne(p => p.User).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(p => p.PasswordRestores).WithOne(p => p.User).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
