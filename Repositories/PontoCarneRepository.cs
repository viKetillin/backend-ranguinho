using ApiCardapio.Data;
using ApiCardapio.Interfaces.Repositories;
using ApiCardapio.Querys;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiCardapio.Repositories
{
    public class PontoCarneRepository : IPontoCarneRepository
    {
        private readonly Contexto _context;

        public PontoCarneRepository(Contexto context)
        {
            _context = context;
        }
    }
}
