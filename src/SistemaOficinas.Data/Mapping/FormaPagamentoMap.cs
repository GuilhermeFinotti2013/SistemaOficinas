using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaOficinas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaOficinas.Data.Mapping
{
    public class FormaPagamentoMap : IEntityTypeConfiguration<FormaPagamento>
    {
        public void Configure(EntityTypeBuilder<FormaPagamento> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Descricao).IsRequired().HasColumnType("varchar(50)")
                .HasColumnName("Descricao");
        }
    }
}
