using System;
using System.IO;
using Dominio;
using Microsoft.EntityFrameworkCore;

namespace Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<Migrante> Migrantes { get; set; }
        public DbSet<Entidad> Entidades { get; set; }
        public DbSet<Emergencia> Emergencias { get; set; }
        public DbSet<Novedad> Novedad {get;set;}
        public DbSet<ServicioEntidad> ServiciosEntidades { get; set; }
        public DbSet <CalificacionApp> CalificacionApp {get;set;}
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            if(!optionBuilder.IsConfigured)
            {
                // Usar ruta persistente en Azure
                var dbPath = Path.Combine(Environment.GetEnvironmentVariable("HOME") ?? ".", "E-Migrant.db");
                optionBuilder.UseSqlite($"Data Source={dbPath}");
            }
        }

        // Manejo de Tablas Intermedias
        //  protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<TablaIntermedia>().HasKey(x=> new{x.Tabla1,x.Tabla2});
        // }
    }
}
