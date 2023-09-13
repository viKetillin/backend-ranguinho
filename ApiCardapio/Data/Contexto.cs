using ApiCardapio.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ApiCardapio.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        public DbSet<AdicionalModel> Adicionais { get; set; }
        public DbSet<CategoriaAdicionalModel> CategoriaAdicionais { get; set; }
        public DbSet<CategoriaEstabelecimentoModel> CategoriaEstabelecimento { get; set; }
        public DbSet<CategoriaProdutoModel> CategoriaProdutos { get; set; }
        public DbSet<DiaHorasFuncionamentoModel> DiasHorasFuncionamento { get; set; }
        public DbSet<EstabelecimentoModel> Estabelecimentos { get; set; }
        public DbSet<IngredienteModel> Ingredientes { get; set; }
        public DbSet<PagamentoModel> Pagamentos { get; set; }
        public DbSet<PedidoIngredienteModel> PedidosIngredientes { get; set; }
        public DbSet<PedidoModel> Pedidos { get; set; }
        public DbSet<PerfilUsuarioModel> PerfilUsuario { get; set; }
        public DbSet<PerfilModel> Perfis { get; set; }
        public DbSet<PontoCarneModel> PontosCarne { get; set; }
        public DbSet<ProdutoEstabelecimentoModel> ProdutoEstabelecimentos { get; set; }
        public DbSet<ProdutoIngredienteModel> ProdutoIngredientes { get; set; }
        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<ProdutoPedidoModel> ProdutosPedidos { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<UsuarioEstabelecimentoModel> UsuarioEstabelecimento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {          
            #region Perfis
            modelBuilder.Entity<PerfilModel>().HasData(
            new PerfilModel()
            {
                Id = 1,
                NomePerfil = "Admin",
            },
            new PerfilModel()
            {
                Id = 2,
                NomePerfil = "Proprietário",
            });
            #endregion Perfis

            #region Usuário
            modelBuilder.Entity<UsuarioModel>().HasData(
            new UsuarioModel()
            {
                Id = 1,
                NomeUsuario = "Vitória Fusco",
                EmailUsuario = "vitoriaketillin@hotmail.com",
                CodigoUsuario = "vitoria.fusco",
                Senha = "$2a$11$1p.3/q6KPnbMitb8mFihTOvkOuPoxPZ/uitRlr9woiWpHR9/u8TOa",
                Endereco = "Moisés Fantin, 92",
                Whatsapp = "14998700705",                      
            });
            #endregion Usuário

            #region Perfil Usuário
            modelBuilder.Entity<PerfilUsuarioModel>().HasData(
            new PerfilUsuarioModel()
            {
                Id = 1,
                PerfilId = 1,
                UsuarioId = 1
            });
            #endregion Usuário

            modelBuilder.Entity<PedidoIngredienteModel>().HasNoKey();
        }
    }
}