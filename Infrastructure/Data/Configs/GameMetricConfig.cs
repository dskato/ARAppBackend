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

    public class GameMetricConfig : IEntityTypeConfiguration<GameMetricEntity>
    {
        public void Configure(EntityTypeBuilder<GameMetricEntity> builder)
        {
            builder.ToTable("game_metrics");
            builder.HasKey(x => x.Id);

            builder.HasOne(p => p.Game).WithMany(u => u.GameMetrics).HasForeignKey(p => p.GameId);
            builder.HasOne(p => p.User).WithMany(u => u.GameMetrics).HasForeignKey(p => p.UserId);
            builder.HasOne(p => p.Class).WithMany(u => u.GameMetrics).HasForeignKey(p => p.ClassId);
        }
    }
    
}
