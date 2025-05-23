using Exercicio01.Data;
using Exercicio01.Model;
using Exercicio01.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Exercicio01.Repositorio
{
    public class CategoriasRepositorio : ICategoriasRepositorio
    {
        private readonly SistemaAtividadeDbContext _dbContext;

        public CategoriasRepositorio(SistemaAtividadeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CategoriasModel> Adicionar(CategoriasModel categorias)
        {
            await _dbContext.Categorias.AddAsync(categorias);
            await _dbContext.SaveChangesAsync();
            return categorias;
        }

        public async Task<bool> Apagar(int id)
        {
            var categorias = await BuscarPorId(id);
            if (categorias == null) return false;

            _dbContext.Categorias.Remove(categorias);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<CategoriasModel> Atualizar(CategoriasModel categorias, int id)
        {
            var categoriasDb = await BuscarPorId(id);
            if (categoriasDb == null) return null;

            categoriasDb.Nome = categorias.Nome;
            categoriasDb.Status = categorias.Status;

            _dbContext.Categorias.Update(categoriasDb);
            await _dbContext.SaveChangesAsync();
            return categoriasDb;
        }

        public async Task<CategoriasModel> BuscarPorId(int id)
        {
            return await _dbContext.Categorias.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<CategoriasModel>> BuscarTodasCategorias()
        {
            return await _dbContext.Categorias.ToListAsync();
        }
    }
}
