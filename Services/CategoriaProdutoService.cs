using ApiCardapio.Commands;
using ApiCardapio.Data;
using ApiCardapio.Interfaces.Repositories;
using ApiCardapio.Interfaces.Services;
using ApiCardapio.Models;
using ApiCardapio.Querys;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCardapio.Services
{
    public class CategoriaProdutoService : ICategoriaProdutoService
    {
        private readonly ICategoriaProdutoRepository _categoriaProdutoRepository;
        private readonly ICategoriaAdicionalRepository _categoriaAdicionalRepository;
        private readonly Contexto _context;

        public CategoriaProdutoService(Contexto contexto, ICategoriaProdutoRepository categoriaProdutoRepository, ICategoriaAdicionalRepository categoriaAdicionalRepository)
        {
            _context = contexto;
            _categoriaProdutoRepository = categoriaProdutoRepository;
            _categoriaAdicionalRepository = categoriaAdicionalRepository;
        }

        #region [GET]
        public async Task<ResultadoExecucaoListaQuery<CategoriaProdutoModel>> GetCategoriasExibidasCardapio(int estabelecimentoId)
        {
            return await _categoriaProdutoRepository.GetCategoriasExibidasCardapio(estabelecimentoId);
        }
        #endregion [GET]        

        #region [POST]
        public async Task<ResultadoExecucaoQuery<int>> PostCategoriaProduto(CategoriaProdutoCommand categoriaProduto)
        {
            bool existeCategoriaAdicional = !VerificarSeExisteCategoriaAdicional("Adicional " + categoriaProduto.NomeCategoriaProduto);
            if (existeCategoriaAdicional)
                categoriaProduto.CategoriaAdicionalId = _categoriaAdicionalRepository.PostCategoriaAdicional(categoriaProduto).Result.Data;
            else
                categoriaProduto.CategoriaAdicionalId = _context.CategoriaAdicionais.Where(e => e.NomeCategoriaAdicional == categoriaProduto.NomeCategoriaProduto).FirstOrDefault().Id;

            if (categoriaProduto.Adicionais != null)
            {
                foreach (var adicionais in categoriaProduto.Adicionais)
                {

                    AdicionalModel adicional = new()
                    {
                        IngredienteId = adicionais.IngredienteId,
                        CategoriaAdicionalId = categoriaProduto.CategoriaAdicionalId,
                        Valor = adicionais.Valor
                    };

                    _context.Adicionais.Add(adicional);
                }
            }

            _context.SaveChanges();

            return await _categoriaProdutoRepository.PostCategoriaProduto(categoriaProduto);
        }
        #endregion [POST]

        #region [PUT]
        public async Task<ResultadoExecucaoQuery<int>> PutCategoriaProduto(CategoriaProdutoCommand categoriaProduto)
        {
            if (!VerificarSeExisteCategoriaAdicional("Adicional " + categoriaProduto.NomeCategoriaProduto))
                categoriaProduto.CategoriaAdicionalId = _categoriaAdicionalRepository.PostCategoriaAdicional(categoriaProduto).Result.Data;
            else
                categoriaProduto.CategoriaAdicionalId = _context.CategoriaAdicionais.Where(e => e.NomeCategoriaAdicional == "Adicional " + categoriaProduto.NomeCategoriaProduto).FirstOrDefault().Id;

            if (categoriaProduto.Adicionais != null)
            {
                foreach (var adicionais in categoriaProduto.Adicionais)
                {
                    AdicionalModel adicional = new()
                    {
                        Id = adicionais.Id,
                        IngredienteId = adicionais.IngredienteId,
                        CategoriaAdicionalId = categoriaProduto.CategoriaAdicionalId,
                        Valor = adicionais.Valor
                    };

                    if (adicionais.Id > 0)
                        _context.Adicionais.Update(adicional);
                    else _context.Adicionais.Add(adicional);

                    _context.SaveChanges();
                }
            }

            _context.SaveChanges();

            return await _categoriaProdutoRepository.PutCategoriaProduto(categoriaProduto);
        }
        #endregion [PUT]

        #region [Privados]
        private bool VerificarSeExisteCategoriaAdicional(string nomeCategoriaAdicional) => _context.CategoriaAdicionais.Any(e => e.NomeCategoriaAdicional == nomeCategoriaAdicional);
        #endregion [Privados]
    }
}