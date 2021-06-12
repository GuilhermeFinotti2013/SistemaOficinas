using Microsoft.EntityFrameworkCore;
using SistemaOficinas.Domain.Entities;
using SistemaOficinas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaOficinas.Data.ORM
{
    public class OficinasDbContext : DbContext
    {
        public OficinasDbContext(DbContextOptions<OficinasDbContext> options)
            :base(options)
        {

        }

        public DbSet<Cliente> Cliente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // onde não tiver setado varchar e a propriedade for do tipo string fica valendo varchar(valor)
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
            {
                property.SetColumnType("varchar(90)");
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OficinasDbContext).Assembly);
            //remover delete cascade
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);

        }
    }
}
