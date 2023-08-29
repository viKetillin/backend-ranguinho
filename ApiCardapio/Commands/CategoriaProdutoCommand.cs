using ApiCardapio.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiCardapio.Commands
{
    public class CategoriaProdutoCommand
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string NomeCategoriaProduto { get; set; }

        [Required]
        public bool ExibirCardapio { get; set; }

        #nullable enable
        [StringLength(100)]
        public string? CategoryName { get; set; }
        public string? LinkImagemFiltro { get; set; }
        public IFormFile? ImagemFiltro { get; set; }
        #nullable disable

        public int? CategoriaAdicionalId { get; set; }
        public int EstabelecimentoId { get; set; }

        public List<AdicionalModel> Adicionais { get; set; }
    }
}
