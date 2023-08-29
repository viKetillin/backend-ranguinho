using ApiCardapio.Interfaces.Services;
using ApiCardapio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ApiCardapio.Controllers
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(IgnoreApi = false)]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ITokenService _tokenService;
        private IConfiguration _config;

        public LoginController(IUsuarioService usuarioService, ITokenService tokenService, IConfiguration config)
        {
            _usuarioService = usuarioService;
            _tokenService = tokenService;
            _config = config;
        }

        [HttpPost("login")]
        public async Task<ActionResult<dynamic>> Authenticate(string usuario, string senha)
        {
            UsuarioEstabelecimentoModel estabelecimentoUsuarioModel = await _usuarioService.RecuperarEstabelecimentoUsuario(usuario);
            PerfilUsuarioModel user = await _usuarioService.RecuperarUsuarioLogin(usuario, senha);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            string token = _tokenService.GenerateToken(user);
            return new
            {
                user,
                estabelecimentoUsuarioModel,
                token,
            };

        }

        [HttpPost("validarToken")]
        public async Task<dynamic> ValidateToken(string authToken)
        {            
            var tokenHandler = new JwtSecurityTokenHandler();

            SecurityToken validatedToken;
            TokenValidationParameters validationParameters = GetValidationParameters();
            IPrincipal principal = tokenHandler.ValidateToken(authToken, validationParameters, out validatedToken);

            UsuarioEstabelecimentoModel estabelecimentoUsuarioModel = await _usuarioService.RecuperarEstabelecimentoUsuario(principal.Identity.Name);
            PerfilUsuarioModel user = await _usuarioService.RecuperarUsuario(principal.Identity.Name);

            return new
            {
                autenticado = principal.Identity.IsAuthenticated,
                user,
                estabelecimentoUsuarioModel
            };
        }

        private TokenValidationParameters GetValidationParameters()
        {
            var secretKey = _config.GetSection("Jwt").GetSection("Key").Value;          

            return new TokenValidationParameters()
            {
                ValidateLifetime = false, 
                ValidateAudience = false, 
                ValidateIssuer = false,   
                ValidIssuer = "https://localhost:5001/",
                ValidAudience = "https://localhost:5001/",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
            };
        }
    }
}
