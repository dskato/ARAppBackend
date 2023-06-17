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
    public class MClassUserConfig : IEntityTypeConfiguration<MClassUserEntity>
    {
       

        public void Configure(EntityTypeBuilder<MClassUserEntity> builder)
        {
            builder.ToTable("m_class_user");
            builder.HasKey(x => x.UserId);
            builder.HasKey(x => x.ClassId);
            builder.HasOne(p => p.User).WithMany(u => u.MClassUsers).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.Class).WithMany(u => u.MClassUsers).HasForeignKey(p => p.ClassId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
