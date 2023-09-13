using ApiCardapio.Data;
using System.Linq;

namespace ApiCardapio.Utilities
{
    public class Utility
    {
        private readonly Contexto _context;
        public Utility(Contexto context)
        {
            _context = context;
        }

        public bool VerificarSeExisteEstabelecimento(int idEstabelecimento) => _context.Estabelecimentos.Any(e => e.Id == idEstabelecimento);
    }
}
