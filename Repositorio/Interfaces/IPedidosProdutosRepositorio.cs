using Exercicio01.Model;

namespace Exercicio01.Repositorio.Interfaces
{
    public interface IPedidosProdutosRepositorio
    {
        Task<List<PedidosProdutosModel>> BuscarTodosPedidosProdutos();
        Task<PedidosProdutosModel> BuscarPorId(int id);
        Task<PedidosProdutosModel> Adicionar(PedidosProdutosModel pedidosprodutos);
        Task<PedidosProdutosModel> Atualizar(PedidosProdutosModel pedidosprodutos, int id);
        Task<bool> Apagar(int id);
    }
}
