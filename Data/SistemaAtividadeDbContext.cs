using Exercicio01.Data.Map;
using Exercicio01.Model;
using Microsoft.EntityFrameworkCore;

namespace Exercicio01.Data
{
    public class SistemaAtividadeDbContext : DbContext
    {
        public SistemaAtividadeDbContext(DbContextOptions<SistemaAtividadeDbContext> options)
            : base(options)
        {
        }
        public DbSet<CategoriasModel> Categorias { get; set; }
        public DbSet<PedidosModel> Pedidos { get; set; }
        public DbSet<PedidosProdutosModel> PedidosProdutos { get; set; }
        public DbSet<ProdutosModel> Produtos { get; set; }
        public DbSet<UsuariosModel> Usuarios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuariosMap());
            modelBuilder.ApplyConfiguration(new CategoriasMap());
            modelBuilder.ApplyConfiguration(new PedidosMap());
            modelBuilder.ApplyConfiguration(new PedidosProdutosMap());
            modelBuilder.ApplyConfiguration(new ProdutosMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
