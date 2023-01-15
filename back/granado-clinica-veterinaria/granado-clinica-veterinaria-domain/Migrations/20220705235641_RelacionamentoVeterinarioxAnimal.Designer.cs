﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using granado_clinica_veterinaria_domain.Models;

namespace granado_clinica_veterinaria_domain.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220705235641_RelacionamentoVeterinarioxAnimal")]
    partial class RelacionamentoVeterinarioxAnimal
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("granado_clinica_veterinaria_domain.Models.AgendamentoModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("AnimalId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnName("DataCadastro")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DataConsulta")
                        .HasColumnName("DataConsulta")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("VeterinarioId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.HasIndex("VeterinarioId");

                    b.ToTable("Agendamento");
                });

            modelBuilder.Entity("granado_clinica_veterinaria_domain.Models.AnimalModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("ClienteId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnName("DataCadastro")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Idade")
                        .HasColumnName("Idade")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("text");

                    b.Property<long>("TipoAnimalId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("Nome")
                        .IsUnique();

                    b.HasIndex("TipoAnimalId");

                    b.ToTable("Animal");
                });

            modelBuilder.Entity("granado_clinica_veterinaria_domain.Models.AtendimentoModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DataAtendimento")
                        .HasColumnName("DataAtendimento")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnName("DataCadastro")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Diagnostico")
                        .IsRequired()
                        .HasColumnName("Diagnostico")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Atendimento");
                });

            modelBuilder.Entity("granado_clinica_veterinaria_domain.Models.ClienteModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnName("CPF")
                        .HasColumnType("text");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnName("DataCadastro")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CPF")
                        .IsUnique();

                    b.HasIndex("Nome")
                        .IsUnique();

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("granado_clinica_veterinaria_domain.Models.TipoAnimalModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnName("DataCadastro")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TipoAnimal");
                });

            modelBuilder.Entity("granado_clinica_veterinaria_domain.Models.VeterinarioAnimalModel", b =>
                {
                    b.Property<long>("VeterinarioId")
                        .HasColumnType("bigint");

                    b.Property<long>("AnimalId")
                        .HasColumnType("bigint");

                    b.HasKey("VeterinarioId", "AnimalId");

                    b.HasIndex("AnimalId");

                    b.ToTable("VeterinarioAnimal");
                });

            modelBuilder.Entity("granado_clinica_veterinaria_domain.Models.VeterinarioModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnName("DataCadastro")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DataContratacao")
                        .HasColumnName("DataContratacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("Geriatra")
                        .HasColumnName("Geriatra")
                        .HasColumnType("boolean");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Nome")
                        .IsUnique();

                    b.ToTable("Veterinario");
                });

            modelBuilder.Entity("granado_clinica_veterinaria_domain.Models.AgendamentoModel", b =>
                {
                    b.HasOne("granado_clinica_veterinaria_domain.Models.AnimalModel", "Animal")
                        .WithMany("Agendamentos")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("granado_clinica_veterinaria_domain.Models.VeterinarioModel", "Veterinario")
                        .WithMany("Agendamentos")
                        .HasForeignKey("VeterinarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("granado_clinica_veterinaria_domain.Models.AnimalModel", b =>
                {
                    b.HasOne("granado_clinica_veterinaria_domain.Models.ClienteModel", "Cliente")
                        .WithMany("Animals")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("granado_clinica_veterinaria_domain.Models.TipoAnimalModel", "TipoAnimal")
                        .WithMany("Animals")
                        .HasForeignKey("TipoAnimalId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("granado_clinica_veterinaria_domain.Models.VeterinarioAnimalModel", b =>
                {
                    b.HasOne("granado_clinica_veterinaria_domain.Models.AnimalModel", "Animal")
                        .WithMany("VeterinarioAnimals")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("granado_clinica_veterinaria_domain.Models.VeterinarioModel", "Veterinario")
                        .WithMany("VeterinarioAnimals")
                        .HasForeignKey("VeterinarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
