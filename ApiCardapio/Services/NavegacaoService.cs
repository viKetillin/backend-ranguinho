using ApiCardapio.Data;
using ApiCardapio.Enumerators;
using ApiCardapio.Interfaces.Repositories;
using ApiCardapio.Interfaces.Services;
using ApiCardapio.Models;
using ApiCardapio.Querys;
using ApiCardapio.Utilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiCardapio.Services
{
    public class NavegacaoService : INavegacaoService
    {
        private readonly Contexto _context;
        private readonly ICardapioRepository _cardapioRepository;
        private readonly ICategoriaProdutoRepository _categoriaProdutoRepository;
        private readonly IAdicionalRepository _adicionalRepository;
        private readonly IHorarioFuncionamentoRepository _horarioFuncionamentoRepository;
        private readonly ICategoriaEstabelecimentoRepository _categoriaEstabelecimentoRepository;
        private readonly IEstabelecimentoRepository _estabelecimentoRepository;

        public NavegacaoService(ICardapioRepository cardapioRepository,
                                ICategoriaProdutoRepository categoriaProdutoRepository,
                                IAdicionalRepository adicionalRepository,
                                IHorarioFuncionamentoRepository horarioFuncionamentoRepository,
                                ICategoriaEstabelecimentoRepository categoriaEstabelecimentoRepository,
                                IEstabelecimentoRepository estabelecimentoRepository,
                                Contexto context)
        {
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
                    List<DiaHorasFuncionamentoModel> horarioFuncionamento = _horarioFuncionamentoRepository.GetHorarioFuncionamentoPorEstabelecimento(estabelecimentoRecuperado.LinkCardapio).Result.Data;

                    bool statusEstabelecimento = VerificarStatusEstabelecimento(horarioFuncionamento);

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

        public async Task<ResultadoExecucaoQuery<ListaEstabelecimentosQuery>> GetEstabelecimento(string link)
        {                        
            List<DiaHorasFuncionamentoModel> horarioFuncionamento = _horarioFuncionamentoRepository.GetHorarioFuncionamentoPorEstabelecimento(link).Result.Data;
            EstabelecimentoModel estabelecimento = _estabelecimentoRepository.GetEstabelecimento(link).Result.Data;           
            bool statusEstabelecimento = VerificarStatusEstabelecimento(horarioFuncionamento);

            ListaEstabelecimentosQuery objEstabelecimento = new()
            {
                Id = estabelecimento.Id,
                Logo = estabelecimento.Logo,
                Nome = estabelecimento.Nome,
                LinkCardapio = estabelecimento.LinkCardapio,
                Cidade = estabelecimento.Cidade,
                Endereco = estabelecimento.Endereco,
                ImagemCapa = estabelecimento.ImagemCapa,
                Telefone = estabelecimento.Telefone,
                UF = estabelecimento.UF,
                StatusEstabelecimento = statusEstabelecimento,
                HorarioFuncionamento = _horarioFuncionamentoRepository.GetHorarioFuncionamento(estabelecimento.Id).Result.Data 
            };

            return await Task.FromResult(new ResultadoExecucaoQuery<ListaEstabelecimentosQuery>(objEstabelecimento));
        }

        public async Task<ResultadoExecucaoListaQuery<CardapioQuery>> GetCardapio(int idEstabelecimento)
        {
            var utilities = new Utility(_context);
            bool verificarSeExisteEstabelecimento = utilities.VerificarSeExisteEstabelecimento(idEstabelecimento);
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
            var utilities = new Utility(_context);

            bool verificarSeExisteEstabelecimento = utilities.VerificarSeExisteEstabelecimento(idEstabelecimento);
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
        private bool VerificarStatusEstabelecimento(List<DiaHorasFuncionamentoModel> horariosFuncionamento)
        {
            TimeSpan saoPauloOffset = TimeSpan.FromHours(-3);
            DateTimeOffset currentTimeInSaoPaulo = DateTimeOffset.UtcNow.ToOffset(saoPauloOffset);            

            DayOfWeek diaSemanaAtual = currentTimeInSaoPaulo.DayOfWeek;
            int horaAtual = currentTimeInSaoPaulo.Hour;

            bool statusEstabelecimento = false;
            foreach (var horarioRecuperado in horariosFuncionamento)
            {
                int horaInicioSalva = 0;
                int horaFimSalva = 0;
                if (horarioRecuperado.HoraInicio.HasValue && horarioRecuperado.HoraFim.HasValue)
                {
                    horaInicioSalva = horarioRecuperado.HoraInicio.Value.Hour;
                    horaFimSalva = horarioRecuperado.HoraFim.Value.Hour;
                }

                if (diaSemanaAtual >= horarioRecuperado.DiaInicio && diaSemanaAtual <= horarioRecuperado.DiaFim && horaAtual >= horaInicioSalva && horaAtual <= horaFimSalva)
                    statusEstabelecimento = true;
            }
            return statusEstabelecimento;
        }
        #endregion [Privados]
    }
}
