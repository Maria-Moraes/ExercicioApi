using Exercicio01.Model;

namespace Exercicio01.Repositorio.Interfaces
{
    public interface ICategoriasRepositorio
    {
        Task<List<CategoriasModel>> BuscarTodasCategorias();
        Task<CategoriasModel> BuscarPorId(int id);
        Task<CategoriasModel> Adicionar(CategoriasModel categoria);
        Task<CategoriasModel> Atualizar(CategoriasModel categoria, int id);
        Task<bool> Apagar(int id);
    }
}
