using EmpireMan.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmpireMan.Data.Mappings
{
    public class PedidoMapping : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ClienteId)
                .IsRequired();

            builder.Property(x => x.DataPedido)
               .IsRequired();

            builder.Property(x => x.ValorDesconto)
               .HasColumnType("decimal(18,2)");

            builder.HasOne(x => x.Cliente)
               .WithMany(x => x.Pedidos)
               .HasForeignKey(x => x.ClienteId);

            builder.ToTable("Pedidos");
        }
    }
}
