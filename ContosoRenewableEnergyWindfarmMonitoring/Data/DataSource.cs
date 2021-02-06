using ContosoRenewableEnergyWindfarmMonitoring.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoRenewableEnergyWindfarmMonitoring.Data
{
    public class DataSource
    {
    }
}




namespace ContosoRenewableEnergyWindfarmMonitoring.Data
{
    public class WindFarmContext : DbContext
    {
        public WindFarmContext(DbContextOptions<WindFarmContext> options) : base(options)
        {
            
        }

        public DbSet<Windmill> Windmills { get; set; }
        public DbSet<Blade> Blades { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Turbine> Turbines { get; set; }
        public DbSet<TurbineTelemetrySample> TurbineTelemetrySamples { get; set; }
        public DbSet<ContosoRenewableEnergyWindfarmMonitoring.Models.TurbineTelemetrySample> TurbineTelemetrySample { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Windmill>().ToTable("Windmill");
            modelBuilder.Entity<Blade>().ToTable("Blade");
            modelBuilder.Entity<Platform>().ToTable("Platform");
            modelBuilder.Entity<Turbine>().ToTable("Turbine");
            modelBuilder.Entity<TurbineTelemetrySample>().ToTable("TurbineTelemetrySample");
        }

        
    }
}