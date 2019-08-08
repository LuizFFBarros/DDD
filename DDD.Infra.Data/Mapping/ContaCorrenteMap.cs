using DDD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD.Infra.Data.Mapping
{
    public class ContaCorrenteMap : IEntityTypeConfiguration<ContaCorrente>
    {
        public void Configure(EntityTypeBuilder<ContaCorrente> builder)
        {
            builder.ToTable("ContaCorrente");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.CPF)
              .IsRequired()
              .HasColumnName("CPF");

            builder.Property(c => c.Nome)
              .IsRequired()
              .HasColumnName("Nome");

            builder.Property(c => c.Endereco)
              .HasColumnName("Endereco");

            builder.Property(c => c.Telefone)
              .IsRequired()
              .HasColumnName("Telefone");

            builder.Property(c => c.Saldo)
              .IsRequired()
              .HasColumnName("Saldo");

            builder.Property(c => c.SaldoLimiteCredito)
              .IsRequired()
              .HasColumnName("SaldoLimiteCredito");

            builder.Property(c => c.LimiteCredito)
              .IsRequired()
              .HasColumnName("LimiteCredito");

        }
    }
}
