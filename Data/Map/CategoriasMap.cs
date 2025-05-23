using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Exercicio01.Model;

namespace Exercicio01.Data.Map
{
    public class CategoriasMap : IEntityTypeConfiguration<CategoriasModel>
    {
        public void Configure(EntityTypeBuilder<CategoriasModel> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Status).IsRequired();
        }
    }
}
