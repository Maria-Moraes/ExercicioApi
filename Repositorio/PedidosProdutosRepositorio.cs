using Exercicio01.Data;
using Exercicio01.Model;
using Exercicio01.Repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exercicio01.Repositorio
{
    public class PedidosProdutosRepositorio : IPedidosProdutosRepositorio
    {
        private readonly SistemaAtividadeDbContext _dbContext;

        public PedidosProdutosRepositorio(SistemaAtividadeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PedidosProdutosModel> Adicionar(PedidosProdutosModel pedidosprodutos)
        {
            await _dbContext.PedidosProdutos.AddAsync(pedidosprodutos);
            await _dbContext.SaveChangesAsync();
            return pedidosprodutos;
        }

        public async Task<bool> Apagar(int id)
        {
            var pedidosprodutos = await BuscarPorId(id);
            if (pedidosprodutos == null) return false;

            _dbContext.PedidosProdutos.Remove(pedidosprodutos);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<PedidosProdutosModel> Atualizar(PedidosProdutosModel pedidosprodutos, int id)
        {
            var pedidosprodutosPorId = await BuscarPorId(id);
            if (pedidosprodutosPorId == null) return null;

            pedidosprodutosPorId.ProdutoId = pedidosprodutos.ProdutoId;
            pedidosprodutosPorId.PedidoId = pedidosprodutos.PedidoId;
            pedidosprodutosPorId.Quantidade = pedidosprodutos.Quantidade;
            pedidosprodutosPorId.PrecoUnitario = pedidosprodutos.PrecoUnitario;

            _dbContext.PedidosProdutos.Update(pedidosprodutosPorId);
            await _dbContext.SaveChangesAsync();
            return pedidosprodutosPorId;
        }

        public async Task<PedidosProdutosModel> BuscarPorId(int id)
        {
            return await _dbContext.PedidosProdutos.Include(x=> x.Produtos).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<PedidosProdutosModel>> BuscarTodosPedidosProdutos()
        {
            return await _dbContext.PedidosProdutos.ToListAsync();
        }
    }
}

