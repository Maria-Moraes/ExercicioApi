using Exercicio01.Model;
using Exercicio01.Repositorio;
using Exercicio01.Repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Exercicio01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriasRepositorio _categoriasRepositorio;
        public CategoriasController(ICategoriasRepositorio categoriasRepositorio)
        {
            _categoriasRepositorio = categoriasRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoriasModel>>> BuscarTodasCategorias()
        {
            List<CategoriasModel> categorias = await _categoriasRepositorio.BuscarTodasCategorias();
            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriasModel>> BuscarPorId(int id)
        {
            CategoriasModel categorias = await _categoriasRepositorio.BuscarPorId(id);
            return Ok(categorias);
        }
        [HttpPost]

        public async Task<ActionResult<CategoriasModel>> Adicionar([FromBody] CategoriasModel categorias)
        {
            CategoriasModel categoriasModel = await _categoriasRepositorio.Adicionar(categorias);
            return Ok(categoriasModel);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoriasModel>> Atualizar(int id, [FromBody] CategoriasModel categorias)
        {
            categorias.Id = id;
            CategoriasModel categoriasModel = await _categoriasRepositorio.Atualizar(categorias, id);
            return Ok(categorias);
        }
        [HttpDelete("{id}")]

        public async Task<ActionResult<CategoriasModel>> Apagar(int id)
        {
            bool apagado = await _categoriasRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}

