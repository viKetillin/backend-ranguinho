using ApiCardapio.Models;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;

namespace ApiCardapio.Interfaces.Services
{
    public interface ITokenService
    {
       string GenerateToken(PerfilUsuarioModel usuario);
    }
}
