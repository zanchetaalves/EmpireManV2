using EmpireMan.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmpireMan.Data.Mappings
{
    public class ProdutoEstoqueMapping : IEntityTypeConfiguration<ProdutoEstoque>
    {
        public void Configure(EntityTypeBuilder<ProdutoEstoque> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Quantidade)
                .IsRequired();

            builder.HasOne(x => x.Produto)
              .WithMany(x => x.ProdutoEstoque)
              .HasForeignKey(x => x.ProdutoId);

            builder.ToTable("ProdutoEstoque");
        }
    }
}
