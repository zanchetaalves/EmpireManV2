using EmpireMan.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmpireMan.Data.Mappings
{
    public class PedidoItensProdutoMapping : IEntityTypeConfiguration<PedidoItensProduto>
    {
        public void Configure(EntityTypeBuilder<PedidoItensProduto> builder)
        {
            builder.HasKey(x => new { x.PedidoItensId, x.ProdutoId });

            builder.HasOne(x => x.PedidoItens)
                .WithMany(x => x.PedidoItensProdutos)
                .HasForeignKey(x => x.PedidoItensId);

            builder.HasOne(x => x.Produto)
                .WithMany(x => x.PedidoItensProdutos)
                .HasForeignKey(x => x.ProdutoId);
        }
    }
}
