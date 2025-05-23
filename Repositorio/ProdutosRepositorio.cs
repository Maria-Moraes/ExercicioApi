using Exercicio01.Data;
using Exercicio01.Model;
using Exercicio01.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Exercicio01.Repositorio
{
    public class ProdutosRepositorio : IProdutosRepositorio
    {
        private readonly SistemaAtividadeDbContext _dbContext;

        public ProdutosRepositorio(SistemaAtividadeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProdutosModel> Adicionar(ProdutosModel produtos)
        {
            await _dbContext.Produtos.AddAsync(produtos);
            await _dbContext.SaveChangesAsync();
            return produtos;
        }

        public async Task<bool> Apagar(int id)
        {
            var produtos = await BuscarPorId(id);
            if (produtos == null) return false;

            _dbContext.Produtos.Remove(produtos);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ProdutosModel> Atualizar(ProdutosModel produtos, int id)
        {
            var produtosPorId = await BuscarPorId(id);
            if (produtosPorId == null) return null;

            produtosPorId.Nome = produtos.Nome;
            produtosPorId.Descricao = produtos.Descricao;
            produtosPorId.PrecoUnitario = produtos.PrecoUnitario;

            _dbContext.Produtos.Update(produtosPorId);
            await _dbContext.SaveChangesAsync();
            return produtosPorId;
        }

        public async Task<ProdutosModel> BuscarPorId(int id)
        {
            return await _dbContext.Produtos.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<ProdutosModel>> BuscarTodosProdutos()
        {
            return await _dbContext.Produtos.ToListAsync();
        }
    }
}