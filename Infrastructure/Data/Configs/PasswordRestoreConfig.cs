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
    public class PasswordRestoreConfig : IEntityTypeConfiguration<PasswordRestoreEntity>
    {
        public void Configure(EntityTypeBuilder<PasswordRestoreEntity> builder)
        {
            builder.ToTable("password_restore");
            builder.HasKey(x => x.Id);
            builder.HasOne(p => p.User).WithMany(u => u.PasswordRestores).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
