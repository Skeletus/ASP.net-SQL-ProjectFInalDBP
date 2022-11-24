using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ProyectoApi.Models;
using ProyectoApi.services;

namespace ProyectoApi.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly bddefinitivaContext _context;
        public UserController(bddefinitivaContext context)
        {
            _context = context;
        }
        private UsuarioRepository _usuarioRepository = new UsuarioRepository();
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_usuarioRepository.GetAllUsuarios(_context.Usuarios.ToList()));
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var obj = _usuarioRepository.GetUsuarioById(id);
            if (obj == null)
            {
                return NotFound("El usuario " + id.ToString() + " no existe");
            }
            return Ok(obj);
        }
        [HttpPost("agregar")]
        public IActionResult addUsuario(Usuario userr)
        {
            _usuarioRepository.add(userr);
            return CreatedAtAction(nameof(addUsuario), userr);
        }
    }
}
