using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrimeiraApi.Data;
using PrimeiraApi.Models;
using PrimeiraApi.Negocio;
using PrimeiraApi.Repositorios;

namespace PrimeiraApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : AppTestBaseController
    {
        private UsuarioNegocio usuarioNegocio;
        public UsuarioController()
        {
            usuarioNegocio = new UsuarioNegocio(new UsuarioRepositorio(TarefasDbContext));
        }

        [HttpGet]
        public ActionResult<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            var usuarios = usuarioNegocio.BuscarTodosUsuarios();
            return Ok(usuarios);
        }

        [HttpPost]
        public ActionResult Incluir(UsuarioModel usuario)
        {   
            usuarioNegocio.Incluir(usuario);
            return Ok();
        }

        [HttpPut]
        public ActionResult Atualizar(UsuarioModel usuario, int Id)
        {
            usuarioNegocio.Atualizar(usuario, Id);
            return Ok();
        }

    }
}
