using Domain.Entities;
using Infrastructure.Data.Configs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Context
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ClassConfig());
            modelBuilder.ApplyConfiguration(new GameConfig());
            modelBuilder.ApplyConfiguration(new GameMetricConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new PasswordRestoreConfig());
        }

        public DbSet<ClassEntity> ClassEntity { get; set; }
        public DbSet<GameEntity> GameEntity { get; set; }
        public DbSet<GameMetricEntity> GameMetricEntity { get; set; }
        public DbSet<UserEntity> UserEntity { get; set; }
        public DbSet<PasswordRestoreEntity> PasswordRestoreEntity { get; set; }



    }
}
