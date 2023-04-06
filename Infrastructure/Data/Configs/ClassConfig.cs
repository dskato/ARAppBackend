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
    public class ClassConfig : IEntityTypeConfiguration<ClassEntity>
    {
        public void Configure(EntityTypeBuilder<ClassEntity> builder)
        {
            builder.ToTable("classes");
            builder.HasKey(x => x.Id);
            builder.HasOne(p => p.Game).WithMany(u => u.Classes).HasForeignKey(p => p.GameId);
        }
    }
}
