using Exercicio01.Data;
using Exercicio01.Model;
using Exercicio01.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Exercicio01.Repositorio
{
    public class PedidosRepositorio : IPedidosRepositorio
    {
        private readonly SistemaAtividadeDbContext _dbContext;

        public PedidosRepositorio(SistemaAtividadeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PedidosModel> Adicionar(PedidosModel pedidos)
        {
            await _dbContext.Pedidos.AddAsync(pedidos);
            await _dbContext.SaveChangesAsync();
            return pedidos;
        }

        public async Task<bool> Apagar(int id)
        {
            var pedidos = await BuscarPorId(id);
            if (pedidos == null) return false;

            _dbContext.Pedidos.Remove(pedidos);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<PedidosModel> Atualizar(PedidosModel pedidos, int id)
        {
            var pedidosPorId = await BuscarPorId(id);
            if (pedidosPorId == null) return null;

            pedidosPorId.usuarioId = pedidos.usuarioId;
            pedidosPorId.EnderecoEntrega = pedidos.EnderecoEntrega;
            pedidosPorId.Status = pedidos.Status;
            pedidosPorId.MetodoPagamento = pedidos.MetodoPagamento;

            _dbContext.Pedidos.Update(pedidosPorId);
            await _dbContext.SaveChangesAsync();
            return pedidosPorId;
        }

        public async Task<PedidosModel> BuscarPorId(int id)
        {
            return await _dbContext.Pedidos.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<PedidosModel>> BuscarTodosPedidos()
        {
            return await _dbContext.Pedidos.ToListAsync();
        }
    }
}

