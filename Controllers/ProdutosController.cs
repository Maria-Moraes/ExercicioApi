using Exercicio01.Model;
using Exercicio01.Repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Exercicio01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutosRepositorio _produtosRepositorio;

        public ProdutosController(IProdutosRepositorio produtosRepositorio)
        {
            _produtosRepositorio = produtosRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProdutosModel>>> BuscarTodosProdutos()
        {
            List<ProdutosModel> produtos = await _produtosRepositorio.BuscarTodosProdutos();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutosModel>> BuscarPorId(int id)
        {
            ProdutosModel produtos = await _produtosRepositorio.BuscarPorId(id);
            return Ok(produtos);
        }
        [HttpPost]

        public async Task<ActionResult<ProdutosModel>> Adicionar([FromBody] ProdutosModel produtos)
        {
            ProdutosModel produtosModel = await _produtosRepositorio.Adicionar(produtos);
            return Ok(produtosModel);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProdutosModel>> Atualizar(int id, [FromBody] ProdutosModel produtos)
        {
            produtos.Id = id;
            ProdutosModel produtosModel = await _produtosRepositorio.Atualizar(produtos, id);
            return Ok(produtos);
        }
        [HttpDelete("{id}")]

        public async Task<ActionResult<ProdutosModel>> Apagar(int id)
        {
            bool apagado = await _produtosRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}

