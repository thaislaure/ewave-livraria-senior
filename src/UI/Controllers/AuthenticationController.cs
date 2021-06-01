using Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;
using UI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private readonly TokenService _tokenService;
        private readonly IUsuarioRepository _usuarioRepository;

        public AuthenticationController(TokenService tokenService, IUsuarioRepository usuarioRepository)
        {
            _tokenService = tokenService;
            _usuarioRepository = usuarioRepository;
        }

        // POST api/<AuthenticationController>
        [HttpPost]
        public IActionResult Logar([FromBody] UserAuthentication userAuthentication)
        {

            // Buscar os dados do userAuthentication no banco de dados com usernamem e pasword
            // E preencher o userInfo com os dados
            var usuario = _usuarioRepository.GetByUserNamePassword(userAuthentication.Username, userAuthentication.Password);
            if (usuario == null)
                return BadRequest("Username ou Password inválido");

            var userInfo = new User { UserId = usuario.UsuarioId, UserName = userAuthentication.Username, Perfil = usuario.Nome };
            var token = _tokenService.GenerateToken(userInfo);
            return Ok(token);
        }
         
    }

    public class UserAuthentication
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
