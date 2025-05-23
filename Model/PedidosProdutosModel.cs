namespace Exercicio01.Model
{
    public class PedidosProdutosModel
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public int PedidoId { get; set; }
        public int Quantidade { get; set; }
        public double PrecoUnitario { get; set; }
        public ProdutosModel? Produtos { get; set; }
        public PedidosModel? Pedidos { get; set; }
    }
}
