namespace ApiCardapio.Querys
{
    public class ListaAdicionaisQuery
    {
        public int IdAdicional { get; set; }
        public string NomeAdicional { get; set; }
        public double Valor { get; set; }

        #nullable enable
        public int? IdIngrediente { get; set; }
        public string? NameIngredient { get; set; }
        public string? DescricaoIngrediente { get; set; }
        public string? NomeCategoria { get; set; }
        #nullable disable
    }
}
