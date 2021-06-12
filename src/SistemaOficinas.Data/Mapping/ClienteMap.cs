using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaOficinas.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SistemaOficinas.Data.Mapping
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(pk => pk.Id);
            builder.Property(c => c.Nome).HasColumnName("Nome")
                .HasColumnType("varchar(10)");
            builder.Property(c => c.RazaoSocial).HasColumnName("RazaoSocial")
                .HasColumnType("varchar(150)");
            builder.Property(c => c.NomeFantasia).HasColumnName("NomeFantasia")
                .HasColumnType("varchar(150)");
            builder.Property(c => c.CPF).HasColumnName("CPF")
                .HasColumnType("varchar(11)");
            builder.Property(c => c.RG).HasColumnName("RG")
                .HasColumnType("varchar(9)");
            builder.Property(c => c.CNPJ).HasColumnName("CNPJ")
                .HasColumnType("varchar(14)");
            builder.Property(c => c.Endereco).IsRequired().HasColumnName("Endereco")
                .HasColumnType("varchar(200)");
            builder.Property(c => c.Bairro).IsRequired().HasColumnName("Bairro")
                .HasColumnType("varchar(75)");
            builder.Property(c => c.Cidade).IsRequired().HasColumnName("Cidade")
                .HasColumnType("varchar(100)");
            builder.Property(c => c.UF).IsRequired().HasColumnName("UF")
                .HasColumnType("varchar(2)");
            builder.Property(c => c.CEP).HasColumnName("CEP")
                .HasColumnType("varchar(10)");
            builder.Property(c => c.TelefoneFixo).HasColumnName("TelefoneFixo")
                .HasColumnType("varchar(15)");
            builder.Property(c => c.Celular).HasColumnName("Celular")
                .HasColumnType("varchar(15)");
            builder.Property(c => c.Email).IsRequired().HasColumnName("Email")
                .HasColumnType("varchar(100)");
            builder.Property(c => c.Observacoes).HasColumnName("Observacoes")
                .HasColumnType("varchar(400)");
        }
    }
}
