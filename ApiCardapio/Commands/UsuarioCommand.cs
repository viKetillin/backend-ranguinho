using ApiCardapio.Models;
using System;

namespace ApiCardapio.Commands
{
    public class UsuarioCommand
    {
        public int Id { get; set; }
        public string NomeUsuario { get; set; }
        public string EmailUsuario { get; set; }
        public string CodigoUsuario { get; set; }
        public string Senha { get; set; }
        #nullable enable
        public string? Endereco { get; set; }
        public string? Whatsapp { get; set; }
        public int? EstabelecimentoId { get; set; }
        public int? PerfilId { get; set; }
        #nullable disable
        public DateTime DataNascimento { get; set; }        
    }
}
