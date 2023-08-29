namespace ApiCardapio.Querys
{
    public class IngredienteQuery
    {
        public int Id { get; set; }        
        public string NomeIngrediente { get; set; }

        #nullable enable        
        public string? NameIngredient { get; set; }
        #nullable disable        
        public string DescricaoIngrediente { get; set; }
        public double Valor { get; set; }
        public int? Quantidade { get; set; }
    }
}
