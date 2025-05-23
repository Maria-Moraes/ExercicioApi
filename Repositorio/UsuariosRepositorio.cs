using Exercicio01.Data;
using Exercicio01.Model;
using Exercicio01.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Exercicio01.Repositorio
{
    public class UsuariosRepositorio : IUsuariosRepositorio
    {
        private readonly SistemaAtividadeDbContext _dbContext;

        public UsuariosRepositorio(SistemaAtividadeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UsuariosModel> Adicionar(UsuariosModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<bool> Apagar(int id)
        {
            var usuario = await BuscarPorId(id);
            if (usuario == null) return false;

            _dbContext.Usuarios.Remove(usuario);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<UsuariosModel> Atualizar(UsuariosModel usuario, int id)
        {
            var usuariosDb = await BuscarPorId(id);
            if (usuariosDb == null) throw new Exception("Usuario não encontrado!");

            usuariosDb.Nome = usuario.Nome;
            usuariosDb.Email = usuario.Email;
            usuariosDb.DataNasc = usuario.DataNasc;

            _dbContext.Usuarios.Update(usuariosDb);
            await _dbContext.SaveChangesAsync();
            return usuariosDb;
        }


        public async Task<UsuariosModel> BuscarPorId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<UsuariosModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }
    }
}
