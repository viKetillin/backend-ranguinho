using ApiCardapio.Data;
using ApiCardapio.Enumerators;
using ApiCardapio.Interfaces.Repositories;
using ApiCardapio.Interfaces.Services;
using ApiCardapio.Models;
using ApiCardapio.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCardapio.Services
{
    public class NavegacaoService : INavegacaoService
    {
        private readonly Contexto _context;
        private readonly INavegacaoRepository _navegacaoRepository;
        private readonly ICardapioRepository _cardapioRepository;
        private readonly ICategoriaProdutoRepository _categoriaProdutoRepository;
        private readonly IAdicionalRepository _adicionalRepository;
        private readonly IHorarioFuncionamentoRepository _horarioFuncionamentoRepository;
        private readonly ICategoriaEstabelecimentoRepository _categoriaEstabelecimentoRepository;
        private readonly IEstabelecimentoRepository _estabelecimentoRepository;

        public NavegacaoService(INavegacaoRepository navegacaoRepository,
                                ICardapioRepository cardapioRepository,
                                ICategoriaProdutoRepository categoriaProdutoRepository,
                                IAdicionalRepository adicionalRepository,
                                IHorarioFuncionamentoRepository horarioFuncionamentoRepository,
                                ICategoriaEstabelecimentoRepository categoriaEstabelecimentoRepository,
                                IEstabelecimentoRepository estabelecimentoRepository,
                                Contexto context)
        {
            _navegacaoRepository = navegacaoRepository;
            _cardapioRepository = cardapioRepository;
            _categoriaProdutoRepository = categoriaProdutoRepository;
            _adicionalRepository = adicionalRepository;
            _horarioFuncionamentoRepository = horarioFuncionamentoRepository;
            _categoriaEstabelecimentoRepository = categoriaEstabelecimentoRepository;
            _estabelecimentoRepository = estabelecimentoRepository;
            _context = context;
        }

        #region [GET]
        public async Task<ResultadoExecucaoListaQuery<EstabelecimentoQuery>> GetEstabelecimentos()
        {          
            List<EstabelecimentoQuery> estabelecimento = new();
            List<ListaEstabelecimentosQuery> lstEstabelecimentos = new();

            List<CategoriaEstabelecimentoModel> categorias = _categoriaEstabelecimentoRepository.GetCategoriasEstabelecimento().Result.Data;

            foreach (var categoriaRecuperada in categorias)
            {
                List<EstabelecimentoModel> estabelecimentos = _estabelecimentoRepository.GetEstabelecimentosPorCategoria(categoriaRecuperada.Id).Result.Data;

                foreach (var estabelecimentoRecuperado in estabelecimentos)
                {
                    bool statusEstabelecimento = false;
                    List<DiaHorasFuncionamentoModel> horarioFuncionamento = _horarioFuncionamentoRepository.GetHorarioFuncionamentoPorEstabelecimento(estabelecimentoRecuperado.Id).Result.Data;

                    DayOfWeek diaSemanaAtual = DateTime.Now.DayOfWeek;
                    int horaAtual = DateTime.Now.Hour;

                    foreach (var horarioRecuperado in horarioFuncionamento)
                    {
                        int horaInicioSalva = 0;
                        int horaFimSalva = 0;
                        if (horarioRecuperado.HoraInicio.HasValue && horarioRecuperado.HoraInicio.HasValue)
                        {
                            horaInicioSalva = horarioRecuperado.HoraInicio.Value.Hour;
                            horaFimSalva = horarioRecuperado.HoraFim.Value.Hour;
                        }

                        if (diaSemanaAtual >= horarioRecuperado.DiaInicio && diaSemanaAtual <= horarioRecuperado.DiaFim && horaAtual >= horaInicioSalva && horaAtual <= horaFimSalva)
                            statusEstabelecimento = true;
                    }

                    ListaEstabelecimentosQuery objListaEstabelecimentos = new()
                    {
                        Id = estabelecimentoRecuperado.Id,
                        Logo = estabelecimentoRecuperado.Logo,
                        Nome = estabelecimentoRecuperado.Nome,
                        LinkCardapio = estabelecimentoRecuperado.LinkCardapio,
                        StatusEstabelecimento = statusEstabelecimento
                    };
                    lstEstabelecimentos.Add(objListaEstabelecimentos);
                }

                EstabelecimentoQuery objEstabelecimentos = new()
                {
                    IdCategoriaEstabelecimento = categoriaRecuperada.Id,
                    NomeCategoriaEstabelecimento = categoriaRecuperada.Nome,
                    Icone = categoriaRecuperada.Icone,
                    LstEstabelecimentos = lstEstabelecimentos
                };
                estabelecimento.Add(objEstabelecimentos);
            }

            return await Task.FromResult(new ResultadoExecucaoListaQuery<EstabelecimentoQuery>(estabelecimento));
        }

        public async Task<ResultadoExecucaoQuery<EstabelecimentoModel>> GetEstabelecimento(string link)
        {
            return await _navegacaoRepository.GetEstabelecimento(link);
        }

        public async Task<ResultadoExecucaoListaQuery<CardapioQuery>> GetCardapio(int idEstabelecimento)
        {
            bool verificarSeExisteEstabelecimento = VerificarSeExisteEstabelecimento(idEstabelecimento);
            if (!verificarSeExisteEstabelecimento)
            {
                return new ResultadoExecucaoListaQuery<CardapioQuery>
                {
                    ResultadoExecucaoEnum = (int)ResultadoExecucaoEnum.Erro,
                    Mensagem = "Estabelecimento não encontrada!"
                };
            }

            List<CardapioQuery> cardapio = new();

            List<CategoriaProdutoModel> categorias = _categoriaProdutoRepository.GetCategoriasExibidasCardapio(idEstabelecimento).Result.Data;

            foreach (var categoriaRecuperada in categorias)
            {
                List<ListaProdutosEstabelecimentoQuery> recuperarProdutos = _cardapioRepository.GetCardapio(idEstabelecimento, categoriaRecuperada.Id).Result.Data;
                List<ListaAdicionaisEstabelecimentoQuery> recuperarAdicionais = _adicionalRepository.GetAdicionais(idEstabelecimento, categoriaRecuperada.Id).Result.Data;

                CardapioQuery objCardapio = new()
                {
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

        public async Task<ResultadoExecucaoListaQuery<DiaHorarioFuncionamentoQuery>> GetHorarioFuncionamento(int idEstabelecimento)
        {
            bool verificarSeExisteEstabelecimento = VerificarSeExisteEstabelecimento(idEstabelecimento);
            if (!verificarSeExisteEstabelecimento)
            {
                return new ResultadoExecucaoListaQuery<DiaHorarioFuncionamentoQuery>
                {
                    ResultadoExecucaoEnum = (int)ResultadoExecucaoEnum.Erro,
                    Mensagem = "Estabelecimento não encontrada!"
                };
            }

            return await _horarioFuncionamentoRepository.GetHorarioFuncionamento(idEstabelecimento);
        }
        #endregion [GET]

        #region [Privados]
        private bool VerificarSeExisteEstabelecimento(int idEstabelecimento) => _context.Estabelecimentos.Any(e => e.Id == idEstabelecimento);
        #endregion [Privados]
    }
}
