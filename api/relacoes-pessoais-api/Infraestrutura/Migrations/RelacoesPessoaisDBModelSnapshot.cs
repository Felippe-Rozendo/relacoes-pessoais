﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using relacoes_pessoais_api.Infraestrutura.Context;


#nullable disable

namespace relacoespessoaisapi.Migrations
{
    [DbContext(typeof(RelacoesPessoaisDB))]
    partial class RelacoesPessoaisDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("relacoes_pessoais_api.Infraestrutura.Entities.Contato", b =>
                {
                    b.Property<int>("CodContato")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodContato"));

                    b.Property<int>("CodPessoa")
                        .HasColumnType("int");

                    b.Property<int>("TipoContato")
                        .HasColumnType("int");

                    b.Property<string>("ValorContato")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodContato");

                    b.HasIndex("CodPessoa");

                    b.ToTable("Contatos");
                });

            modelBuilder.Entity("relacoes_pessoais_api.Infraestrutura.Entities.Pessoa", b =>
                {
                    b.Property<int>("CodPessoa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodPessoa"));

                    b.Property<DateTime>("DataModificacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodPessoa");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("relacoes_pessoais_api.Infraestrutura.Entities.Contato", b =>
                {
                    b.HasOne("relacoes_pessoais_api.Infraestrutura.Entities.Pessoa", "Pessoa")
                        .WithMany("Contatos")
                        .HasForeignKey("CodPessoa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("relacoes_pessoais_api.Infraestrutura.Entities.Pessoa", b =>
                {
                    b.Navigation("Contatos");
                });
#pragma warning restore 612, 618
        }
    }
}
