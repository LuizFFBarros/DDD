using DDD.Domain.Entities;
using DDD.Domain.Interfaces;
using DDD.Infra.Data.Mapping;
using DDD.Infra.Data.Repository;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Tests
{
    public class SqlInMemory : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<ContaCorrente> ContaCorrente { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Utilizando um servidor SQLite local. Aqui poderíamos configurar qualquer outro banco de dados.
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseInMemoryDatabase(databaseName: "test1");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(new UserMap().Configure);
            modelBuilder.Entity<Produto>(new ProdutoMap().Configure);
            modelBuilder.Entity<ContaCorrente>(new ContaCorrenteMap().Configure);
        }

    }
    
   
}
