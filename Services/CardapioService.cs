using ApiCardapio.Data;
using ApiCardapio.Enumerators;
using ApiCardapio.Interfaces.Repositories;
using ApiCardapio.Interfaces.Services;
using ApiCardapio.Models;
using ApiCardapio.Querys;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCardapio.Services
{
    public class CardapioService : ICardapioService
    {
        private readonly Contexto _context;
        private readonly ICardapioRepository _cardapioRepository;
        private readonly ICategoriaProdutoRepository _categoriaProdutoRepository;
        private readonly IAdicionalRepository _adicionalRepository;
        private readonly IIngredienteRepository _ingredienteRepository;

        public CardapioService(Contexto context, ICardapioRepository cardapioRepository, ICategoriaProdutoRepository categoriaProdutoRepository, IAdicionalRepository adicionalRepository, IIngredienteRepository ingredienteRepository)
        {
            _context = context;
            _cardapioRepository = cardapioRepository;
            _categoriaProdutoRepository = categoriaProdutoRepository;
            _adicionalRepository = adicionalRepository;
            _ingredienteRepository = ingredienteRepository;
        }

        #region [GET]
        public async Task<ResultadoExecucaoListaQuery<CardapioQuery>> GetCardapio(int idEstabelecimento, UserFromTokenQuery usuario)
        {
            bool verificarSeUsuarioTemPermissao = VerificarSePerfilUsuarioTemPermissao(idEstabelecimento, usuario);
            if (!verificarSeUsuarioTemPermissao)
            {
                return new ResultadoExecucaoListaQuery<CardapioQuery>
                {
                    ResultadoExecucaoEnum = (int)ResultadoExecucaoEnum.NaoAutorizado,
                    Mensagem = "Usuário não autorizado!"
                };
            }

            bool verificarSeExisteEstabelecimento = VerificarSeExisteEstabelecimento(idEstabelecimento);
            if (!verificarSeExisteEstabelecimento)
            {
                return new ResultadoExecucaoListaQuery<CardapioQuery>
                {
                    ResultadoExecucaoEnum = (int)ResultadoExecucaoEnum.Erro,
                    Mensagem = string.Format("O estabelecimento com id {0} não existe!", idEstabelecimento),
                };
            }

            List<CardapioQuery> cardapio = new();

            List<CategoriaProdutoModel> categorias = _categoriaProdutoRepository.GetCategoriasProduto(idEstabelecimento).Result.Data;

            foreach (var categoriaRecuperada in categorias)
            {
                List<ListaProdutosEstabelecimentoQuery> recuperarProdutos = _cardapioRepository.GetCardapio(idEstabelecimento, categoriaRecuperada.Id).Result.Data;
                List<ListaAdicionaisEstabelecimentoQuery> recuperarAdicionais = _adicionalRepository.GetAdicionais(idEstabelecimento, categoriaRecuperada.Id).Result.Data;

                CardapioQuery objCardapio = new()
                {
                    IdCategoria = categoriaRecuperada.Id,
                    NomeCategoria = categoriaRecuperada.NomeCategoriaProduto,
                    CategoryName = categoriaRecuperada.CategoryName,
                    ImagemFiltro = categoriaRecuperada.ImagemFiltro,
                    LstProdutosEstabelecimento = recuperarProdutos,
                    LstAdicionaisEstabelecimentos = recuperarAdicionais
                };

                cardapio.Add(objCardapio);
            }

            return await Task.FromResult(new ResultadoExecucaoListaQuery<CardapioQuery>(cardapio));
        }

        public async Task<ResultadoExecucaoQuery<ProdutoQuery>> GetProduto(int idEstabelecimento, int idProduto)
        {
            bool verificarSeExisteEstabelecimento = VerificarSeExisteEstabelecimento(idEstabelecimento);
            if (!verificarSeExisteEstabelecimento)
            {
                return new ResultadoExecucaoQuery<ProdutoQuery>
                {
                    ResultadoExecucaoEnum = (int)ResultadoExecucaoEnum.Erro,
                    Mensagem = string.Format("O estabelecimento com id {0} não existe!", idEstabelecimento),
                };
            }            

            ProdutoQuery produto = _cardapioRepository.GetProduto(idEstabelecimento, idProduto).Result.Data;

            List<IngredienteQuery> recuperarIngredientes = _ingredienteRepository.GetIngredientesPorProduto(idEstabelecimento, idProduto).Result.Data;

            ProdutoQuery objProduto = new()
            {
                Id = produto.Id,
                Ativo = produto.Ativo,
                DescricaoProduto = produto.DescricaoProduto,
                ImagemProduto = produto.ImagemProduto,
                Ingredientes = recuperarIngredientes,
                NomeProduto = produto.NomeProduto,
                ProductDescription = produto.ProductDescription,
                Valor = produto.Valor,
                ValorPromocional = produto.ValorPromocional
            };

            return await Task.FromResult(new ResultadoExecucaoQuery<ProdutoQuery>(objProduto));
        }
        #endregion [GET]

        #region [POST]
        public async Task<ResultadoExecucaoQuery<int>> PostProduto([FromBody] ProdutoCommand produtoCommand)
        {
            return await _cardapioRepository.PostProduto(produtoCommand);
        }
        #endregion [POST]

        #region [PUT]
        public async Task<ResultadoExecucaoQuery<int>> PutProduto([FromForm] ProdutoCommand produtoCommand)
        {
            return await _cardapioRepository.PutProduto(produtoCommand);
        }
        #endregion [PUT]   
        
        #region [DELETE]
        public async Task<ResultadoExecucaoQuery<ProdutoModel>> DeleteProduto(int id)
        {
            return await _cardapioRepository.DeleteProduto(id);
        }
        #endregion [PUT]

        #region [Privados]        
        private bool VerificarSeExisteEstabelecimento(int idEstabelecimento) => _context.Estabelecimentos.Any(e => e.Id == idEstabelecimento);

        private bool VerificarSePerfilUsuarioTemPermissao(int idEstabelecimento, UserFromTokenQuery usuario)
        {
            if (usuario.Perfil == "Admin" || usuario.Perfil == "Proprietário")
                return true;
            else if (usuario.Perfil == "Franqueado")
                return _context.UsuarioEstabelecimento.Any(f => f.EstabelecimentoId == idEstabelecimento && f.Usuario.CodigoUsuario == usuario.CodigoUsuario);
            else
                return false;
        }
        #endregion [Privados]
    }
}
