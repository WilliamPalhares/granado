using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace granado_clinica_veterinaria_domain.Models
{
    public class ApplicationContext : DbContext
    {
        public virtual DbSet<AgendamentoModel> Agendamentos { get; set; }
        public virtual DbSet<AnimalModel> Animals { get; set; }
        public virtual DbSet<AtendimentoModel> Atendimentos { get; set; }
        public virtual DbSet<ClienteModel> Clientes { get; set; }
        public virtual DbSet<TipoAnimalModel> TipoAnimals { get; set; }
        public virtual DbSet<VeterinarioModel> Veterinarios { get; set; }
        public virtual DbSet<VeterinarioAnimalModel> VeterinarioAnimals { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.HasDefaultSchema("public");

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AgendamentoModel>().HasKey(t => t.Id);
            modelBuilder.Entity<AgendamentoModel>().Property(t => t.Id).IsRequired();

            //Relacionamento Agendamento x Animal
            modelBuilder.Entity<AgendamentoModel>().HasOne<AnimalModel>(s => s.Animal)
                                               .WithMany(g => g.Agendamentos)
                                               .HasForeignKey(s => s.AnimalId);

            //Relacionamento Agendamento x Veterinario
            modelBuilder.Entity<AgendamentoModel>().HasOne<VeterinarioModel>(s => s.Veterinario)
                                               .WithMany(g => g.Agendamentos)
                                               .HasForeignKey(s => s.VeterinarioId);

            modelBuilder.Entity<AnimalModel>().HasKey(t => t.Id);
            modelBuilder.Entity<AnimalModel>().HasIndex(t => t.Nome).IsUnique();
            modelBuilder.Entity<AnimalModel>().Property(t => t.Id).IsRequired();

            //Relacionamento Animal x Cliente
            modelBuilder.Entity<AnimalModel>().HasOne<ClienteModel>(s => s.Cliente)
                                               .WithMany(g => g.Animals)
                                               .HasForeignKey(s => s.ClienteId);

            //Relacionamento Animal x TipoAnimal
            modelBuilder.Entity<AnimalModel>().HasOne<TipoAnimalModel>(s => s.TipoAnimal)
                                               .WithMany(g => g.Animals)
                                               .HasForeignKey(s => s.TipoAnimalId);

            modelBuilder.Entity<AtendimentoModel>().HasKey(t => t.Id);
            modelBuilder.Entity<AtendimentoModel>().Property(t => t.Id).IsRequired();

            //Relacionamento Atendimento x Veterinario
            modelBuilder.Entity<AtendimentoModel>().HasOne<VeterinarioModel>(s => s.Veterinario)
                                               .WithMany(g => g.Atendimentos)
                                               .HasForeignKey(s => s.VeterinarioId);

            //Relacionamento Atendimento x Animal
            modelBuilder.Entity<AtendimentoModel>().HasOne<AnimalModel>(s => s.Animal)
                                               .WithMany(g => g.Atendimentos)
                                               .HasForeignKey(s => s.AnimalId);

            modelBuilder.Entity<ClienteModel>().HasKey(t => t.Id);
            modelBuilder.Entity<ClienteModel>().HasIndex(t => t.Nome).IsUnique();
            modelBuilder.Entity<ClienteModel>().HasIndex(t => t.CPF).IsUnique();
            modelBuilder.Entity<ClienteModel>().Property(t => t.Id).IsRequired();

            modelBuilder.Entity<TipoAnimalModel>().HasKey(t => t.Id);
            modelBuilder.Entity<TipoAnimalModel>().Property(t => t.Id).IsRequired();

            modelBuilder.Entity<VeterinarioModel>().HasKey(t => t.Id);
            modelBuilder.Entity<VeterinarioModel>().HasIndex(t => t.Nome).IsUnique();
            modelBuilder.Entity<VeterinarioModel>().Property(t => t.Id).IsRequired();

            //Relacionamento de Veterinario x Animal
            modelBuilder.Entity<VeterinarioAnimalModel>().HasKey(sc => new { sc.VeterinarioId, sc.AnimalId });

            modelBuilder.Entity<VeterinarioAnimalModel>()
                .HasOne<VeterinarioModel>(sc => sc.Veterinario)
                .WithMany(s => s.VeterinarioAnimals)
                .HasForeignKey(sc => sc.VeterinarioId);

            modelBuilder.Entity<VeterinarioAnimalModel>()
                .HasOne<AnimalModel>(sc => sc.Animal)
                .WithMany(s => s.VeterinarioAnimals)
                .HasForeignKey(sc => sc.AnimalId);
        }
    }
}
