using EmpireMan.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmpireMan.Data.Mappings
{
    public class PedidoItensMapping : IEntityTypeConfiguration<PedidoItens>
    {
        public void Configure(EntityTypeBuilder<PedidoItens> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.PedidoId)
                .IsRequired();

            builder.Property(x => x.ProdutoId)
                .IsRequired();

            builder.Property(x => x.Quantidade)
                .IsRequired();

            builder.Property(x => x.ValorUnitario)
               .IsRequired()
               .HasColumnType("decimal(18,2)");

            builder.Property(x => x.ValorTotal)
              .IsRequired()
              .HasColumnType("decimal(18,2)");

            builder.Property(x => x.PercentualDesconto)
              .HasColumnType("decimal(18,2)");

            builder.Property(x => x.ValorDesconto)
             .HasColumnType("decimal(18,2)");

            builder.ToTable("PedidoItens");
        }
    }
}
