using Exercicio01.Model;
using Exercicio01.Repositorio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exercicio01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosRepositorio _usuariosRepositorio;

        public UsuariosController(IUsuariosRepositorio usuarioRepositorio)
        {
            _usuariosRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuariosModel>>> BuscarTodosUsuarios()
        {
            List<UsuariosModel> usuarios = await _usuariosRepositorio.BuscarTodosUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuariosModel>> BuscarPorId(int id)
        {
            UsuariosModel usuario = await _usuariosRepositorio.BuscarPorId(id);
            return Ok(usuario);
        }
        [HttpPost]

        public async Task<ActionResult<UsuariosModel>> Adicionar([FromBody] UsuariosModel usuarios)
        {
            UsuariosModel usuariosModel = await _usuariosRepositorio.Adicionar(usuarios);
            return Ok(usuariosModel);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProdutosModel>> Atualizar(int id, [FromBody] UsuariosModel usuarios)
        {
            usuarios.Id = id;
            UsuariosModel usuario = await _usuariosRepositorio.Atualizar(usuarios, id);
            return Ok(usuario);
        }
        [HttpDelete("{id}")]

        public async Task<ActionResult<ProdutosModel>> Apagar(int id)
        {
            bool apagado = await _usuariosRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
