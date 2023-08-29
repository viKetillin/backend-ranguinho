using System.ComponentModel.DataAnnotations;

namespace ApiCardapio.Querys
{
    public class UserFromTokenQuery
    {
        [StringLength(200)]
        public string CodigoUsuario { get; set; }

        [StringLength(200)]
        public string Perfil { get;set; }
    }
}
