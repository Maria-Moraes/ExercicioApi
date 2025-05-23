using Exercicio01.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Exercicio01.Data.Map
{
    public class PedidosMap : IEntityTypeConfiguration<PedidosModel>
    {
        public void Configure(EntityTypeBuilder<PedidosModel> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.usuarioId).IsRequired().HasMaxLength(255);
            builder.Property(x => x.EnderecoEntrega).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.MetodoPagamento).IsRequired();
        }
    }
}
