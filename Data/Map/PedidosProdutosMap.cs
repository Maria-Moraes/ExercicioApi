using Exercicio01.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Exercicio01.Data.Map
{
    public class PedidosProdutosMap : IEntityTypeConfiguration<PedidosProdutosModel>
    {
        public void Configure(EntityTypeBuilder<PedidosProdutosModel> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.ProdutoId).IsRequired().HasMaxLength(255);
            builder.Property(x => x.PedidoId).IsRequired();
            builder.Property(x => x.Quantidade).IsRequired();
            builder.Property(x => x.PrecoUnitario).IsRequired();
            builder.HasOne(x => x.Produtos).WithMany();
            builder.HasOne(x => x.Pedidos).WithMany();
        }
    }
}
