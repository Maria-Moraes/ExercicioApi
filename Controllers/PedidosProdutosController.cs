using Exercicio01.Model;
using Exercicio01.Repositorio;
using Exercicio01.Repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Exercicio01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosProdutosController : ControllerBase
    {
        private readonly IPedidosProdutosRepositorio _pedidosprodutosRepositorio;

        public PedidosProdutosController(IPedidosProdutosRepositorio pedidosprodutosRepositorio)
        {
            _pedidosprodutosRepositorio = pedidosprodutosRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<PedidosProdutosModel>>> BuscarTodosPedidosProdutos()
        {
            List<PedidosProdutosModel> pedidosprodutos = await _pedidosprodutosRepositorio.BuscarTodosPedidosProdutos();
            return Ok(pedidosprodutos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PedidosProdutosModel>> BuscarPorId(int id)
        {
            PedidosProdutosModel pedidosprodutos = await _pedidosprodutosRepositorio.BuscarPorId(id);
            return Ok(pedidosprodutos);
        }
        [HttpPost]

        public async Task<ActionResult<PedidosProdutosModel>> Adicionar([FromBody] PedidosProdutosModel pedidosprodutos)
        {
            PedidosProdutosModel pedidosprodutosModel = await _pedidosprodutosRepositorio.Adicionar(pedidosprodutos);
            return Ok(pedidosprodutosModel);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PedidosProdutosModel>> Atualizar(int id, [FromBody] PedidosProdutosModel pedidosprodutos)
        {
            pedidosprodutos.Id = id;
            PedidosProdutosModel pedidosprodutosModel = await _pedidosprodutosRepositorio.Atualizar(pedidosprodutos, id);
            return Ok(pedidosprodutos);
        }
        [HttpDelete("{id}")]

        public async Task<ActionResult<PedidosProdutosModel>> Apagar(int id)
        {
            bool apagado = await _pedidosprodutosRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}

