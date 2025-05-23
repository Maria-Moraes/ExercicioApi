using Exercicio01.Model;

namespace Exercicio01.Repositorio.Interfaces
{
    public interface IUsuariosRepositorio
    {
        Task<List<UsuariosModel>> BuscarTodosUsuarios();
        Task<UsuariosModel> BuscarPorId(int id);
        Task<UsuariosModel> Adicionar(UsuariosModel usuario);
        Task<UsuariosModel> Atualizar(UsuariosModel usuario, int id);
        Task<bool> Apagar(int id);
    }
}
