// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaOficinas.Data.ORM;

namespace SistemaOficinas.Data.Migrations
{
    [DbContext(typeof(OficinasDbContext))]
    [Migration("20210612213553_MapeandoTabelaCliente")]
    partial class MapeandoTabelaCliente
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SistemaOficinas.Domain.Entities.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(75)")
                        .HasColumnName("Bairro");

                    b.Property<string>("CEP")
                        .HasColumnType("varchar(10)")
                        .HasColumnName("CEP");

                    b.Property<string>("CNPJ")
                        .HasColumnType("varchar(14)")
                        .HasColumnName("CNPJ");

                    b.Property<string>("CPF")
                        .HasColumnType("varchar(11)")
                        .HasColumnName("CPF");

                    b.Property<string>("Celular")
                        .HasColumnType("varchar(15)")
                        .HasColumnName("Celular");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Cidade");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Email");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Endereco");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(10)")
                        .HasColumnName("Nome");

                    b.Property<string>("NomeFantasia")
                        .HasColumnType("varchar(150)")
                        .HasColumnName("NomeFantasia");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Observacoes")
                        .HasColumnType("varchar(400)")
                        .HasColumnName("Observacoes");

                    b.Property<string>("RG")
                        .HasColumnType("varchar(9)")
                        .HasColumnName("RG");

                    b.Property<string>("RazaoSocial")
                        .HasColumnType("varchar(150)")
                        .HasColumnName("RazaoSocial");

                    b.Property<int>("Sexo")
                        .HasColumnType("int");

                    b.Property<int>("Situacao")
                        .HasColumnType("int");

                    b.Property<string>("TelefoneFixo")
                        .HasColumnType("varchar(15)")
                        .HasColumnName("TelefoneFixo");

                    b.Property<int>("TipoPessoa")
                        .HasColumnType("int");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasColumnType("varchar(2)")
                        .HasColumnName("UF");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });
#pragma warning restore 612, 618
        }
    }
}
