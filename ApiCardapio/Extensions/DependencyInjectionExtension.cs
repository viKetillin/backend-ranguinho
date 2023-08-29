using ApiCardapio.Data;
using ApiCardapio.Interfaces.Repositories;
using ApiCardapio.Interfaces.Services;
using ApiCardapio.Repositories;
using ApiCardapio.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace ApiCardapio.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static void ResolveDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            AddDependenciesRepositories(services);
            AddDependenciesServices(services);
        }

        static void AddDependenciesServices(IServiceCollection services)
        {
            services.AddScoped<ICardapioService, CardapioService>();
            services.AddScoped<ICategoriaEstabelecimentoService, CategoriaEstabelecimentoService>();
            services.AddScoped<ICategoriaProdutoService, CategoriaProdutoService>();
            services.AddScoped<ICategoriaAdicionalService, CategoriaAdicionalService>();
            services.AddScoped<IEstabelecimentoService, EstabelecimentoService>();
            services.AddScoped<IHorarioFuncionamentoService, HorarioFuncionamentoService>();
            services.AddScoped<IIngredienteService, IngredienteService>();
            services.AddScoped<IUsuarioService, UsuarioService>();            
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<INavegacaoService, NavegacaoService>();           
            services.AddScoped<IAdicionalService, AdicionalService>();           
        }

        static void AddDependenciesRepositories(IServiceCollection services)
        {
            services.AddScoped<ICardapioRepository, CardapioRepository>();
            services.AddScoped<ICategoriaEstabelecimentoRepository, CategoriaEstabelecimentoRepository>();
            services.AddScoped<ICategoriaProdutoRepository, CategoriasProdutosRepository>();
            services.AddScoped<ICategoriaAdicionalRepository, CategoriaAdicionalRepository>();
            services.AddScoped<IEstabelecimentoRepository, EstabelecimentoRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IPontoCarneRepository, PontoCarneRepository>();
            services.AddScoped<IHorarioFuncionamentoRepository, HorarioFuncionamentoRepository>();
            services.AddScoped<IIngredienteRepository, IngredienteRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IDbContext, DbContexto>();
            services.AddScoped<INavegacaoRepository, NavegacaoRepository>();
            services.AddScoped<IAdicionalRepository, AdicionalRepository>();
        }
    }
}
