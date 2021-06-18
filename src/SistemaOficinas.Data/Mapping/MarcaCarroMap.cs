using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaOficinas.Domain.Models;

namespace SistemaOficinas.Data.Mapping
{
    public class MarcaCarroMap : IEntityTypeConfiguration<MarcaCarro>
    {
        public void Configure(EntityTypeBuilder<MarcaCarro> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome).IsRequired().HasColumnType("varchar(50)")
                .HasColumnName("Nome");
        }
    }
}
