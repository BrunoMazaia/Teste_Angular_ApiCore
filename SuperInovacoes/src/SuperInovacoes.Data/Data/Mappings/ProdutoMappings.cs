using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperInovacoes.Business.Models;

namespace SuperInovacoes.Data.Data.Mappings
{
    public class ProdutoMappings : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {

            builder.ToTable("Produto");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Valor)
                .IsRequired();

            builder.Property(p => p.Imagem)
                .IsRequired()
                .HasColumnType("varchar(100)");

   
        }
    }
}
