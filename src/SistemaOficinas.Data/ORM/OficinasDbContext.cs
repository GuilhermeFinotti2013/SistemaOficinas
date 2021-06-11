using Microsoft.EntityFrameworkCore;
using SistemaOficinas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaOficinas.Data.ORM
{
    public class OficinasDbContext : DbContext
    {
        public OficinasDbContext(DbContextOptions<OficinasDbContext> options)
            :base(options)
        {

        }

        public DbSet<Fabricante> Fabricante { get; set; }
    }
}
