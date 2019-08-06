using DDD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD.Infra.Data.Mapping
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Nome)
                   .IsRequired()
                   .HasColumnName("Nome");

            builder.Property(a => a.Fabricante)
                   .IsRequired()
                   .HasColumnName("Fabricante");

            builder.Property(a => a.Codigo)
                   .IsRequired()
                   .HasColumnName("Codigo");

            builder.Property(a => a.Preco)
                   .IsRequired()
                   .HasColumnName("Preco");
        }
    }
}
