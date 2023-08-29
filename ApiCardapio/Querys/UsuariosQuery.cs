using System;

namespace ApiCardapio.Querys
{
    public class UsuariosQuery
    {
        public int Id { get; set; }
        public int PerfilId { get; set; }
        public int EstabelecimentoId { get; set; }
        public string NomeUsuario { get; set; }
        public string EmailUsuario { get; set; }
        public string CodigoUsuario { get; set; }
        public string Senha { get; set; }
        public string Endereco { get; set; }
        public string Whatsapp { get; set; }
        public string LinkCardapio { get; set; }
        public string NomePerfil { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
